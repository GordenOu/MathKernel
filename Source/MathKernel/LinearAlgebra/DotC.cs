using System;
using Core.Diagnostics;
using MathKernel.Resources;

namespace MathKernel.LinearAlgebra
{
    public unsafe partial class BLAS
    {
        private static complexf dotc(
            ConjugatedVectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            complexf result;
            NativeMethods.cblas_cdotc_sub(
                xDescriptor.Size,
                x, xDescriptor.Stride,
                y, yDescriptor.Stride,
                &result);
            return result;
        }

        private static complex dotc(
            ConjugatedVectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            complex result;
            NativeMethods.cblas_zdotc_sub(
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
        /// Sum(i => Conjugate(x[i]) * y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static complexf Dot(
            ConjugatedVectorDescriptor xDescriptor, complexf* x,
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

            return dotc(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => Conjugate(x[i]) * y[i]).
        /// </summary>
        public static complexf Dot(ConjugatedVector<complexf> x, Vector<complexf> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complexf* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dotc(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }

        /// <summary>
        /// Sum(i => x[i] * Conjugate(y[i])).
        /// </summary>
        [CLSCompliant(false)]
        public static complexf Dot(
            VectorDescriptor xDescriptor, complexf* x,
            ConjugatedVectorDescriptor yDescriptor, complexf* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            return dotc(yDescriptor, y, xDescriptor, x);
        }

        /// <summary>
        /// Sum(i => x[i] * Conjugate(y[i])).
        /// </summary>
        public static complexf Dot(Vector<complexf> x, ConjugatedVector<complexf> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complexf* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dotc(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class BLAS
    {
        /// <summary>
        /// Sum(i => Conjugate(x[i]) * y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static complex Dot(
            ConjugatedVectorDescriptor xDescriptor, complex* x,
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

            return dotc(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => Conjugate(x[i]) * y[i]).
        /// </summary>
        public static complex Dot(ConjugatedVector<complex> x, Vector<complex> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complex* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dotc(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            }
        }

        /// <summary>
        /// Sum(i => x[i] * Conjugate(y[i])).
        /// </summary>
        [CLSCompliant(false)]
        public static complex Dot(
            VectorDescriptor xDescriptor, complex* x,
            ConjugatedVectorDescriptor yDescriptor, complex* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            return dotc(yDescriptor, y, xDescriptor, x);
        }

        /// <summary>
        /// Sum(i => x[i] * Conjugate(y[i])).
        /// </summary>
        public static complex Dot(Vector<complex> x, ConjugatedVector<complex> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complex* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dotc(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            }
        }
    }
}
