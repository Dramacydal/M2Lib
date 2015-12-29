using System.IO;

namespace M2Lib.Elements
{
    public class Name : Element
    {
        public char NameLitera;

        public override void Read(BinaryReader stream)
        {
            NameLitera = stream.ReadChar();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(NameLitera);
        }
    }
}
