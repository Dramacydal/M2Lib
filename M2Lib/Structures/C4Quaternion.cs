using System.Runtime.InteropServices;

namespace M2Lib.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct C4Quaternion
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        public float[] Value;
    }
}
