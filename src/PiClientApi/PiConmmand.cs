using ProtoBuf;

namespace PiClientApi
{
    public enum OperationMode
    {
        Auto,
        Manual,
    }

    [ProtoContract]
    public class PiConmmand
    {
        [ProtoMember(1)]
        public OperationMode operationMode { get; set; }

        [ProtoMember(2)]
        public bool[]? NineLeds { get; set; }
        
        [ProtoMember(3)]
        public bool? Shamash { get; set; }
    }
}
