using M2Lib.Structures;
using System.IO;

namespace M2Lib.Elements
{
    [Size(0x58)]
    public class Bone : Element
    {
        // 0
        public int KeyBoneId;
        // 4
        public uint Flags;
        // 8
        public short ParentBone;
        // A
        public ushort SubmeshId;
        // C
        public ushort[] Unknown = new ushort[2];
        // 10
        public Track<C3Vector> Translation = new Track<C3Vector>();
        // 24
        public Track<CompQuat> Rotation = new Track<CompQuat>();
        // 38
        public Track<C3Vector> Scale = new Track<C3Vector>();
        // 4C
        public C3Vector Pivot;

        public override void Read(BinaryReader stream)
        {
            KeyBoneId = stream.ReadInt32();
            Flags = stream.ReadUInt32();
            ParentBone = stream.ReadInt16();
            SubmeshId = stream.ReadUInt16();
            Unknown = stream.Read<ushort>(Unknown.Length);
            Translation.Read(stream);
            Rotation.Read(stream);
            Scale.Read(stream);
            Pivot = stream.Read<C3Vector>();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(KeyBoneId);
            stream.Write(Flags);
            stream.Write(ParentBone);
            stream.Write(SubmeshId);
            for (var i = 0; i < Unknown.Length;++i)
                stream.Write(Unknown[i]);
            Translation.Write(stream);
            Rotation.Write(stream);
            Scale.Write(stream);
            stream.Write(Pivot);
        }
    }
}
