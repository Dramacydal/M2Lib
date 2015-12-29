using System.IO;

namespace M2Lib
{
    public class MyBinaryWriter : BinaryWriter
    {
        public int DataStartOffset { get; set; }

        public MyBinaryWriter(Stream stream, int DataOffset = 0)
            : base(stream)
        {
            DataStartOffset = DataOffset;
        }
    }
}
