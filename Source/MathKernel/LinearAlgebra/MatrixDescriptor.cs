using System;
using Core.Diagnostics;

namespace MathKernel.LinearAlgebra
{
    public class MatrixDescriptor
    {
        public int Rows { get; private set; }

        public int Columns { get; private set; }

        public int Stride { get; private set; }

        public MatrixLayout Layout { get; private set; }

        private MatrixDescriptor() { }

        public MatrixDescriptor(
            int rows,
            int columns,
            int stride,
            MatrixLayout layout = MatrixLayout.RowMajor)
        {
            Requires.Positive(rows, nameof(rows));
            Requires.Positive(columns, nameof(columns));
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
            Stride = stride;
            Layout = layout;
        }

        public MatrixDescriptor(
            int rows,
            int columns,
            MatrixLayout layout = MatrixLayout.RowMajor)
            : this(
                  rows,
                  columns,
                  layout == MatrixLayout.RowMajor ? columns : rows,
                  layout)
        { }

        public MatrixDescriptor Transpose()
        {
            return new MatrixDescriptor
            {
                Rows = Columns,
                Columns = Rows,
                Stride = Stride,
                Layout = Layout.Transpose()
            };
        }
    }
}
