using System;
using System.Diagnostics;
using Core.Diagnostics;
using MathKernel.Resources;
using static System.Math;

namespace MathKernel.LinearAlgebra
{
    public class BandMatrix<T>
        where T : struct
    {
        public BandMatrixDescriptor Descriptor { get; private set; }

        public T[] Storage { get; private set; }

        public int Offset { get; private set; }

        private BandMatrix() { }

        internal BandMatrix(BandMatrixDescriptor descriptor, T[] storage, int offset)
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

        public BandMatrix<T> Transpose()
        {
            return new BandMatrix<T>
            {
                Descriptor = Descriptor.Transpose(),
                Storage = Storage,
                Offset = Offset
            };
        }
    }

    [Duplicate(typeof(float))]
    public static partial class BandMatrix
    {
        public static BandMatrix<float> Create(
            BandMatrixDescriptor descriptor,
            float[] storage,
            int offset)
        {
            return new BandMatrix<float>(descriptor, storage, offset);
        }

        public static BandMatrix<float> Create(
            BandMatrixDescriptor descriptor,
            float[] storage)
        {
            return new BandMatrix<float>(descriptor, storage, 0);
        }

        /// <summary>
        /// Convert from full storage to band storage.
        /// </summary>
        public static BandMatrix<float> FromMatrix(
            Matrix<float> matrix,
            int upperBandwidth,
            int lowerBandwidth)
        {
            Requires.NotNull(matrix, nameof(matrix));
            Requires.Range(
                upperBandwidth,
                nameof(upperBandwidth),
                0 <= upperBandwidth && upperBandwidth < matrix.Descriptor.Columns);
            Requires.Range(
                lowerBandwidth,
                nameof(lowerBandwidth),
                0 <= lowerBandwidth && lowerBandwidth < matrix.Descriptor.Rows);

            var descriptor = new BandMatrixDescriptor(
                matrix.Descriptor.Rows,
                matrix.Descriptor.Columns,
                upperBandwidth,
                lowerBandwidth,
                matrix.Descriptor.Layout);
            bool transposed = false;
            if (matrix.Descriptor.Layout == MatrixLayout.ColumnMajor)
            {
                matrix = matrix.Transpose();
                descriptor = descriptor.Transpose();
                transposed = true;
            }
            Debug.Assert(matrix.Descriptor.Layout == MatrixLayout.RowMajor);
            Debug.Assert(descriptor.Layout == MatrixLayout.RowMajor);

            var storage = new float[descriptor.Rows * descriptor.Stride];
            int offset1 = matrix.Offset;
            int offset2 = 0;
            for (int i = 0; i < descriptor.Rows; i++)
            {
                int begin1 = Max(0, i - descriptor.LowerBandwidth);
                int begin2 = Max(0, descriptor.LowerBandwidth - i);
                int end = Min(descriptor.Columns, i + descriptor.UpperBandwidth + 1);
                for (int j1 = begin1, j2 = begin2; j1 < end; j1++, j2++)
                {
                    storage[offset2 + j2] = matrix.Storage[offset1 + j1];
                }

                offset1 += matrix.Descriptor.Stride;
                offset2 += descriptor.Stride;
            }

            return Create(transposed ? descriptor.Transpose() : descriptor, storage);
        }
    }

    [Duplicate(typeof(double))]
    public static partial class BandMatrix
    {
        public static BandMatrix<double> Create(
            BandMatrixDescriptor descriptor,
            double[] storage,
            int offset)
        {
            return new BandMatrix<double>(descriptor, storage, offset);
        }

        public static BandMatrix<double> Create(
            BandMatrixDescriptor descriptor,
            double[] storage)
        {
            return new BandMatrix<double>(descriptor, storage, 0);
        }

        /// <summary>
        /// Convert from full storage to band storage.
        /// </summary>
        public static BandMatrix<double> FromMatrix(
            Matrix<double> matrix,
            int upperBandwidth,
            int lowerBandwidth)
        {
            Requires.NotNull(matrix, nameof(matrix));
            Requires.Range(
                upperBandwidth,
                nameof(upperBandwidth),
                0 <= upperBandwidth && upperBandwidth < matrix.Descriptor.Columns);
            Requires.Range(
                lowerBandwidth,
                nameof(lowerBandwidth),
                0 <= lowerBandwidth && lowerBandwidth < matrix.Descriptor.Rows);

            var descriptor = new BandMatrixDescriptor(
                matrix.Descriptor.Rows,
                matrix.Descriptor.Columns,
                upperBandwidth,
                lowerBandwidth,
                matrix.Descriptor.Layout);
            bool transposed = false;
            if (matrix.Descriptor.Layout == MatrixLayout.ColumnMajor)
            {
                matrix = matrix.Transpose();
                descriptor = descriptor.Transpose();
                transposed = true;
            }
            Debug.Assert(matrix.Descriptor.Layout == MatrixLayout.RowMajor);
            Debug.Assert(descriptor.Layout == MatrixLayout.RowMajor);

            var storage = new double[descriptor.Rows * descriptor.Stride];
            int offset1 = matrix.Offset;
            int offset2 = 0;
            for (int i = 0; i < descriptor.Rows; i++)
            {
                int begin1 = Max(0, i - descriptor.LowerBandwidth);
                int begin2 = Max(0, descriptor.LowerBandwidth - i);
                int end = Min(descriptor.Columns, i + descriptor.UpperBandwidth + 1);
                for (int j1 = begin1, j2 = begin2; j1 < end; j1++, j2++)
                {
                    storage[offset2 + j2] = matrix.Storage[offset1 + j1];
                }

                offset1 += matrix.Descriptor.Stride;
                offset2 += descriptor.Stride;
            }

            return Create(transposed ? descriptor.Transpose() : descriptor, storage);
        }
    }

