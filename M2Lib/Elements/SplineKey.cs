using System.IO;

namespace M2Lib.Elements
{
    [Size(12)]
    public class SplineKey<T> : Element where T : new()
    {
        public T[] Values = new T[3];

        public override void Read(BinaryReader stream)
        {
            Values = stream.Read<T>(Values.Length);
        }

        public override void Write(MyBinaryWriter stream)
        {
            for (var i = 0; i < Values.Length; ++i)
                stream.Write<T>(Values[i]);
        }
    }
}
