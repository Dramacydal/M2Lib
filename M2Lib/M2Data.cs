using M2Lib.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using M2Lib.Elements.Chunks;

namespace M2Lib
{
    public class M2Data : Element
    {
        public List<Element> Chunks = new List<Element>();

        public override void Read(BinaryReader stream)
        {
            var chunkStart = 0;
            while (stream.BaseStream.Position != stream.BaseStream.Length)
            {
                stream.BaseStream.Seek(chunkStart, SeekOrigin.Begin);

                //afid sfid bfid
                var chunkMagic = string.Concat(stream.ReadBytes(4).Select(_ => (char)_));
                var chunkSize = stream.ReadInt32();
                chunkStart += chunkSize + 8;

                using (var reader = new BinaryReader(new MemoryStream(stream.ReadBytes(chunkSize))))
                {
                    var chunk = M2Chunk.CreateFromMagic(chunkMagic, chunkSize);
                    chunk.Read(reader);

                    Chunks.Add(chunk);
                }
            }
        }

        public override void Write(MyBinaryWriter stream)
        {
            throw new NotImplementedException();
        }

    }
}
