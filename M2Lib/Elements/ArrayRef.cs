using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace M2Lib.Elements
{
    public class WTF
    {
        public static int MaxOffs = 0;
    }
    [Size(8)]
    public class ArrayRef<T> : Element where T : new()
    {
        
        public override void Read(BinaryReader stream)
        {
            var Count = stream.ReadInt32();
            var Offset = stream.ReadInt32();
            if (Offset > WTF.MaxOffs)
                WTF.MaxOffs = Offset;

            if (Offset > 0)
            {
                var curPos = stream.BaseStream.Position;
                stream.BaseStream.Seek((long)Offset, SeekOrigin.Begin);
                Elements = stream.Read<T>(Count).ToList();
                stream.BaseStream.Seek((long)curPos, SeekOrigin.Begin);
            }
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.Write(Elements.Count);
            stream.Write(stream.DataStartOffset);

            if (Elements.Count > 0)
            {
                var currOffs = stream.BaseStream.Position;
                stream.Seek(stream.DataStartOffset, SeekOrigin.Begin);

                if (typeof(T).IsSubclassOf(typeof(Element)))
                {
                    var elementSize = (Elements[0] as Element).GetSize();
                    stream.DataStartOffset += elementSize * Elements.Count;
                }
                else
                    stream.DataStartOffset += Marshal.SizeOf(typeof(T)) * Elements.Count;

                foreach (var element in Elements)
                    stream.Write<T>(element);

                stream.Seek((int)currOffs, SeekOrigin.Begin);
            }
        }

        public List<T> Elements = new List<T>();
    }
}