    [Duplicate(typeof(complexf))]
    public static partial class BandMatrix
    {
        public static BandMatrix<complexf> Create(
            BandMatrixDescriptor descriptor,
            complexf[] storage,
            int offset)
        {
            return new BandMatrix<complexf>(descriptor, storage, offset);
        }

        public static BandMatrix<complexf> Create(
            BandMatrixDescriptor descriptor,
            complexf[] storage)
        {
            return new BandMatrix<complexf>(descriptor, storage, 0);
        }

        /// <summary>
        /// Convert from full storage to band storage.
        /// </summary>
        public static BandMatrix<complexf> FromMatrix(
            Matrix<complexf> matrix,
            int upperBandwidth,
            int lowerBandwidth)
        {
            Requires.NotNull(matrix, nameof(matrix));
            Requires.Range(
                upperBandwidth,
                nameof(upperBandwidth),
                0 <= upperBandwidth && upperBandwidth < matrix.Descriptor.Columns);
            Requires.Range(
                lowerBandwidth,
                nameof(lowerBandwidth),
                0 <= lowerBandwidth && lowerBandwidth < matrix.Descriptor.Rows);

            var descriptor = new BandMatrixDescriptor(
                matrix.Descriptor.Rows,
                matrix.Descriptor.Columns,
                upperBandwidth,
                lowerBandwidth,
                matrix.Descriptor.Layout);
            bool transposed = false;
            if (matrix.Descriptor.Layout == MatrixLayout.ColumnMajor)
            {
                matrix = matrix.Transpose();
                descriptor = descriptor.Transpose();
                transposed = true;
            }
            Debug.Assert(matrix.Descriptor.Layout == MatrixLayout.RowMajor);
            Debug.Assert(descriptor.Layout == MatrixLayout.RowMajor);

            var storage = new complexf[descriptor.Rows * descriptor.Stride];
            int offset1 = matrix.Offset;
            int offset2 = 0;
            for (int i = 0; i < descriptor.Rows; i++)
            {
                int begin1 = Max(0, i - descriptor.LowerBandwidth);
                int begin2 = Max(0, descriptor.LowerBandwidth - i);
                int end = Min(descriptor.Columns, i + descriptor.UpperBandwidth + 1);
                for (int j1 = begin1, j2 = begin2; j1 < end; j1++, j2++)
                {
                    storage[offset2 + j2] = matrix.Storage[offset1 + j1];
                }

                offset1 += matrix.Descriptor.Stride;
                offset2 += descriptor.Stride;
            }

            return Create(transposed ? descriptor.Transpose() : descriptor, storage);
        }
    }

    [Duplicate(typeof(complex))]
    public static partial class BandMatrix
    {
        public static BandMatrix<complex> Create(
            BandMatrixDescriptor descriptor,
            complex[] storage,
            int offset)
        {
            return new BandMatrix<complex>(descriptor, storage, offset);
        }

        public static BandMatrix<complex> Create(
            BandMatrixDescriptor descriptor,
            complex[] storage)
        {
            return new BandMatrix<complex>(descriptor, storage, 0);
        }

        /// <summary>
        /// Convert from full storage to band storage.
        /// </summary>
        public static BandMatrix<complex> FromMatrix(
            Matrix<complex> matrix,
            int upperBandwidth,
            int lowerBandwidth)
        {
            Requires.NotNull(matrix, nameof(matrix));
            Requires.Range(
                upperBandwidth,
                nameof(upperBandwidth),
                0 <= upperBandwidth && upperBandwidth < matrix.Descriptor.Columns);
            Requires.Range(
                lowerBandwidth,
                nameof(lowerBandwidth),
                0 <= lowerBandwidth && lowerBandwidth < matrix.Descriptor.Rows);

            var descriptor = new BandMatrixDescriptor(
                matrix.Descriptor.Rows,
                matrix.Descriptor.Columns,
                upperBandwidth,
                lowerBandwidth,
                matrix.Descriptor.Layout);
            bool transposed = false;
            if (matrix.Descriptor.Layout == MatrixLayout.ColumnMajor)
            {
                matrix = matrix.Transpose();
                descriptor = descriptor.Transpose();
                transposed = true;
            }
            Debug.Assert(matrix.Descriptor.Layout == MatrixLayout.RowMajor);
            Debug.Assert(descriptor.Layout == MatrixLayout.RowMajor);

            var storage = new complex[descriptor.Rows * descriptor.Stride];
            int offset1 = matrix.Offset;
            int offset2 = 0;
            for (int i = 0; i < descriptor.Rows; i++)
            {
                int begin1 = Max(0, i - descriptor.LowerBandwidth);
                int begin2 = Max(0, descriptor.LowerBandwidth - i);
                int end = Min(descriptor.Columns, i + descriptor.UpperBandwidth + 1);
                for (int j1 = begin1, j2 = begin2; j1 < end; j1++, j2++)
                {
                    storage[offset2 + j2] = matrix.Storage[offset1 + j1];
                }

                offset1 += matrix.Descriptor.Stride;
                offset2 += descriptor.Stride;
            }

            return Create(transposed ? descriptor.Transpose() : descriptor, storage);
        }
    }
}
