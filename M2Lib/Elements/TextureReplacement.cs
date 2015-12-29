using System.IO;

namespace M2Lib.Elements
{
    [Size(2)]
    public class TextureReplacement : Element
    {
        public ushort Replacement;

        public override void Read(BinaryReader stream)
        {
            Replacement = stream.ReadUInt16();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Replacement);
        }
    }
}
