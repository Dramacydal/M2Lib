using System.Runtime.InteropServices;

namespace M2Lib.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CRange
    {
        public float Min;
        public float Max;
    }
}
