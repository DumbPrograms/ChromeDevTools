using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DumbPrograms.ChromeDevTools.Protocol;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace DumbPrograms.ChromeDevTools
{
    public partial class InspectorClient
    {
        private readonly ClientWebSocket WebSocket;
        private readonly InspectionTarget InspectionTarget;
        private readonly JsonSerializerSettings JsonSerializerSettings;

        private int Started;
        private event Action<InspectionMessage> MessageReceived;
        private ConcurrentDictionary<string, EventDispatcher> EventDispatchers;
        private CancellationTokenSource ReceivingLoopCanceller;
        private Task ReceivingLoop;

        private int CommandId = 0;

        public InspectorClient(InspectionTarget inspectionTarget)
        {
            WebSocket = new ClientWebSocket();
            InspectionTarget = inspectionTarget;
            JsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public async Task Start(CancellationToken cancellation = default)
        {
            if (Interlocked.CompareExchange(ref Started, 1, 0) == 0)
            {
                await WebSocket.ConnectAsync(new Uri(InspectionTarget.WebSocketDebuggerUrl), cancellation)
                               .ConfigureAwait(false);

                EventDispatchers = new ConcurrentDictionary<string, EventDispatcher>();
                MessageReceived += DispatchSubscribedEvents;

                ReceivingLoopCanceller = new CancellationTokenSource();
                ReceivingLoop = StartReceivingLoop(ReceivingLoopCanceller.Token);
            }
        }

        private async Task StartReceivingLoop(CancellationToken cancellation)
        {
            var buffer = new byte[1024];
            var stream = new MemoryStream();

            while (!cancellation.IsCancellationRequested)
            {
                if (stream.Length > 1024 * 8)
                {
                    stream = new MemoryStream();
                }
                else
                {
                    stream.SetLength(0);
                }

                while (true)
                {
                    var receive = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellation).ConfigureAwait(false);

                    stream.Write(buffer, 0, receive.Count);

                    if (receive.MessageType == WebSocketMessageType.Close)
                    {
                        await WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", cancellationToken: default).ConfigureAwait(false);

                        ReceivingLoopCanceller.Cancel();

                        return;
                    }

                    if (receive.EndOfMessage)
                    {
                        Debug.Assert(receive.MessageType == WebSocketMessageType.Text);

                        stream.Position = 0;

                        var reader = new StreamReader(stream, Encoding.UTF8);
                        var messageText = reader.ReadToEnd();
                        var message = JsonConvert.DeserializeObject<InspectionMessage>(messageText);

                        MessageReceived?.Invoke(message);

                        break;
                    }
                }
            }
        }

        public async Task<TResponse> InvokeCommand<TResponse>(ICommand<TResponse> command, CancellationToken cancellation = default)
        {
            var id = Interlocked.Increment(ref CommandId);
            var response = RegisterCommandResponseHandler<TResponse>(id, command, cancellation);

            var frame = new InspectionMessage
            {
                Id = id,
                Method = command.Name,
                Params = JObject.Parse(JsonConvert.SerializeObject(command, JsonSerializerSettings))
            };

            var frameText = JsonConvert.SerializeObject(frame, JsonSerializerSettings);
            var bytes = Encoding.UTF8.GetBytes(frameText);

            await WebSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, cancellation)
                           .ConfigureAwait(false);

            return await response.ConfigureAwait(false);
        }

        private Task<TResponse> RegisterCommandResponseHandler<TResponse>(int id, ICommand command, CancellationToken cancellation)
        {
            var tcs = new TaskCompletionSource<TResponse>();

            MessageReceived += Handler;

            return tcs.Task;

            void Handler(InspectionMessage message)
            {
                if (message.Id != id)
                    return;

                if (message.Result is JObject result)
                {
                    tcs.SetResult(result.ToObject<TResponse>());
                }
                else
                {
                    tcs.SetException(new CommandFailedException(command, message.Error.Code, message.Error.Message));
                }

                MessageReceived -= Handler;
            }
        }

        private void DispatchSubscribedEvents(InspectionMessage message)
        {
            if (message.Method != null && EventDispatchers.TryGetValue(message.Method, out var dispatcher))
            {
                dispatcher.Dispatch(message.Params);
            }
        }

        private void AddEventHandler<TEvent>(string name, Func<TEvent, Task> handler)
        {
            var dispatcher = GetEventDispatcher<TEvent>(name);
            dispatcher.Handlers += handler;
        }

        private void RemoveEventHandler<TEvent>(string name, Func<TEvent, Task> handler)
        {
            var dispatcher = GetEventDispatcher<TEvent>(name);
            dispatcher.Handlers -= handler;
        }

        public IDisposable SubscribeEvent<TEvent>(Func<TEvent, Task> handler)
        {
            var @event = typeof(TEvent).GetCustomAttribute<EventAttribute>();
            if (@event != null)
            {
                var dispatcher = GetEventDispatcher<TEvent>(@event.Name);

                dispatcher.Handlers += handler;

                return new EventUnsubscriber<TEvent>(dispatcher, handler);
            }

            throw new ArgumentException($"{typeof(TEvent).Name} is not a valid protocol event type.", nameof(TEvent));
        }

        private EventDispatcher<TEvent> GetEventDispatcher<TEvent>(string name)
            => (EventDispatcher<TEvent>)EventDispatchers.GetOrAdd(name, n => new EventDispatcher<TEvent>());
    }
}