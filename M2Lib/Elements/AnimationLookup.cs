using System.IO;

namespace M2Lib.Elements
{
    [Size(2)]
    public class AnimationLookup : Element
    {
        public short AnimationId;

        public override void Read(BinaryReader stream)
        {
            AnimationId = stream.ReadInt16();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(AnimationId);
        }
    }
}
