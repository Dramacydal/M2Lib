using System.IO;

namespace M2Lib.Elements
{
    [Size(2)]
    public class AttachmentLookup : Element
    {
        public short Attachment;

        public override void Read(BinaryReader stream)
        {
            Attachment = stream.ReadInt16();
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Attachment);
        }
    }
}
