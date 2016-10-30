using System;
using Core.Diagnostics;
using MathKernel.Resources;

namespace MathKernel.LinearAlgebra
{
    public unsafe partial class BLAS
    {
        private static void rotm(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y,
            float h11, float h12, float h21, float h22)
        {
            var h = stackalloc float[5];
            h[1] = h11;
            h[2] = h21;
            h[3] = h12;
            h[4] = h22;
            if (h11 == 1 && h22 == 1)
            {
                if (h12 == 0 && h21 == 0)
                {
                    h[0] = -2;
                }
                else
                {
                    h[0] = 0;
                }
            }
            else if (h12 == 1 && h21 == -1)
            {
                h[0] = 1;
            }
            else
            {
                h[0] = -1;
            }

            NativeMethods.cblas_srotm(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride,
                h);
        }

        private static void rotm(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y,
            double h11, double h12, double h21, double h22)
        {
            var h = stackalloc double[5];
            h[1] = h11;
            h[2] = h21;
            h[3] = h12;
            h[4] = h22;
            if (h11 == 1 && h22 == 1)
            {
                if (h12 == 0 && h21 == 0)
                {
                    h[0] = -2;
                }
                else
                {
                    h[0] = 0;
                }
            }
            else if (h12 == 1 && h21 == -1)
            {
                h[0] = 1;
            }
            else
            {
                h[0] = -1;
            }

            NativeMethods.cblas_drotm(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride,
                h);
        }
    }

    [RealTypeDuplicate(typeof(float))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// (x, y) = ((h11 * x + h12 * y), (h21 * x + h22 * y)).
        /// </summary>
        [CLSCompliant(false)]
        public static void Rotate(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y,
            float h11, float h12, float h21, float h22)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            rotm(xDescriptor, x, yDescriptor, y, h11, h12, h21, h22);
        }

        /// <summary>
        /// (x, y) = ((h11 * x + h12 * y), (h21 * x + h22 * y)).
        /// </summary>
        public static void Rotate(
            Vector<float> x, Vector<float> y,
            float h11, float h12, float h21, float h22)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                rotm(
                    x.Descriptor, xPtr + x.Offset,
                    y.Descriptor, yPtr + y.Offset,
                    h11, h12, h21, h22);
            }
        }
    }

    [RealTypeDuplicate(typeof(double))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// (x, y) = ((h11 * x + h12 * y), (h21 * x + h22 * y)).
        /// </summary>
        [CLSCompliant(false)]
        public static void Rotate(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y,
            double h11, double h12, double h21, double h22)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            rotm(xDescriptor, x, yDescriptor, y, h11, h12, h21, h22);
        }

        /// <summary>
        /// (x, y) = ((h11 * x + h12 * y), (h21 * x + h22 * y)).
        /// </summary>
        public static void Rotate(
            Vector<double> x, Vector<double> y,
            double h11, double h12, double h21, double h22)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (double* xPtr = x.Storage, yPtr = y.Storage)
            {
                rotm(
                    x.Descriptor, xPtr + x.Offset,
                    y.Descriptor, yPtr + y.Offset,
                    h11, h12, h21, h22);
            }
        }
    }
}
