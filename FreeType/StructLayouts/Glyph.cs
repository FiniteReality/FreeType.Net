using System;
using System.Runtime.InteropServices;

namespace FreeType2.StructLayouts
{
    [StructLayout(LayoutKind.Sequential, Size = 40)]
    internal struct Glyph
    {
        IntPtr library;
        IntPtr clazz;
        uint format;
        IntPtr pos_x;
        IntPtr pos_y;
    }
}
