using System.Runtime.InteropServices;

namespace FreeType2.StructLayouts
{
    [StructLayout(LayoutKind.Sequential, Size = 32)]
    internal struct BBox
    {
        public ulong xMin;
        public ulong yMin;
        public ulong xMax;
        public ulong yMax;
    }
}
