using FreeType2.Handles;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FreeType2
{
    public class BBox : IDisposable
    {
        private readonly BBoxHandle _handle;

        internal unsafe BBox(GlyphHandle glyph, BBoxMode mode)
        {
            _handle = new BBoxHandle(glyph, mode);

            var bbox = Marshal.PtrToStructure<StructLayouts.BBox>(_handle.Handle);

            /*ulong* ptr = (ulong*)_handle.Handle.ToPointer();

            ulong xMin = ptr[0];
            ulong yMin = ptr[1];
            ulong xMax = ptr[2];
            ulong yMax = ptr[3];

            Bounds = new Rectangle(
                new Point((int)xMin, (int)yMin),
                new Size((int)(xMax - xMin), (int)(yMax - yMax)));*/
        }

        public Rectangle Bounds { get; }

        public void Dispose()
        {
            _handle.Dispose();
        }
    }
}
