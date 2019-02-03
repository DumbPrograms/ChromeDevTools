using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net.WebSockets;
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
        private event Func<InspectionMessage, Task> MessageReceived;
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

                        await MessageReceived?.Invoke(message);

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

            MessageReceived += CommandResponseHandler;

            return tcs.Task;

            Task CommandResponseHandler(InspectionMessage message)
            {
                if (message.Id != id)
                {
                    return Task.FromResult(false);
                }

                if (message.Result is JObject result)
                {
                    tcs.SetResult(result.ToObject<TResponse>());
                }
                else
                {
                    tcs.SetException(new CommandFailedException(command, message.Error.Code, message.Error.Message));
                }

                MessageReceived -= CommandResponseHandler;

                return Task.FromResult(true);
            }
        }

        private async Task DispatchSubscribedEvents(InspectionMessage message)
        {
            if (message.Method != null && EventDispatchers.TryGetValue(message.Method, out var dispatcher))
            {
                await dispatcher.Dispatch(message.Params).ConfigureAwait(false);
            }
        }

        private EventDispatcher<TEvent> AddEventHandler<TEvent>(string name, Func<TEvent, Task> handler)
        {
            var dispatcher = GetEventDispatcher<TEvent>(name);
            dispatcher.Handlers += handler;

            return dispatcher;
        }

        private void RemoveEventHandler<TEvent>(string name, Func<TEvent, Task> handler)
        {
            var dispatcher = GetEventDispatcher<TEvent>(name);
            dispatcher.Handlers -= handler;
        }

        private Task<TEvent> SubscribeUntil<TEvent>(string name, Func<TEvent, Task<bool>> handler)
        {
            var tcs = new TaskCompletionSource<TEvent>();

            var dispatcher = GetEventDispatcher<TEvent>(name);
            dispatcher.Handlers += UntilHandler;

            return tcs.Task;

            async Task UntilHandler(TEvent e)
            {
                if (handler == null || await handler(e))
                {
                    dispatcher.Handlers -= UntilHandler;
                    tcs.SetResult(e);
                }
            }
        }

        private EventDispatcher<TEvent> GetEventDispatcher<TEvent>(string name)
            => (EventDispatcher<TEvent>)EventDispatchers.GetOrAdd(name, n => new EventDispatcher<TEvent>());
    }
}