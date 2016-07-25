using M2Lib;
using M2Lib.Elements;
using System;
using System.IO;

namespace Test
{
    class Program
    {
        public struct E
        {
            public int F;
            public int G;
        }

        [Size(4+4+8)]
        public class B : Element
        {
            public int C;
            public int D;
            public ArrayRef<E> E = new ArrayRef<E>();

            public override void Read(BinaryReader stream)
            {
                C = stream.ReadInt32();
                D = stream.ReadInt32();
                E.Read(stream);
            }

            public override void Write(MyBinaryWriter stream)
            {
                //stream.DataStartOffset += 16;
                stream.Write(C);
                stream.Write(D);
                E.Write(stream);
            }
        }

        public class TestStruct : Element
        {
            public uint A;
            public ArrayRef<B> B = new ArrayRef<B>();

            public override void Read(BinaryReader stream)
            {
                A = stream.ReadUInt32();
                B.Read(stream);
            }

            public override void Write(MyBinaryWriter stream)
            {
                stream.DataStartOffset += 12;
                stream.Write(A);
                B.Write(stream);
            }
        }

        static void Main(string[] args)
        {
            {
                var model = new M2();
                model.Load(File.OpenRead(@"E:\m2work\legion\Character\Tauren\Male\TaurenMale_HD.M2"));


                return;
            }

            return;
            {
                var stream = new MemoryStream();
                var e = new E();
                e.F = 1; e.G = 2;
                var e2 = new E();
                e2.F = 3; e2.G = 4;

                var b = new B();
                b.C = 5; b.D = 6; b.E.Elements.Add(e);

                var b2 = new B();
                b2.C = 7; b2.D = 8; b2.E.Elements.Add(e2);

                var t = new TestStruct();
                t.A = 9;
                t.B.Elements.Add(b);
                t.B.Elements.Add(b2);

                var writer = new MyBinaryWriter(stream);
                t.Write(writer);

                stream.Seek(0, SeekOrigin.Begin);

                var reader = new BinaryReader(stream);
                var t2 = new TestStruct();
                t2.Read(reader);

                return;
            }
            {
                var model = new M2();
                model.Load(File.OpenRead(@"E:\m2work\new\PandarenYetiMount\PandarenYetiMount.m2"));
            }
        }
    }
}
