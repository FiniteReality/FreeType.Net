using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FreeType2.Handles
{
    internal class GlyphHandle
    {
        public GlyphHandle(IntPtr glyphSlot)
        {
            var handle = IntPtr.Zero;
            var status = Natives.FT_Get_Glyph(glyphSlot, ref handle);
            if (status != FTError.Success)
                throw new Exception($"FreeType returned an error: {status}");

            Handle = handle;
        }

        public IntPtr Handle { get; private set; }
        public bool IsInvalid => Handle == IntPtr.Zero;

        private void CloseHandle()
        {
            if (IsInvalid)
                return;

            Natives.FT_Done_Glyph(Handle);
            Handle = IntPtr.Zero;
        }

        public void Dispose()
        {
            CloseHandle();
            GC.SuppressFinalize(this);
        }

        ~GlyphHandle()
        {
            CloseHandle();
        }
    }
}
