using System.IO;

namespace M2Lib.Elements
{
    [Size(0xC)]
    public class TrackBase : Element
    {
        public ushort InterpolationType;
        public ushort GlobalSequence;
        public ArrayRef<uint> TimeStamps = new ArrayRef<uint>();

        public override void Read(BinaryReader stream)
        {
            InterpolationType = stream.ReadUInt16();
            GlobalSequence = stream.ReadUInt16();
            TimeStamps.Read(stream);
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(InterpolationType);
            stream.Write(GlobalSequence);
            TimeStamps.Write(stream);
        }
    }
}
