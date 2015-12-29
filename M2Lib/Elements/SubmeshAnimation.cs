using M2Lib.Structures;
using System.IO;

namespace M2Lib.Elements
{
    [Size(0x28)]
    public class SubmeshAnimation : Element
    {
        // 0
        public Track<C3Vector> Color = new Track<C3Vector>();
        // 14
        public Track<ushort> Alpha = new Track<ushort>();

        public override void Read(BinaryReader stream)
        {
            Color.Read(stream);
            Alpha.Read(stream);
        }

        public override void Write(MyBinaryWriter stream)
        {
            Color.Write(stream);
            Alpha.Write(stream);
        }
    }
}
