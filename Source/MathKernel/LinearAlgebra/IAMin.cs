using System;
using Core.Diagnostics;

namespace MathKernel.LinearAlgebra
{
    public unsafe partial class BLAS
    {
        private static int iamin(VectorDescriptor descriptor, float* x)
        {
            return (int)NativeMethods.cblas_isamin(descriptor.Size, x, descriptor.Stride);
        }

        private static int iamin(VectorDescriptor descriptor, double* x)
        {
            return (int)NativeMethods.cblas_idamin(descriptor.Size, x, descriptor.Stride);
        }

        private static int iamin(VectorDescriptor descriptor, complexf* x)
        {
            return (int)NativeMethods.cblas_icamin(descriptor.Size, x, descriptor.Stride);
        }

        private static int iamin(VectorDescriptor descriptor, complex* x)
        {
            return (int)NativeMethods.cblas_izamin(descriptor.Size, x, descriptor.Stride);
        }
    }

    [RealTypeDuplicate(typeof(float))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x.IndexOf(Min(Abs(x))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMin(VectorDescriptor descriptor, float* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamin(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Min(Abs(x))).
        /// </summary>
        public static int IAMin(Vector<float> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (float* xPtr = x.Storage)
            {
                return iamin(x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [RealTypeDuplicate(typeof(double))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x.IndexOf(Min(Abs(x))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMin(VectorDescriptor descriptor, double* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamin(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Min(Abs(x))).
        /// </summary>
        public static int IAMin(Vector<double> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (double* xPtr = x.Storage)
            {
                return iamin(x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x.IndexOf(Min(i => Abs(x[i].Real) + Abs(x[i].Imaginary))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMin(VectorDescriptor descriptor, complexf* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamin(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Min(i => Abs(x[i].Real) + Abs(x[i].Imaginary))).
        /// </summary>
        public static int IAMin(Vector<complexf> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complexf* xPtr = x.Storage)
            {
                return iamin(x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x.IndexOf(Min(i => Abs(x[i].Real) + Abs(x[i].Imaginary))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMin(VectorDescriptor descriptor, complex* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamin(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Min(i => Abs(x[i].Real) + Abs(x[i].Imaginary))).
        /// </summary>
        public static int IAMin(Vector<complex> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complex* xPtr = x.Storage)
            {
                return iamin(x.Descriptor, xPtr + x.Offset);
            }
        }
    }
}
