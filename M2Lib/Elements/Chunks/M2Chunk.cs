namespace M2Lib.Elements.Chunks
{
    public abstract class M2Chunk : Element
    {
        public readonly int Size;

        protected M2Chunk(int Size)
        {
            this.Size = Size;
        }

        public static M2Chunk CreateFromMagic(string ChunkMagic, int Size)
        {
            switch (ChunkMagic)
            {
                case "MD21":
                    return new MD21Chunk(Size);
                case "AFID":
                    break;
                case "SFID":
                    break;
                case "BFID":
                    break;
            }

            return new UnknownChunk(ChunkMagic, Size);
        }

        public abstract string GetChunkMagic();
    }
}
