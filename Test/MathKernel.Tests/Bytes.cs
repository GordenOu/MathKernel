using System;
using System.Runtime.InteropServices;

namespace MathKernel.Tests
{
    public sealed unsafe class Bytes : IDisposable
    {
        public IntPtr Ptr { get; }

        public Bytes(int size)
        {
            Ptr = Marshal.AllocHGlobal(size);
            for (int i = 0; i < size; i++)
            {
                Marshal.WriteByte(Ptr, i, 0);
            }
        }

        private bool disposed;

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;

                Marshal.FreeHGlobal(Ptr);
            }
            GC.SuppressFinalize(this);
        }

        ~Bytes()
        {
            Dispose();
        }

        public static explicit operator float* (Bytes bytes)
        {
            return (float*)bytes.Ptr.ToPointer();
        }

        public static explicit operator double* (Bytes bytes)
        {
            return (double*)bytes.Ptr.ToPointer();
        }

        public static explicit operator complexf* (Bytes bytes)
        {
            return (complexf*)bytes.Ptr.ToPointer();
        }

        public static explicit operator complex* (Bytes bytes)
        {
            return (complex*)bytes.Ptr.ToPointer();
        }
    }
}
