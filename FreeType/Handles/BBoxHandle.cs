using System;
using System.Runtime.InteropServices;

namespace FreeType2.Handles
{
    internal class BBoxHandle : IDisposable
    {
        public BBoxHandle(GlyphHandle glyph, BBoxMode mode)
        {
            var handle = IntPtr.Zero;
            Natives.FT_Glyph_Get_CBox(glyph.Handle, mode, out handle);
            Handle = handle;
        }

        public IntPtr Handle { get; private set; }
        public bool IsInvalid => Handle == IntPtr.Zero;

        private void CloseHandle()
        {
            if (IsInvalid)
                return;

            Handle = IntPtr.Zero;
        }

        public void Dispose()
        {
            CloseHandle();
            GC.SuppressFinalize(this);
        }

        ~BBoxHandle()
        {
            CloseHandle();
        }
    }
}
