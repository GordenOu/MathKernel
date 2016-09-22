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
        public T[] Storage { get; private set; }

        public BandMatrixDescriptor Descriptor { get; private set; }

        private BandMatrix() { }

        internal BandMatrix(T[] storage, BandMatrixDescriptor descriptor)
        {
            Requires.NotNull(storage, nameof(storage));
            Requires.NotNull(descriptor, nameof(descriptor));
            int rows = descriptor.Rows;
            int columns = descriptor.Columns;
            int upperBandwidth = descriptor.UpperBandwidth;
            int lowerBandwidth = descriptor.LowerBandwidth;
            int bandwidth = upperBandwidth + lowerBandwidth + 1;
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

        public BandMatrix<T> Transpose()
        {
            return new BandMatrix<T>
            {
                Storage = Storage,
                Descriptor = Descriptor.Transpose()
            };
        }

        public BandMatrix<T> ConjugateTranspose()
        {
            return new BandMatrix<T>
            {
                Storage = Storage,
                Descriptor = Descriptor.ConjugateTranspose()
            };
        }
    }

    [Duplicate(typeof(float))]
    public static partial class BandMatrix
    {
        public static BandMatrix<float> Create(
            float[] storage,
            BandMatrixDescriptor descriptor)
        {
            return new BandMatrix<float>(storage, descriptor);
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
            int offset1 = matrix.Descriptor.Offset;
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

            return transposed
                ? new BandMatrix<float>(storage, descriptor.Transpose())
                : new BandMatrix<float>(storage, descriptor);
        }
    }

    [Duplicate(typeof(double))]
    public static partial class BandMatrix
    {
        public static BandMatrix<double> Create(
            double[] storage,
            BandMatrixDescriptor descriptor)
        {
            return new BandMatrix<double>(storage, descriptor);
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
            int offset1 = matrix.Descriptor.Offset;
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

            return transposed
                ? new BandMatrix<double>(storage, descriptor.Transpose())
                : new BandMatrix<double>(storage, descriptor);
        }
    }

    [Duplicate(typeof(complexf))]
    public static partial class BandMatrix
    {
        public static BandMatrix<complexf> Create(
            complexf[] storage,
            BandMatrixDescriptor descriptor)
        {
            return new BandMatrix<complexf>(storage, descriptor);
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
            int offset1 = matrix.Descriptor.Offset;
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

            return transposed
                ? new BandMatrix<complexf>(storage, descriptor.Transpose())
                : new BandMatrix<complexf>(storage, descriptor);
        }
    }

    [Duplicate(typeof(complex))]
    public static partial class BandMatrix
    {
        public static BandMatrix<complex> Create(
            complex[] storage,
            BandMatrixDescriptor descriptor)
        {
            return new BandMatrix<complex>(storage, descriptor);
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
            int offset1 = matrix.Descriptor.Offset;
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

            return transposed
                ? new BandMatrix<complex>(storage, descriptor.Transpose())
                : new BandMatrix<complex>(storage, descriptor);
        }
    }
}
