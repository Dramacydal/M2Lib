using M2Lib.Structures;
using System;
using System.IO;

namespace M2Lib.Elements
{
    [Size(0x1EC)]
    public class ParticleEmitter : Element
    {
        // 0
        public uint Unknown;
        // 4
        public uint Flags;
        // 8
        public C3Vector Position;
        // 14
        public ushort Bone;
        // 16
        public ushort PackedTexture;
        // 18
        public ArrayRef<char> ModelFileName = new ArrayRef<char>();
        // 20
        public ArrayRef<char> ChildEmitterFileName = new ArrayRef<char>();
        // 28
        public byte BlendingType;
        // 29
        public byte EmitterType;
        // 2A
        public ushort ParticleColorIndex;
        // 2C
        public byte ParticleType;
        // 2D
        public byte HeadOrTail;
        // 2E
        public ushort TextureTileRotation;
        // 30
        public ushort TextureDimensionRows;
        // 32
        public ushort TextureDimensionColumns;
        // 34
        public Track<float> EmissionSpeed = new Track<float>();
        // 48
        public Track<float> SpeedVariation = new Track<float>();
        // 5C
        public Track<float> VerticalRange = new Track<float>();
        // 70
        public Track<float> HorizontalRange = new Track<float>();
        // 84
        public Track<float> Gravity = new Track<float>();
        // 98
        public Track<float> LifeSpan = new Track<float>();
        // AC
        public uint UnkPadding;
        // B0
        public Track<float> EmissionRate = new Track<float>();
        // C4
        public uint UnkPadding2;
        // C8
        public Track<float> EmissionAreaLength = new Track<float>();
        // DC
        public Track<float> EmissingAreaWidth = new Track<float>();
        // F0
        public Track<float> Gravity2 = new Track<float>();
        // 104
        public FakeAnimationBlock<C3Vector> ColorTrack = new FakeAnimationBlock<C3Vector>();
        // 114
        public FakeAnimationBlock<ushort> AlphaTrack = new FakeAnimationBlock<ushort>();
        // 124
        public FakeAnimationBlock<C2Vector> ScaleTrack = new FakeAnimationBlock<C2Vector>();
        // 134
        public float[] UnknownFields = new float[2];
        // 13C
        public FakeAnimationBlock<ushort> HeadCellTrack = new FakeAnimationBlock<ushort>();
        // 14C
        public FakeAnimationBlock<ushort> TailCellTrack = new FakeAnimationBlock<ushort>();
        // 15C
        public float SomethingParticleStyle;
        // 160
        public float[] UnknownFloats1 = new float[2];
        // 168
        public CRange TwinkleScale;
        // 170
        public uint Unk;
        // 174
        public float Drag;
        // 178
        public float[] UnknownFloats2 = new float[2];
        // 180
        public float Rotation;
        // 184
        public float[] UnknownFloats3 = new float[2];
        // 18C
        public C3Vector Rotation1;
        // 198
        public C3Vector Rotation2;
        // 1A4
        public C3Vector Translation;
        // 1B0
        public float[] FollowParams = new float[4];
        // 1C0
        public ArrayRef<C3Vector> UnknownReference;
        // 1C8
        public Track<char> EnabledIn;
        // 1DC
        public uint[] Unk2 = new uint[4];

        public override void Read(BinaryReader s)
        {
            Unknown = s.ReadUInt32();
            Flags = s.ReadUInt32();
            Position = s.Read<C3Vector>();
            Bone = s.ReadUInt16();
            PackedTexture = s.ReadUInt16();
            ModelFileName.Read(s);
            ChildEmitterFileName.Read(s);
            BlendingType = s.ReadByte();
            EmitterType = s.ReadByte();
            ParticleColorIndex = s.ReadUInt16();
            ParticleType = s.ReadByte();
            HeadOrTail = s.ReadByte();
            TextureTileRotation = s.ReadUInt16();
            TextureDimensionRows = s.ReadUInt16();
            TextureDimensionColumns = s.ReadUInt16();
            EmissionSpeed.Read(s);
            SpeedVariation.Read(s);
            VerticalRange.Read(s);
            HorizontalRange.Read(s);
            Gravity.Read(s);
            LifeSpan.Read(s);
            UnkPadding = s.ReadUInt32();
            EmissionRate.Read(s);
            UnkPadding2 = s.ReadUInt32();
            EmissionAreaLength.Read(s);
            EmissingAreaWidth.Read(s);
            Gravity2.Read(s);
            ColorTrack.Read(s);
            AlphaTrack.Read(s);
            ScaleTrack.Read(s);
            UnknownFields = s.Read<float>(UnknownFields.Length);
            HeadCellTrack.Read(s);
            TailCellTrack.Read(s);
            SomethingParticleStyle = s.ReadSingle();
            UnknownFloats1 = s.Read<float>(UnknownFloats1.Length);
            TwinkleScale = s.Read<CRange>();
            Unk = s.ReadUInt32();
            Drag = s.ReadSingle();
            UnknownFloats2 = s.Read<float>(UnknownFloats2.Length);
            Rotation = s.ReadSingle();
            UnknownFloats3 = s.Read<float>(UnknownFloats3.Length);
            Rotation1 = s.Read<C3Vector>();
            Rotation2 = s.Read<C3Vector>();
            Translation = s.Read<C3Vector>();
            FollowParams = s.Read<float>(FollowParams.Length);
            UnknownReference.Read(s);
            EnabledIn.Read(s);
            Unk2 = s.Read<uint>(Unk2.Length);
        }

        public override void Write(MyBinaryWriter stream)
        {
            throw new NotImplementedException();
        }
    }
}
