using FreeType2.Handles;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FreeType2
{
    public class Glyph : IDisposable
    {
        private static uint UnicodeEncoding = (uint)'u' << 24 |
                                              (uint)'n' << 16 |
                                              (uint)'i' <<  8 |
                                                    'c';

        private readonly FaceHandle _face;
        private readonly GlyphHandle _glyph;

        internal unsafe Glyph(LibraryHandle library, string path, long index, char character, GlyphLoadFlags flags)
        {
            _face = new FaceHandle(library, path, index);

            var status = Natives.FT_Select_Charmap(_face.Handle, UnicodeEncoding);
            if (status != FTError.Success)
                throw new Exception($"FreeType returned an error: {status}");

            status = Natives.FT_Set_Char_Size(_face.Handle, 0, 16, 96, 96);
            if (status != FTError.Success)
                throw new Exception($"FreeType returned an error: {status}");

            status = Natives.FT_Load_Char(_face.Handle, character, flags);
            if (status != FTError.Success)
                throw new Exception($"FreeType returned an error: {status}");

            var face = Marshal.PtrToStructure<StructLayouts.Face>(_face.Handle);

            _glyph = new GlyphHandle(face.glyph_slot);
        }

        public void Dispose()
        {
            _glyph.Dispose();
            _face.Dispose();
        }

        public BBox GetControlBox(BBoxMode mode)
        {
            return new BBox(_glyph, mode);
        }
    }
}
