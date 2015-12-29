using M2Lib.Structures;
using System.IO;

namespace M2Lib.Elements
{
    [Size(0x9C)]
    public class Light : Element
    {
        // 0
        public ushort Type;
        // 2
        public short Bone;
        // 4
        public C3Vector Position;
        // 10
        public Track<C3Vector> AmbientColor = new Track<C3Vector>();
        // 24
        public Track<float> AmbientInsensity = new Track<float>();
        // 38
        public Track<C3Vector> DiffuseColor = new Track<C3Vector>();
        // 4C
        public Track<float> DiffuseIntensity = new Track<float>();
        // 60
        public Track<float> AttenuationStart = new Track<float>();
        // 74
        public Track<float> AttenuationEnd = new Track<float>();
        // 88
        public Track<byte> Unknown = new Track<byte>();

        public override void Read(BinaryReader stream)
        {
            Type = stream.ReadUInt16();
            Bone = stream.ReadInt16();
            Position = stream.Read<C3Vector>();
            AmbientColor.Read(stream);
            AmbientInsensity.Read(stream);
            DiffuseColor.Read(stream);
            DiffuseIntensity.Read(stream);
            AttenuationStart.Read(stream);
            AttenuationEnd.Read(stream);
            Unknown.Read(stream);
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Type);
            stream.Write(Bone);
            stream.Write(Position);
            AmbientColor.Write(stream);
            AmbientInsensity.Write(stream);
            DiffuseColor.Write(stream);
            DiffuseIntensity.Write(stream);
            AttenuationStart.Write(stream);
            AttenuationEnd.Write(stream);
            Unknown.Write(stream);
        }
    }
}
