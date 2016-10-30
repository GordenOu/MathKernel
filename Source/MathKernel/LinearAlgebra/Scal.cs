using System;
using Core.Diagnostics;

namespace MathKernel.LinearAlgebra
{
    public unsafe partial class BLAS
    {
        private static void scal(float a, VectorDescriptor descriptor, float* x)
        {
            NativeMethods.cblas_sscal(descriptor.Size, a, x, descriptor.Stride);
        }

        private static void scal(double a, VectorDescriptor descriptor, double* x)
        {
            NativeMethods.cblas_dscal(descriptor.Size, a, x, descriptor.Stride);
        }

        private static void scal(complexf a, VectorDescriptor descriptor, complexf* x)
        {
            NativeMethods.cblas_cscal(descriptor.Size, &a, x, descriptor.Stride);
        }

        private static void scal(complex a, VectorDescriptor descriptor, complex* x)
        {
            NativeMethods.cblas_zscal(descriptor.Size, &a, x, descriptor.Stride);
        }

        private static void scal(float a, VectorDescriptor descriptor, complexf* x)
        {
            NativeMethods.cblas_csscal(descriptor.Size, a, x, descriptor.Stride);
        }

        private static void scal(double a, VectorDescriptor descriptor, complex* x)
        {
            NativeMethods.cblas_zdscal(descriptor.Size, a, x, descriptor.Stride);
        }
    }

    [Duplicate(typeof(float))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x = a * x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Scale(float a, VectorDescriptor descriptor, float* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            scal(a, descriptor, x);
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        public static void Scale(float a, Vector<float> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (float* xPtr = x.Storage)
            {
                scal(a, x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [Duplicate(typeof(double))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x = a * x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Scale(double a, VectorDescriptor descriptor, double* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            scal(a, descriptor, x);
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        public static void Scale(double a, Vector<double> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (double* xPtr = x.Storage)
            {
                scal(a, x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [Duplicate(typeof(complexf))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x = a * x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Scale(complexf a, VectorDescriptor descriptor, complexf* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            scal(a, descriptor, x);
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        public static void Scale(complexf a, Vector<complexf> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complexf* xPtr = x.Storage)
            {
                scal(a, x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [Duplicate(typeof(complex))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x = a * x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Scale(complex a, VectorDescriptor descriptor, complex* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            scal(a, descriptor, x);
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        public static void Scale(complex a, Vector<complex> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complex* xPtr = x.Storage)
            {
                scal(a, x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x = a * x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Scale(float a, VectorDescriptor descriptor, complexf* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            scal(a, descriptor, x);
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        public static void Scale(float a, Vector<complexf> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complexf* xPtr = x.Storage)
            {
                scal(a, x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// x = a * x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Scale(double a, VectorDescriptor descriptor, complex* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            scal(a, descriptor, x);
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        public static void Scale(double a, Vector<complex> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complex* xPtr = x.Storage)
            {
                scal(a, x.Descriptor, xPtr + x.Offset);
            }
        }
    }
}
