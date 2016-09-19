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

        /// <summary>
        /// Convert from full storage to band storage.
        /// </summary>
        public static BandMatrix<T> FromMatrix(Matrix<T> matrix, BandMatrixDescriptor descriptor)
        {
            Requires.NotNull(matrix, nameof(matrix));
            Requires.NotNull(descriptor, nameof(descriptor));

            if (matrix.Descriptor.Layout == MatrixLayout.ColumnMajor)
            {
                matrix = matrix.Transpose();
            }
            Debug.Assert(matrix.Descriptor.Layout == MatrixLayout.RowMajor);
            BandMatrixDescriptor temp = null;
            if (descriptor.Layout == MatrixLayout.ColumnMajor)
            {
                temp = descriptor;
                descriptor = descriptor.Transpose();
            }
            Debug.Assert(descriptor.Layout == MatrixLayout.RowMajor);

            T[] storage = new T[descriptor.Offset + descriptor.Rows * descriptor.Stride];
            int offset1 = matrix.Descriptor.Offset;
            int offset2 = descriptor.Offset;
            for (int i = 0; i < descriptor.Rows; i++)
            {
                int begin1 = Max(0, i - descriptor.LowerBandwidth);
                int begin2 = Max(0, descriptor.LowerBandwidth - i);
                int end = Min(descriptor.Columns, i + descriptor.UpperBandwidth + 1);
                for (int j1 = begin1, j2 = begin2; j1 <= end; j1++, j2++)
                {
                    storage[offset2 + j2] = matrix.Storage[offset1 + j1];
                }

                offset1 += matrix.Descriptor.Stride;
                offset2 += descriptor.Stride;
            }

            if (temp == null)
            {
                return new BandMatrix<T>(storage, descriptor);
            }
            else
            {
                return new BandMatrix<T>(storage, temp);
            }
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
    }
}
