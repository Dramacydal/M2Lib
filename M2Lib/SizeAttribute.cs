using System;

namespace M2Lib.Elements
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class Size : Attribute
    {
        public int Bytes { get; private set; }
        public Size(int size)
        {
            Bytes = size;
        }
    }
}
