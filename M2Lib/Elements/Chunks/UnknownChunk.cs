using System;
using System.IO;

namespace M2Lib.Elements.Chunks
{
    public class UnknownChunk : M2Chunk
    {
        public UnknownChunk(string ChunkMagic, int Size) : base(Size)
        {
            this.ChunkMagic = ChunkMagic;
        }

        protected string ChunkMagic;
        public byte[] RawData { get; private set; }

        public override string GetChunkMagic()
        {
            return ChunkMagic;
        }

        public override void Read(BinaryReader stream)
        {
            RawData = stream.ReadBytes(Size);
        }

        public override void Write(MyBinaryWriter stream)
        {
            throw new NotImplementedException();
        }
    }
}
