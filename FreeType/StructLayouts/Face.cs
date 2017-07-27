using System;
using System.Runtime.InteropServices;

namespace FreeType2.StructLayouts
{
    [StructLayout(LayoutKind.Sequential, Size = 248)]
    internal struct Face
    {
        long num_faces;
        long face_index;

        long face_flags;
        long style_flags;

        long num_glyphs;

        IntPtr family_name;
        IntPtr style_name;

        int num_charmaps;
        IntPtr charmaps;

        IntPtr generic_data;
        IntPtr generic_finalizer;

        long bbox_xMin, bbox_yMin;
        long bbox_xMax, bbox_yMax;

        ushort units_per_em;
        short ascender;
        short descender;
        short height;

        short max_advance_width;
        short max_advance_height;

        short underline_position;
        short underline_thickness;

        public IntPtr glyph_slot; /* hooray, the thing we actually want!!! */
        IntPtr size;
        IntPtr charmap;

        IntPtr driver;
        IntPtr memory;
        IntPtr stream;

        IntPtr list_head;
        IntPtr list_tail;

        IntPtr autohint_data;
        IntPtr autohint_finalizer;
        IntPtr extensions;

        IntPtr @internal;
    }
}
