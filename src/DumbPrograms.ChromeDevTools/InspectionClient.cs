using System;
using System.Diagnostics;
using System.IO;
using System.Net.WebSockets;
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
        private event EventHandler<InspectionMessage> MessageReceived;

        private readonly ClientWebSocket WebSocket;
        private readonly InspectionTarget InspectionTarget;

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
            await WebSocket.ConnectAsync(new Uri(InspectionTarget.WebSocketDebuggerUrl), cancellation);

            ReceivingLoopCanceller = new CancellationTokenSource();
            ReceivingLoop = StartReceivingLoop(ReceivingLoopCanceller.Token);
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

        public async Task<TResponse> InvokeCommand<TCommand, TResponse>(TCommand command, CancellationToken cancellation = default)
            where TCommand : ICommand<TResponse>
        {
            var id = Interlocked.Increment(ref CommandId);
            var frame = new InspectionMessage
            {
                Id = id,
                Method = command.Name,
                Params = command
            };

            var frameText = JsonConvert.SerializeObject(frame);
            var bytes = Encoding.UTF8.GetBytes(frameText);

            var response = RegisterCommandResponseHandler<TResponse>(id);

            await WebSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, false, cancellation);

            return await response;
        }

        private Task<TResponse> RegisterCommandResponseHandler<TResponse>(int id)
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