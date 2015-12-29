using System.IO;

namespace M2Lib.Elements
{
    [Size(2)]
    public class TextureLookup : Element
    {
        ushort Texture;

        public override void Read(BinaryReader stream)
        {
            Texture = stream.ReadUInt16();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Texture);
        }
    }
}
