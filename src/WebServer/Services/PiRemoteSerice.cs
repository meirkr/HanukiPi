using PiClientApi;
using ProtoBuf.Grpc;

namespace WebServer.Services
{
    public class PiRemoteSerice : IPiMessagesReciever
    {
        public async IAsyncEnumerable<PiConmmand> GetCommandsAsync(CallContext context = default)
        {
            await Task.Delay(5000);
            yield return new PiConmmand()
            {
                operationMode = OperationMode.Auto,
            };
            await Task.Delay(5000);
            yield return new PiConmmand()
            {
                operationMode = OperationMode.Manual,
                NineLeds = new[] { true, false, false, false, false, false, false, true, false },
                Shamash = true,
            };
        }
    }
}
