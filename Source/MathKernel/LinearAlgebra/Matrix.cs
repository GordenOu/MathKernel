using System;
using System.Diagnostics;
using Core.Diagnostics;
using MathKernel.Resources;

namespace MathKernel.LinearAlgebra
{
    public class Matrix<T>
        where T : struct
    {
        public MatrixDescriptor Descriptor { get; private set; }

        public T[] Storage { get; private set; }

        public int Offset { get; private set; }

        private Matrix() { }

        internal Matrix(MatrixDescriptor descriptor, T[] storage, int offset)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNull(storage, nameof(storage));
            Requires.NonNegative(offset, nameof(offset));
            int rows = descriptor.Rows;
            int columns = descriptor.Columns;
            int stride = descriptor.Stride;
            switch (descriptor.Layout)
            {
                case MatrixLayout.RowMajor:
                    if (storage.Length < offset + rows * stride)
                    {
                        throw new ArgumentException(Strings.InsufficientStorageLength);
                    }
                    break;
                case MatrixLayout.ColumnMajor:
                    if (storage.Length < offset + columns * stride)
                    {
                        throw new ArgumentException(Strings.InsufficientStorageLength);
                    }
                    break;
                default:
                    Debug.Fail(Strings.Unreachable);
                    break;
            }

            Descriptor = descriptor;
            Storage = storage;
            Offset = offset;
        }

        public Matrix<T> Transpose()
        {
            return new Matrix<T>
            {
                Descriptor = Descriptor.Transpose(),
                Storage = Storage,
                Offset = Offset
            };
        }
    }

    [Duplicate(typeof(float))]
    public static partial class Matrix
    {
        public static Matrix<float> Create(
            MatrixDescriptor descriptor,
            float[] storage,
            int offset)
        {
            return new Matrix<float>(descriptor, storage, offset);
        }

        public static Matrix<float> Create(MatrixDescriptor descriptor, float[] storage)
        {
            return new Matrix<float>(descriptor, storage, 0);
        }
    }

    [Duplicate(typeof(double))]
    public static partial class Matrix
    {
        public static Matrix<double> Create(
            MatrixDescriptor descriptor,
            double[] storage,
            int offset)
        {
            return new Matrix<double>(descriptor, storage, offset);
        }

        public static Matrix<double> Create(MatrixDescriptor descriptor, double[] storage)
        {
            return new Matrix<double>(descriptor, storage, 0);
        }
    }

    [Duplicate(typeof(complexf))]
    public static partial class Matrix
    {
        public static Matrix<complexf> Create(
            MatrixDescriptor descriptor,
            complexf[] storage,
            int offset)
        {
            return new Matrix<complexf>(descriptor, storage, offset);
        }

        public static Matrix<complexf> Create(MatrixDescriptor descriptor, complexf[] storage)
        {
            return new Matrix<complexf>(descriptor, storage, 0);
        }
    }

    [Duplicate(typeof(complex))]
    public static partial class Matrix
    {
        public static Matrix<complex> Create(
            MatrixDescriptor descriptor,
            complex[] storage,
            int offset)
        {
            return new Matrix<complex>(descriptor, storage, offset);
        }

        public static Matrix<complex> Create(MatrixDescriptor descriptor, complex[] storage)
        {
            return new Matrix<complex>(descriptor, storage, 0);
        }
    }
}
