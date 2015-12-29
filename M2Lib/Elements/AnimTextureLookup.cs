using System.IO;

namespace M2Lib.Elements
{
    [Size(2)]
    public class AnimTextureLookup : Element
    {
        public ushort AnimTextureId;

        public override void Read(BinaryReader stream)
        {
            AnimTextureId = stream.ReadUInt16();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(AnimTextureId);
        }
    }
}
