using System.IO;

namespace M2Lib.Elements
{
    [Size(2)]
    public class CameraLookup : Element
    {
        public ushort Camera;

        public override void Read(BinaryReader stream)
        {
            Camera = stream.ReadUInt16();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Camera);
        }
    }
}
