using System.IO;

namespace M2Lib.Elements
{
    [Size(16)]
    public class Texture : Element
    {
        // 0
        public uint Type;
        // 4
        public uint Flags;
        // C
        public ArrayRef<char> FileName = new ArrayRef<char>();

        public override void Read(BinaryReader stream)
        {
            Type = stream.ReadUInt32();
            Flags = stream.ReadUInt32();
            FileName.Read(stream);
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Type);
            stream.Write(Flags);
            FileName.Write(stream);
        }
    }
}
