using M2Lib.Structures;
using System;
using System.IO;

namespace M2Lib.Elements
{
    [Size(0xB0)]
    public class RibbonEmitter : Element
    {
        // 0
        public uint Unk;
        // 4
        public uint Bone;
        // 8
        public C3Vector Position;
        // 14
        public ArrayRef<ushort> TextureRef = new ArrayRef<ushort>();
        // 1C
        public ArrayRef<ushort> BlendRef = new ArrayRef<ushort>();
        // 24
        public Track<C3Vector> Color = new Track<C3Vector>();
        // 38
        public Track<ushort> Opacity = new Track<ushort>();
        // 4C
        public Track<float> HeightAbove = new Track<float>();
        // 60
        public Track<float> HeightBelow = new Track<float>();
        // 74
        public float Resolution;
        // 78
        public float Length;
        // 7C
        public float EmissionAngle;
        // 80
        public ushort[] RenderFlags = new ushort[2];
        // 84
        public Track<ushort> Unk1 = new Track<ushort>();
        // 98
        public Track<byte> Unk2 = new Track<byte>();
        // AC
        public uint Unk3;

        public override void Read(BinaryReader stream)
        {
            Unk = stream.ReadUInt32();
            Bone = stream.ReadUInt32();
            Position = stream.Read<C3Vector>();
            TextureRef.Read(stream);
            BlendRef.Read(stream);

            Color.Read(stream);
            Opacity.Read(stream);
            HeightAbove.Read(stream);
            HeightBelow.Read(stream);

            Resolution = stream.ReadSingle();
            Length = stream.ReadSingle();
            EmissionAngle = stream.ReadSingle();

            RenderFlags = stream.Read<ushort>(RenderFlags.Length);

            Unk1.Read(stream);
            Unk2.Read(stream);

            Unk3 = stream.ReadUInt32();
        }

        public override void Write(MyBinaryWriter stream)
        {
            throw new NotImplementedException();
        }
    }
}
