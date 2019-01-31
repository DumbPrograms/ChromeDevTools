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

namespace DumbPrograms.ChromeDevTools
{
    public partial class InspectionClient
    {
        private readonly ClientWebSocket WebSocket;
        private readonly InspectionTarget InspectionTarget;

        private int Started;
        private event EventHandler<InspectionMessage> MessageReceived;
        private ConcurrentDictionary<string, EventDispatcher> EventDispatchers;
        private CancellationTokenSource ReceivingLoopCanceller;
        private Task ReceivingLoop;

        private int CommandId = 0;

        public InspectionClient(InspectionTarget inspectionTarget)
        {
            WebSocket = new ClientWebSocket();
            InspectionTarget = inspectionTarget;
        }

        public async Task Start(CancellationToken cancellation = default)
        {
            if (Interlocked.CompareExchange(ref Started, 1, 0) == 0)
            {
                await WebSocket.ConnectAsync(new Uri(InspectionTarget.WebSocketDebuggerUrl), cancellation);

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
                    stream.Position = 0;
                }

                while (true)
                {
                    var receive = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellation);

                    stream.Write(buffer, 0, receive.Count);

                    if (receive.MessageType == WebSocketMessageType.Close)
                    {
                        await WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", cancellationToken: default);

                        ReceivingLoopCanceller.Cancel();

                        return;
                    }

                    if (receive.EndOfMessage)
                    {
                        Debug.Assert(receive.MessageType == WebSocketMessageType.Text);

                        var reader = new StreamReader(stream, Encoding.UTF8);
                        var message = JsonConvert.DeserializeObject<InspectionMessage>(reader.ReadToEnd());

                        MessageReceived?.Invoke(this, message);

                        break;
                    }
                }
            }
        }

        private Task InvokeCommand(int id, ICommand command, CancellationToken cancellation)
        {
            var frame = new InspectionMessage
            {
                Id = id,
                Method = command.Name,
                Params = JObject.FromObject(command)
            };

            var frameText = JsonConvert.SerializeObject(frame);
            var bytes = Encoding.UTF8.GetBytes(frameText);

            return WebSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, false, cancellation);
        }

        public Task InvokeCommand(ICommand command, CancellationToken cancellation = default)
        {
            var id = Interlocked.Increment(ref CommandId);

            return InvokeCommand(id, command, cancellation);
        }

        public async Task<TResponse> InvokeCommand<TResponse>(ICommand<TResponse> command, CancellationToken cancellation = default)
        {
            var id = Interlocked.Increment(ref CommandId);
            var response = RegisterCommandResponseHandler<TResponse>(id, cancellation);

            await InvokeCommand(id, command, cancellation);

            return await response;
        }

        private void DispatchSubscribedEvents(object sender, InspectionMessage message)
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

        private Task<TResponse> RegisterCommandResponseHandler<TResponse>(int id, CancellationToken cancellation)
        {
            var tcs = new TaskCompletionSource<TResponse>();
            var handler = GetCommandResponseMessageReceivedHandler(tcs, id);

            MessageReceived += handler;

            return tcs.Task;
        }

        private EventHandler<InspectionMessage> GetCommandResponseMessageReceivedHandler<T>(TaskCompletionSource<T> tcs, int id)
        {
            EventHandler<InspectionMessage> handler = null;
            handler = new EventHandler<InspectionMessage>((o, message) =>
            {
                if (message.Id != id)
                    return;

                if (message.Result is JObject result)
                {
                    tcs.SetResult(result.ToObject<T>());
                }
                else
                {
                    tcs.SetException(new Exception($"Code: {message.Error.Code}; Message: {message.Error.Message}"));
                }

                MessageReceived -= handler;
            });

            return handler;
        }
    }
}