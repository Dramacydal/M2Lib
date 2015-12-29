using System.IO;

namespace M2Lib.Elements
{
    [Size(2)]
    public class TransparencyLookup : Element
    {
        public ushort Transparency;

        public override void Read(BinaryReader stream)
        {
            Transparency = stream.ReadUInt16();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Transparency);
        }
    }
}
