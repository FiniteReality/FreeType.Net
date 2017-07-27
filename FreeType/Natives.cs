using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FreeType2
{
    internal class Natives
    {
        [DllImport("freetype6")]
        public static extern FTError FT_Init_FreeType(ref IntPtr libraryRef);
        [DllImport("freetype6")]
        public static extern FTError FT_Done_FreeType(IntPtr library);
        [DllImport("freetype6")]
        public static extern FTError FT_New_Face(IntPtr library, StringBuilder path, long index, ref IntPtr face);
        [DllImport("freetype6")]
        public static extern FTError FT_Select_Charmap(IntPtr face, uint encoding);
        [DllImport("freetype6")]
        public static extern FTError FT_Set_Char_Size(IntPtr face, long width, long height, uint horiz_resolution, uint vert_resolution);
        [DllImport("freetype6")]
        public static extern FTError FT_Get_Glyph(IntPtr slot, ref IntPtr glyph);
        [DllImport("freetype6")]
        public static extern void FT_Done_Glyph(IntPtr glyph);
        [DllImport("freetype6")]
        public static extern FTError FT_Done_Face(IntPtr face);
        [DllImport("freetype6")]
        public static extern FTError FT_Load_Char(IntPtr face, ulong character, GlyphLoadFlags flags);

        [DllImport("freetype6")]
        public static extern void FT_Glyph_Get_CBox(IntPtr glyph, BBoxMode mode, out IntPtr acbox);
    }
}
