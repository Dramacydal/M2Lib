using System;
using System.IO;

namespace M2Lib
{
    public class M2
    {
        protected M2Data Data;

        public M2()
        {
        }

        public void Load(Stream stream)
        {
            Data = new M2Data();
            using (var reader = new BinaryReader(stream))
                Data.Read(reader);
        }

        public void Save(Stream stream)
        {
            using (var writer = new MyBinaryWriter(stream, Data.GetSize()))
            {
                Data.Write(writer);
                Console.WriteLine(writer.DataStartOffset);
            }
        }
    }
}
