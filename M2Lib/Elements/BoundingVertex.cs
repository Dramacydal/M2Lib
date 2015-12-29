using M2Lib.Structures;
using System.IO;

namespace M2Lib.Elements
{
    [Size(12)]
    public class BoundingVertex : Element
    {
        public C3Vector Position;

        public override void Read(BinaryReader stream)
        {
            Position = stream.Read<C3Vector>();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Position);
        }
    }
}
