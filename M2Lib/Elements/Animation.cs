using M2Lib.Structures;
using System.IO;

namespace M2Lib.Elements
{
    [Size(0x40)]
    public class Animation : Element
    {
        // 0
        ushort AnimationID;
        // 2
        ushort SubAnimationId;
        // 4
        uint Length;
        // 8
        float MoveSpeed;
        // C
        uint Flags;
        // 10
        short Probability;
        // 12
        ushort Padding;
        // 14
        uint[] Unknown = new uint[2];
        // 1C
        uint BlendTime;
        // 20
        SVolume BoundVolume; // size 1C
        // 3C
        short NextAnimation;
        // 3E
        ushort AliasNext;

        public override void Read(BinaryReader stream)
        {
            AnimationID = stream.ReadUInt16();
            SubAnimationId = stream.ReadUInt16();
            Length = stream.ReadUInt32();
            MoveSpeed = stream.ReadSingle();
            Flags = stream.ReadUInt32();
            Probability = stream.ReadInt16();
            Padding = stream.ReadUInt16();
            Unknown = stream.Read<uint>(Unknown.Length);
            BlendTime = stream.ReadUInt32();
            BoundVolume = stream.Read<SVolume>();
            NextAnimation = stream.ReadInt16();
            AliasNext = stream.ReadUInt16();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(AnimationID);
            stream.Write(SubAnimationId);
            stream.Write(Length);
            stream.Write(MoveSpeed);
            stream.Write(Flags);
            stream.Write(Probability);
            stream.Write(Padding);
            for (var i = 0; i < Unknown.Length; ++i)
                stream.Write(Unknown[i]);
            stream.Write(BlendTime);
            stream.Write(BoundVolume);
            stream.Write(NextAnimation);
            stream.Write(AliasNext);
        }
    }
}
