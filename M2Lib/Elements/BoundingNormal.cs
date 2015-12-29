using M2Lib.Structures;
using System.IO;

namespace M2Lib.Elements
{
    [Size(12)]
    public class BoundingNormal : Element
    {
        public C3Vector Normal;

        public override void Read(BinaryReader stream)
        {
            Normal = stream.Read<C3Vector>();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Normal);
        }
    }
}
