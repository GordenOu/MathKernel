using System;
using Core.Diagnostics;
using MathKernel.Resources;

namespace MathKernel.LinearAlgebra
{
    public unsafe partial class BLAS
    {
        private static void copy(
           VectorDescriptor xDescriptor, float* x,
           VectorDescriptor yDescriptor, float* y)
        {
            NativeMethods.cblas_scopy(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride);
        }

        private static void copy(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y)
        {
            NativeMethods.cblas_dcopy(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride);
        }

        private static void copy(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            NativeMethods.cblas_ccopy(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride);
        }

        private static void copy(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            NativeMethods.cblas_zcopy(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride);
        }
    }

    [Duplicate(typeof(float))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// y = x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Copy(
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

            copy(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = x.
        /// </summary>
        public static void Copy(Vector<float> x, Vector<float> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                copy(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }
    }

    [Duplicate(typeof(double))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// y = x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Copy(
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

            copy(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = x.
        /// </summary>
        public static void Copy(Vector<double> x, Vector<double> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (double* xPtr = x.Storage, yPtr = y.Storage)
            {
                copy(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }
    }

    [Duplicate(typeof(complexf))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// y = x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Copy(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            copy(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = x.
        /// </summary>
        public static void Copy(Vector<complexf> x, Vector<complexf> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complexf* xPtr = x.Storage, yPtr = y.Storage)
            {
                copy(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }
    }

    [Duplicate(typeof(complex))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// y = x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Copy(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            copy(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = x.
        /// </summary>
        public static void Copy(Vector<complex> x, Vector<complex> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complex* xPtr = x.Storage, yPtr = y.Storage)
            {
                copy(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }
    }
}
