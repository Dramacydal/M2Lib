using M2Lib.Structures;
using System.IO;

namespace M2Lib.Elements
{
    [Size(0x28)]
    public class Attachment : Element
    {
        // 0
        public uint Id;
        // 4
        public uint Bone;
        // 8
        public C3Vector Position;
        // 14
        public Track<byte> AnimateAttached = new Track<byte>();

        public override void Read(BinaryReader stream)
        {
            Id = stream.ReadUInt32();
            Bone = stream.ReadUInt32();
            Position = stream.Read<C3Vector>();
            AnimateAttached.Read(stream);
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Id);
            stream.Write(Bone);
            stream.Write(Position);
            AnimateAttached.Write(stream);
        }
    }
}
