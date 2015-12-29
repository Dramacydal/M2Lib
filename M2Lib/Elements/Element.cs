using System;
using System.IO;

namespace M2Lib.Elements
{
    public abstract class Element
    {
        public abstract void Read(BinaryReader stream);
        public abstract void Write(MyBinaryWriter stream);

        public virtual void BuildDataRefs() { }

        public virtual int GetSize() 
        {
            var attributes = GetType().GetCustomAttributes(typeof(Size), true);
            foreach (var attribute in attributes)
                return (attribute as Size).Bytes;

            throw new Exception("Size attibute not set to " + GetType());
        }
    }
}
