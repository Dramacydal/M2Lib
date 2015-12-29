using System.IO;

namespace M2Lib.Elements
{
    [Size(0xF)]
    public class FakeAnimationBlock<T> : Element where T : struct
    {
        public ArrayRef<uint> TimeStamps = new ArrayRef<uint>();
        public ArrayRef<T> Values = new ArrayRef<T>();

        public override void Read(BinaryReader stream)
        {
            TimeStamps.Read(stream);
            Values.Read(stream);
        }

        public override void Write(MyBinaryWriter stream)
        {
            TimeStamps.Write(stream);
            Values.Write(stream);
        }
    }
}
