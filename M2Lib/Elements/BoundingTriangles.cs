using System.IO;

namespace M2Lib.Elements
{
    [Size(2)]
    public class BoundingTriangles : Element
    {
        ushort Index;

        public override void Read(BinaryReader stream)
        {
            Index = stream.ReadUInt16();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Index);
        }
    }
}
