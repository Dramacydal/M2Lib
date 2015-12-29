using M2Lib.Structures;
using System.IO;

namespace M2Lib.Elements
{
    [Size(48)]
    public class Vertex : Element
    {
        // 0
        public C3Vector Position;
        // C
        public byte[] Weights = new byte[4];
        // 10
        public byte[] Indices = new byte[4];
        // 14
        public C3Vector Normal;
        // 20
        public C2Vector[] TextureCoordinates = new C2Vector[2];

        public override void Read(BinaryReader stream)
        {
            Position = stream.Read<C3Vector>();
            Weights = stream.ReadBytes(Weights.Length);
            Indices = stream.ReadBytes(Indices.Length);
            Normal = stream.Read<C3Vector>();
            TextureCoordinates = stream.Read<C2Vector>(TextureCoordinates.Length);
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Position);
            for (var i = 0; i < Weights.Length; ++i)
                stream.Write(Weights[i]);
            for (var i = 0; i < Indices.Length; ++i)
                stream.Write(Indices[i]);
            stream.Write(Normal);
            for (var i = 0; i < TextureCoordinates.Length; ++i)
                stream.Write(TextureCoordinates[i]);
        }
    }
}
