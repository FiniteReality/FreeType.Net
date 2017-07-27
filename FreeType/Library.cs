using FreeType2.Handles;
using System;

namespace FreeType2
{
    public class Library : IDisposable
    {
        private readonly LibraryHandle _library;

        public Library()
        {
            _library = new LibraryHandle();
        }

        public void Dispose()
        {
            _library.Dispose();
        }

        public Glyph LoadGlyphFromChar(string font, long face_index, char character)
        {
            return new Glyph(_library, font, face_index, character, GlyphLoadFlags.Default | GlyphLoadFlags.Render);
        }
    }
}
