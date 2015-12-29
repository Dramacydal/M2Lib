using System.Runtime.InteropServices;

namespace M2Lib.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SVolume
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U4)]
        float[] Min;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U4)]
        float[] Max;
        float Radius;
    }
}
