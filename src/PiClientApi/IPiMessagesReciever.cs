using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace PiClientApi
{
    [Service]
    public interface IPiMessagesReciever
    {
        IAsyncEnumerable<PiConmmand> GetCommandsAsync(CallContext context = default);
    }
}
