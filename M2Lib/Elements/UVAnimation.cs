using M2Lib.Structures;
using System.IO;

namespace M2Lib.Elements
{
    [Size(0x3C)]
    public class UVAnimation : Element
    {
        public Track<C3Vector> Translation = new Track<C3Vector>();
        public Track<C4Quaternion> Rotation = new Track<C4Quaternion>();
        public Track<C3Vector> Scaling = new Track<C3Vector>();

        public override void Read(BinaryReader stream)
        {
            Translation.Read(stream);
            Rotation.Read(stream);
            Scaling.Read(stream);
        }

        public override void Write(MyBinaryWriter stream)
        {
            Translation.Write(stream);
            Rotation.Write(stream);
            Scaling.Write(stream);
        }
    }
}
