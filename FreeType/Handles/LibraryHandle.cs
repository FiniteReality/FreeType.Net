using System;

namespace FreeType2.Handles
{
    internal class LibraryHandle : IDisposable
    {
        public LibraryHandle()
        {
            var handle = IntPtr.Zero;

            var status = Natives.FT_Init_FreeType(ref handle);
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

            Natives.FT_Done_FreeType(Handle);
            Handle = IntPtr.Zero;
        }

        public void Dispose()
        {
            CloseHandle();
            GC.SuppressFinalize(this);
        }

        ~LibraryHandle()
        {
            CloseHandle();
        }
    }
}
