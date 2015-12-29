using System.Runtime.InteropServices;

namespace M2Lib.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CompQuat
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U2)]
        public ushort[] Value;
    }
}
