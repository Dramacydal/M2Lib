using System.IO;

namespace M2Lib.Elements
{
    [Size(4)]
    public class GlobalSequence : Element
    {
        public uint Timestamp;

        public override void Read(BinaryReader stream)
        {
            Timestamp = stream.ReadUInt32();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Timestamp);
        }
    }
}
