using System.IO;

namespace M2Lib.Elements
{
    [Size(0x14)]
    public class Transparency : Element
    {
        public Track<ushort> Weight = new Track<ushort>();

        public override void Read(BinaryReader stream)
        {
            Weight.Read(stream);
        }

        public override void Write(MyBinaryWriter stream)
        {
            Weight.Write(stream);
        }
    }
}
