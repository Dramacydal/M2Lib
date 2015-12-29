using System.IO;

namespace M2Lib.Elements
{
    [Size(2)]
    public class TextureUnit : Element
    {
        ushort Unit;

        public override void Read(BinaryReader stream)
        {
            Unit = stream.ReadUInt16();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Unit);
        }
    }
}
