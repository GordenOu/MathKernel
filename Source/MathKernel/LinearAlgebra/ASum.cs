using System;
using Core.Diagnostics;

namespace MathKernel.LinearAlgebra
{
    public unsafe partial class BLAS
    {
        private static float asum(VectorDescriptor descriptor, float* x)
        {
            return NativeMethods.cblas_sasum(descriptor.Size, x, descriptor.Stride);
        }

        private static float asum(VectorDescriptor descriptor, complexf* x)
        {
            return NativeMethods.cblas_scasum(descriptor.Size, x, descriptor.Stride);
        }

        private static double asum(VectorDescriptor descriptor, double* x)
        {
            return NativeMethods.cblas_dasum(descriptor.Size, x, descriptor.Stride);
        }

        private static double asum(VectorDescriptor descriptor, complex* x)
        {
            return NativeMethods.cblas_dzasum(descriptor.Size, x, descriptor.Stride);
        }
    }

    [RealTypeDuplicate(typeof(float))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// Sum(Abs(x)).
        /// </summary>
        [CLSCompliant(false)]
        public static float ASum(VectorDescriptor descriptor, float* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return asum(descriptor, x);
        }

        /// <summary>
        /// Sum(Abs(x)).
        /// </summary>
        public static float ASum(Vector<float> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (float* xPtr = x.Storage)
            {
                return asum(x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [RealTypeDuplicate(typeof(double))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// Sum(Abs(x)).
        /// </summary>
        [CLSCompliant(false)]
        public static double ASum(VectorDescriptor descriptor, double* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return asum(descriptor, x);
        }

        /// <summary>
        /// Sum(Abs(x)).
        /// </summary>
        public static double ASum(Vector<double> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (double* xPtr = x.Storage)
            {
                return asum(x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// Sum(i => Abs(x[i].Real) + Abs(x[i].Imaginary)).
        /// </summary>
        [CLSCompliant(false)]
        public static float ASum(VectorDescriptor descriptor, complexf* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return asum(descriptor, x);
        }

        /// <summary>
        /// Sum(i => Abs(x[i].Real) + Abs(x[i].Imaginary)).
        /// </summary>
        public static float ASum(Vector<complexf> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complexf* xPtr = x.Storage)
            {
                return asum(x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// Sum(i => Abs(x[i].Real) + Abs(x[i].Imaginary)).
        /// </summary>
        [CLSCompliant(false)]
        public static double ASum(VectorDescriptor descriptor, complex* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return asum(descriptor, x);
        }

        /// <summary>
        /// Sum(i => Abs(x[i].Real) + Abs(x[i].Imaginary)).
        /// </summary>
        public static double ASum(Vector<complex> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complex* xPtr = x.Storage)
            {
                return asum(x.Descriptor, xPtr + x.Offset);
            }
        }
    }
}
