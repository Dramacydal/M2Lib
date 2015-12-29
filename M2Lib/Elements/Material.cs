using System.IO;

namespace M2Lib.Elements
{
    [Size(4)]
    public class Material : Element
    {
        // 0
        ushort Flags;
        // 2
        ushort BlendingMode;

        public override void Read(BinaryReader stream)
        {
            Flags = stream.ReadUInt16();
            BlendingMode = stream.ReadUInt16();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Flags);
            stream.Write(BlendingMode);
        }
    }
}
