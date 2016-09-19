using System;
using System.Diagnostics;
using Core.Diagnostics;
using MathKernel.Resources;

namespace MathKernel
{
    public class Matrix<T>
        where T : struct
    {
        public T[] Storage { get; private set; }

        public MatrixDescriptor Descriptor { get; private set; }

        private Matrix() { }

        internal Matrix(T[] storage, MatrixDescriptor descriptor)
        {
            Requires.NotNull(storage, nameof(storage));
            Requires.NotNull(descriptor, nameof(descriptor));
            int rows = descriptor.Rows;
            int columns = descriptor.Columns;
            int offset = descriptor.Offset;
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

            Storage = storage;
            Descriptor = descriptor;
        }

        public Matrix<T> Transpose()
        {
            return new Matrix<T>
            {
                Storage = Storage,
                Descriptor = Descriptor.Transpose()
            };
        }

        public Matrix<T> ConjugateTranspose()
        {
            return new Matrix<T>
            {
                Storage = Storage,
                Descriptor = Descriptor.ConjugateTranspose()
            };
        }
    }

    [Duplicate(typeof(float))]
    public static partial class Matrix
    {
        public static Matrix<float> Create(float[] storage, MatrixDescriptor descriptor)
        {
            return new Matrix<float>(storage, descriptor);
        }

        public static Matrix<float> Create(
            float[] storage,
            int rows,
            int columns,
            MatrixLayout layout = MatrixLayout.RowMajor)
        {
            return new Matrix<float>(storage, new MatrixDescriptor(rows, columns, layout));
        }
    }

    [Duplicate(typeof(double))]
    public static partial class Matrix
    {
        public static Matrix<double> Create(double[] storage, MatrixDescriptor descriptor)
        {
            return new Matrix<double>(storage, descriptor);
        }

        public static Matrix<double> Create(
            double[] storage,
            int rows,
            int columns,
            MatrixLayout layout = MatrixLayout.RowMajor)
        {
            return new Matrix<double>(storage, new MatrixDescriptor(rows, columns, layout));
        }
    }

    [Duplicate(typeof(complexf))]
    public static partial class Matrix
    {
        public static Matrix<complexf> Create(complexf[] storage, MatrixDescriptor descriptor)
        {
            return new Matrix<complexf>(storage, descriptor);
        }

        public static Matrix<complexf> Create(
            complexf[] storage,
            int rows,
            int columns,
            MatrixLayout layout = MatrixLayout.RowMajor)
        {
            return new Matrix<complexf>(storage, new MatrixDescriptor(rows, columns, layout));
        }
    }

    [Duplicate(typeof(complex))]
    public static partial class Matrix
    {
        public static Matrix<complex> Create(complex[] storage, MatrixDescriptor descriptor)
        {
            return new Matrix<complex>(storage, descriptor);
        }

        public static Matrix<complex> Create(
            complex[] storage,
            int rows,
            int columns,
            MatrixLayout layout = MatrixLayout.RowMajor)
        {
            return new Matrix<complex>(storage, new MatrixDescriptor(rows, columns, layout));
        }
    }
}
