using M2Lib.Structures;
using System.IO;

namespace M2Lib.Elements
{
    [Size(0x74)]
    public class Camera : Element
    {
        // 0
        public uint Type;
        // 4
        public float FarClip;
        // 8
        public float NearClip;
        // C
        public Track<SplineKey<C3Vector>> Positions = new Track<SplineKey<C3Vector>>();
        // 20
        public C3Vector PositionBase;
        // 2C
        public Track<SplineKey<C3Vector>> TargetPositions = new Track<SplineKey<C3Vector>>();
        // 40
        public C3Vector TargetPositionBase;
        // 4C
        public Track<SplineKey<float>> Roll = new Track<SplineKey<float>>();
        // 60
        public Track<SplineKey<float>> FoV = new Track<SplineKey<float>>();

        public override void Read(BinaryReader stream)
        {
            Type = stream.ReadUInt32();
            FarClip = stream.ReadSingle();
            NearClip = stream.ReadSingle();
            Positions.Read(stream);
            PositionBase = stream.Read<C3Vector>();
            TargetPositions.Read(stream);
            TargetPositionBase = stream.Read<C3Vector>();
            Roll.Read(stream);
            FoV.Read(stream);
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Type);
            stream.Write(FarClip);
            stream.Write(NearClip);
            Positions.Write(stream);
            stream.Write(PositionBase);
            TargetPositions.Write(stream);
            stream.Write(TargetPositionBase);
            Roll.Write(stream);
            FoV.Write(stream);
        }
    }
}
