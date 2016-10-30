using System;
using Core.Diagnostics;
using MathKernel.Resources;

namespace MathKernel.LinearAlgebra
{
    public unsafe partial class BLAS
    {
        private static float dot(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            return NativeMethods.cblas_sdot(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride);
        }

        private static double dot(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y)
        {
            return NativeMethods.cblas_ddot(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride);
        }
    }

    [RealTypeDuplicate(typeof(float))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static float Dot(
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

            return dot(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        public static float Dot(Vector<float> x, Vector<float> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dot(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }
    }

    [RealTypeDuplicate(typeof(double))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static double Dot(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            return dot(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        public static double Dot(Vector<double> x, Vector<double> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (double* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dot(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }
    }
}
