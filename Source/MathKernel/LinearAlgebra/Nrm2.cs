using System;
using Core.Diagnostics;

namespace MathKernel.LinearAlgebra
{
    public unsafe partial class BLAS
    {
        private static float nrm2(VectorDescriptor descriptor, float* x)
        {
            return NativeMethods.cblas_snrm2(descriptor.Size, x, descriptor.Stride);
        }

        private static double nrm2(VectorDescriptor descriptor, double* x)
        {
            return NativeMethods.cblas_dnrm2(descriptor.Size, x, descriptor.Stride);
        }

        private static float nrm2(VectorDescriptor descriptor, complexf* x)
        {
            return NativeMethods.cblas_scnrm2(descriptor.Size, x, descriptor.Stride);
        }

        private static double nrm2(VectorDescriptor descriptor, complex* x)
        {
            return NativeMethods.cblas_dznrm2(descriptor.Size, x, descriptor.Stride);
        }
    }

    [RealTypeDuplicate(typeof(float))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// Sqrt(Sum(i => x[i] * x[i])).
        /// </summary>
        [CLSCompliant(false)]
        public static float Norm2(VectorDescriptor descriptor, float* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return nrm2(descriptor, x);
        }

        /// <summary>
        /// Sqrt(Sum(i => x[i] * x[i])).
        /// </summary>
        public static float Norm2(Vector<float> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (float* xPtr = x.Storage)
            {
                return nrm2(x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [RealTypeDuplicate(typeof(double))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// Sqrt(Sum(i => x[i] * x[i])).
        /// </summary>
        [CLSCompliant(false)]
        public static double Norm2(VectorDescriptor descriptor, double* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return nrm2(descriptor, x);
        }

        /// <summary>
        /// Sqrt(Sum(i => x[i] * x[i])).
        /// </summary>
        public static double Norm2(Vector<double> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (double* xPtr = x.Storage)
            {
                return nrm2(x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// Sqrt(Sum(i => Conjugate(x[i]) * x[i])).
        /// </summary>
        [CLSCompliant(false)]
        public static float Norm2(VectorDescriptor descriptor, complexf* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return nrm2(descriptor, x);
        }

        /// <summary>
        /// Sqrt(Sum(i => Conjugate(x[i]) * x[i])).
        /// </summary>
        public static float Norm2(Vector<complexf> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complexf* xPtr = x.Storage)
            {
                return nrm2(x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// Sqrt(Sum(i => Conjugate(x[i]) * x[i])).
        /// </summary>
        [CLSCompliant(false)]
        public static double Norm2(VectorDescriptor descriptor, complex* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return nrm2(descriptor, x);
        }

        /// <summary>
        /// Sqrt(Sum(i => Conjugate(x[i]) * x[i])).
        /// </summary>
        public static double Norm2(Vector<complex> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complex* xPtr = x.Storage)
            {
                return nrm2(x.Descriptor, xPtr + x.Offset);
            }
        }
    }
}
