using System.IO;

namespace M2Lib.Elements
{
    [Size(2)]
    public class BoneLookup : Element
    {
        public ushort Bone;

        public override void Read(BinaryReader stream)
        {
            Bone = stream.ReadUInt16();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Bone);
        }
    }
}
