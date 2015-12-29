using M2Lib.Elements;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace M2Lib
{
    public static class Extensions
    {
        private static T ConvertToType<T>(object val) where T : new()
        {
            var h = GCHandle.Alloc(val, GCHandleType.Pinned);
            var t = (T)Marshal.PtrToStructure(h.AddrOfPinnedObject(), typeof(T));
            h.Free();

            return t;
        }

        public static T Read<T>(this BinaryReader reader) where T : new()
        {
            switch (typeof(T).Name)
            {
                case "Byte":
                    return (T)(object)reader.ReadByte();
                case "SByte":
                    return (T)(object)reader.ReadSByte();
                case "Int32":
                    return (T)(object)reader.ReadInt32();
                case "UInt32":
                    return (T)(object)reader.ReadUInt32();
                case "Int16":
                    return (T)(object)reader.ReadInt16();
                case "UInt16":
                    return (T)(object)reader.ReadUInt16();
                case "Double":
                    return (T)(object)reader.ReadDouble();
                case "Single":
                    return (T)(object)reader.ReadSingle();
                case "Int64":
                    return (T)(object)reader.ReadInt64();
                case "UInt64":
                    return (T)(object)reader.ReadUInt64();
                default:
                    break;
            }

            if (typeof(T).IsSubclassOf(typeof(Element)))
            {
                var val = new T();
                ((object)val as Element).Read(reader);
                return val;
            }

            var bytes = reader.ReadBytes(Marshal.SizeOf(typeof(T)));
            return ConvertToType<T>(bytes);
        }

        public static T[] Read<T>(this BinaryReader reader, int count) where T : new()
        {
            var ret = new List<T>();
            for (var i = 0; i < count; ++i)
                ret.Add(reader.Read<T>());

            return ret.ToArray();
        }

        public static void Write<T>(this MyBinaryWriter writer, T value) where T : new()
        {
            if (typeof(T).IsSubclassOf(typeof(Element)))
            {
                ((object)value as Element).Write(writer);
                return;
            }

            var size = Marshal.SizeOf(typeof(T));
            var bytes = new byte[size];
            var ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(value, ptr, true);
            Marshal.Copy(ptr, bytes, 0, size);
            Marshal.FreeHGlobal(ptr);

            writer.Write(bytes);
        }
    }
}
