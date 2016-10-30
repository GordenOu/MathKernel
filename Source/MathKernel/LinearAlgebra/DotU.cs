using System;
using Core.Diagnostics;
using MathKernel.Resources;

namespace MathKernel.LinearAlgebra
{
    public unsafe partial class BLAS
    {
        private static complexf dotu(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            complexf result;
            NativeMethods.cblas_cdotu_sub(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride,
                &result);
            return result;
        }

        private static complex dotu(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            complex result;
            NativeMethods.cblas_zdotu_sub(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride,
                &result);
            return result;
        }
    }

    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static complexf Dot(
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

            return dotu(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        public static complexf Dot(Vector<complexf> x, Vector<complexf> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complexf* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dotu(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static complex Dot(
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

            return dotu(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        public static complex Dot(Vector<complex> x, Vector<complex> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complex* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dotu(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }
    }
}
