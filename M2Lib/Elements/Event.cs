using M2Lib.Structures;
using System.IO;

namespace M2Lib.Elements
{
    [Size(0x24)]
    public class Event : Element
    {
        // 0
        public uint Id;
        // 4
        public uint Data;
        // 8
        public uint Bone;
        // C
        public C3Vector Position;
        // 18
        public TrackBase Enabled = new TrackBase();

        public override void Read(BinaryReader stream)
        {
            Id = stream.ReadUInt32();
            Data = stream.ReadUInt32();
            Bone = stream.ReadUInt32();
            Position = stream.Read<C3Vector>();
            Enabled.Read(stream);
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Id);
            stream.Write(Data);
            stream.Write(Bone);
            stream.Write(Position);
            Enabled.Write(stream);
        }
    }
}
