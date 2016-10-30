using System;
using Core.Diagnostics;
using MathKernel.Resources;

namespace MathKernel.LinearAlgebra
{
    public unsafe partial class BLAS
    {
        private static void axpy(
            float a,
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            NativeMethods.cblas_saxpy(
                xDescriptor.Size,
                a,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride);
        }

        private static void axpy(
            double a,
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y)
        {
            NativeMethods.cblas_daxpy(
                xDescriptor.Size,
                a,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride);
        }

        private static void axpy(
            complexf a,
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            NativeMethods.cblas_caxpy(
                xDescriptor.Size,
                &a,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride);
        }

        private static void axpy(
            complex a,
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            NativeMethods.cblas_zaxpy(
                xDescriptor.Size,
                &a,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride);
        }
    }

    [Duplicate(typeof(float))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// y = a * x + y.
        /// </summary>
        [CLSCompliant(false)]
        public static void AXPY(
            float a,
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

            axpy(a, xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = a * x + y.
        /// </summary>
        public static void AXPY(float a, Vector<float> x, Vector<float> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                axpy(a, x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }
    }

    [Duplicate(typeof(double))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// y = a * x + y.
        /// </summary>
        [CLSCompliant(false)]
        public static void AXPY(
            double a,
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

            axpy(a, xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = a * x + y.
        /// </summary>
        public static void AXPY(double a, Vector<double> x, Vector<double> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (double* xPtr = x.Storage, yPtr = y.Storage)
            {
                axpy(a, x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }
    }

    [Duplicate(typeof(complexf))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// y = a * x + y.
        /// </summary>
        [CLSCompliant(false)]
        public static void AXPY(
            complexf a,
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

            axpy(a, xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = a * x + y.
        /// </summary>
        public static void AXPY(complexf a, Vector<complexf> x, Vector<complexf> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complexf* xPtr = x.Storage, yPtr = y.Storage)
            {
                axpy(a, x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }
    }

    [Duplicate(typeof(complex))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// y = a * x + y.
        /// </summary>
        [CLSCompliant(false)]
        public static void AXPY(
            complex a,
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

            axpy(a, xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = a * x + y.
        /// </summary>
        public static void AXPY(complex a, Vector<complex> x, Vector<complex> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complex* xPtr = x.Storage, yPtr = y.Storage)
            {
                axpy(a, x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }
    }
}
