using System.IO;

namespace M2Lib.Elements
{
    [Size(0x14)]
    public class Track<T> : TrackBase where T : new()
    {
        public ArrayRef<T> Values = new ArrayRef<T>();

        public override void Read(BinaryReader stream)
        {
            base.Read(stream);
            Values.Read(stream);
        }

        public override void Write(MyBinaryWriter stream)
        {
            base.Write(stream);
            Values.Write(stream);
        }
    }
}
