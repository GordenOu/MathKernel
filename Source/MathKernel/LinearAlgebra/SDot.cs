using System;
using Core.Diagnostics;
using MathKernel.Resources;

namespace MathKernel.LinearAlgebra
{
    public unsafe partial class BLAS
    {
        private static float sdot(
            float b,
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            return NativeMethods.cblas_sdsdot(
                xDescriptor.Size,
                b,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride);
        }

        /// <summary>
        /// (float)Sum(i => (double)x[i] * (double)y[i]) + b.
        /// </summary>
        [CLSCompliant(false)]
        public static float SDot(
            float b,
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            return sdot(b, xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// (float)Sum(i => (double)x[i] * (double)y[i]) + b.
        /// </summary>
        public static float SDot(float b, Vector<float> x, Vector<float> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                return sdot(b, x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }

        private static double sdot(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            return NativeMethods.cblas_dsdot(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride);
        }

        /// <summary>
        /// Sum(i => (double)x[i] * (double)y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static double SDot(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            return sdot(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => (double)x[i] * (double)y[i]).
        /// </summary>
        public static double SDot(Vector<float> x, Vector<float> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                return sdot(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }
    }
}
