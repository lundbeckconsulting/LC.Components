/*
    @Date			 : 28.11.2019
    @Author			 : Stein Lundbeck
*/

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace LundbeckConsulting
{
    public class DisposableBase : IDisposable
    {
        private IntPtr _handle;
        private bool _disposed = false;
        private readonly Component _component = new Component();

        public DisposableBase(IntPtr handle)
        {
            _handle = handle;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    _component.Dispose();
                }

                CloseHandle(_handle);
                _handle = IntPtr.Zero;
                _disposed = true;
            }
        }

        [DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        ~DisposableBase()
        {
            Dispose(false);
        }

        public bool Disposed => _disposed;
    }
}
