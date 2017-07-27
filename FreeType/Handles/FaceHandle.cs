using System;
using System.Collections.Generic;
using System.Text;

namespace FreeType2.Handles
{
    internal class FaceHandle : IDisposable
    {
        public FaceHandle(LibraryHandle library, string path, long index)
        {
            if (library.IsInvalid)
                throw new ArgumentException($"{nameof(library)} must be valid");
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException($"{nameof(path)} must be set to a valid path");

            var handle = IntPtr.Zero;

            var status = Natives.FT_New_Face(library.Handle, new StringBuilder(path), index, ref handle);
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

            Natives.FT_Done_Face(Handle);
            Handle = IntPtr.Zero;
        }

        public void Dispose()
        {
            CloseHandle();
            GC.SuppressFinalize(this);
        }

        ~FaceHandle()
        {
            CloseHandle();
        }
    }
}
