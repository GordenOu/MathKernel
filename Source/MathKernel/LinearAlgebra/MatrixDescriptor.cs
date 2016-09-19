using System;
using Core.Diagnostics;

namespace MathKernel.LinearAlgebra
{
    public class MatrixDescriptor
    {
        public int Rows { get; private set; }

        public int Columns { get; private set; }

        public int Offset { get; private set; }

        public int Stride { get; private set; }

        public MatrixLayout Layout { get; private set; }

        public bool IsConjugated { get; private set; }

        private MatrixDescriptor() { }

        public MatrixDescriptor(
            int rows,
            int columns,
            int offset,
            int stride,
            MatrixLayout layout = MatrixLayout.RowMajor)
        {
            Requires.Positive(rows, nameof(rows));
            Requires.Positive(columns, nameof(columns));
            Requires.NonNegative(offset, nameof(offset));
            switch (layout)
            {
                case MatrixLayout.RowMajor:
                    Requires.Range(stride, nameof(stride), stride >= columns);
                    break;
                case MatrixLayout.ColumnMajor:
                    Requires.Range(stride, nameof(stride), stride >= rows);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(layout));
            }

            Rows = rows;
            Columns = columns;
            Offset = offset;
            Stride = stride;
            Layout = layout;
        }

        public MatrixDescriptor(
            int rows,
            int columns,
            int offset,
            MatrixLayout layout = MatrixLayout.RowMajor)
            : this(
                  rows,
                  columns,
                  offset,
                  layout == MatrixLayout.RowMajor ? columns : rows,
                  layout)
        { }

        public MatrixDescriptor(
            int rows,
            int columns,
            MatrixLayout layout = MatrixLayout.RowMajor)
            : this(
                  rows,
                  columns,
                  0,
                  layout == MatrixLayout.RowMajor ? columns : rows,
                  layout)
        { }

        public MatrixDescriptor Transpose()
        {
            var layout = Layout == MatrixLayout.RowMajor
                ? MatrixLayout.ColumnMajor
                : MatrixLayout.RowMajor;
            return new MatrixDescriptor
            {
                Rows = Columns,
                Columns = Rows,
                Offset = Offset,
                Stride = Stride,
                Layout = layout,
                IsConjugated = IsConjugated
            };
        }

        public MatrixDescriptor ConjugateTranspose()
        {
            var descriptor = Transpose();
            descriptor.IsConjugated = !IsConjugated;
            return descriptor;
        }
    }
}
