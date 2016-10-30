using System;
using Core.Diagnostics;
using MathKernel.Resources;

namespace MathKernel.LinearAlgebra
{
    public unsafe partial class BLAS
    {
        private static void rot(
               VectorDescriptor xDescriptor, float* x,
               VectorDescriptor yDescriptor, float* y,
               float c, float s)
        {
            NativeMethods.cblas_srot(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride,
                c, s);
        }

        private static void rot(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y,
            double c, double s)
        {
            NativeMethods.cblas_drot(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride,
                c, s);
        }

        private static void rot(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y,
            float c, float s)
        {
            NativeMethods.cblas_csrot(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride,
                c, s);
        }

        private static void rot(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y,
            double c, double s)
        {
            NativeMethods.cblas_zdrot(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride,
                c, s);
        }
    }

    [RealTypeDuplicate(typeof(float))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        [CLSCompliant(false)]
        public static void Rotate(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y,
            float c, float s)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            rot(xDescriptor, x, yDescriptor, y, c, s);
        }

        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        public static void Rotate(Vector<float> x, Vector<float> y, float c, float s)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                rot(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset, c, s);
            }
        }
    }

    [RealTypeDuplicate(typeof(double))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        [CLSCompliant(false)]
        public static void Rotate(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y,
            double c, double s)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            rot(xDescriptor, x, yDescriptor, y, c, s);
        }

        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        public static void Rotate(Vector<double> x, Vector<double> y, double c, double s)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (double* xPtr = x.Storage, yPtr = y.Storage)
            {
                rot(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset, c, s);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        [CLSCompliant(false)]
        public static void Rotate(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y,
            float c, float s)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            rot(xDescriptor, x, yDescriptor, y, c, s);
        }

        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        public static void Rotate(Vector<complexf> x, Vector<complexf> y, float c, float s)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complexf* xPtr = x.Storage, yPtr = y.Storage)
            {
                rot(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset, c, s);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        [CLSCompliant(false)]
        public static void Rotate(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y,
            double c, double s)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            rot(xDescriptor, x, yDescriptor, y, c, s);
        }

        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        public static void Rotate(Vector<complex> x, Vector<complex> y, double c, double s)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complex* xPtr = x.Storage, yPtr = y.Storage)
            {
                rot(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset, c, s);
            }
        }
    }
}
