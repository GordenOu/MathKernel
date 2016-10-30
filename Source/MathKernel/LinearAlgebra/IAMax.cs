using System;
using Core.Diagnostics;

namespace MathKernel.LinearAlgebra
{
    public unsafe partial class BLAS
    {
        private static int iamax(VectorDescriptor descriptor, float* x)
        {
            return (int)NativeMethods.cblas_isamax(descriptor.Size, x, descriptor.Stride);
        }

        private static int iamax(VectorDescriptor descriptor, double* x)
        {
            return (int)NativeMethods.cblas_idamax(descriptor.Size, x, descriptor.Stride);
        }

        private static int iamax(VectorDescriptor descriptor, complexf* x)
        {
            return (int)NativeMethods.cblas_icamax(descriptor.Size, x, descriptor.Stride);
        }

        private static int iamax(VectorDescriptor descriptor, complex* x)
        {
            return (int)NativeMethods.cblas_izamax(descriptor.Size, x, descriptor.Stride);
        }
    }

    [RealTypeDuplicate(typeof(float))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x.IndexOf(Max(Abs(x))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMax(VectorDescriptor descriptor, float* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamax(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Max(Abs(x))).
        /// </summary>
        public static int IAMax(Vector<float> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (float* xPtr = x.Storage)
            {
                return iamax(x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [RealTypeDuplicate(typeof(double))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x.IndexOf(Max(Abs(x))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMax(VectorDescriptor descriptor, double* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamax(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Max(Abs(x))).
        /// </summary>
        public static int IAMax(Vector<double> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (double* xPtr = x.Storage)
            {
                return iamax(x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x.IndexOf(Max(i => Abs(x[i].Real) + Abs(x[i].Imaginary))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMax(VectorDescriptor descriptor, complexf* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamax(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Max(i => Abs(x[i].Real) + Abs(x[i].Imaginary))).
        /// </summary>
        public static int IAMax(Vector<complexf> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complexf* xPtr = x.Storage)
            {
                return iamax(x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x.IndexOf(Max(i => Abs(x[i].Real) + Abs(x[i].Imaginary))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMax(VectorDescriptor descriptor, complex* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamax(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Max(i => Abs(x[i].Real) + Abs(x[i].Imaginary))).
        /// </summary>
        public static int IAMax(Vector<complex> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complex* xPtr = x.Storage)
            {
                return iamax(x.Descriptor, xPtr + x.Offset);
            }
        }
    }
}
