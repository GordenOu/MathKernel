using Core.Diagnostics;

namespace MathKernel.LinearAlgebra
{
    public class BandMatrixDescriptor
    {
        public int Rows { get; private set; }

        public int Columns { get; private set; }

        public int UpperBandwidth { get; private set; }

        public int LowerBandwidth { get; private set; }

        public int Offset { get; private set; }

        public int Stride { get; private set; }

        public MatrixLayout Layout { get; private set; }

        public bool IsConjugated { get; private set; }

        private BandMatrixDescriptor() { }

        public BandMatrixDescriptor(
            int rows,
            int columns,
            int upperBandwidth,
            int lowerBandwidth,
            int offset,
            int stride,
            MatrixLayout layout = MatrixLayout.RowMajor)
        {
            Requires.Positive(rows, nameof(rows));
            Requires.Positive(columns, nameof(columns));
            Requires.Range(upperBandwidth, nameof(upperBandwidth), upperBandwidth < columns);
            Requires.Range(lowerBandwidth, nameof(lowerBandwidth), lowerBandwidth < rows);
            Requires.NonNegative(offset, nameof(offset));
            Requires.NonNegative(upperBandwidth, nameof(upperBandwidth));
            Requires.NonNegative(lowerBandwidth, nameof(lowerBandwidth));
            Requires.Range(stride, nameof(stride), stride >= upperBandwidth + lowerBandwidth + 1);

            Rows = rows;
            Columns = columns;
            UpperBandwidth = upperBandwidth;
            LowerBandwidth = lowerBandwidth;
            Offset = offset;
            Stride = stride;
            Layout = layout;
        }

        public BandMatrixDescriptor(
            int rows,
            int columns,
            int upperBandwidth,
            int lowerBandwidth,
            int offset,
            MatrixLayout layout = MatrixLayout.RowMajor)
            : this(
                  rows,
                  columns,
                  upperBandwidth,
                  lowerBandwidth,
                  offset,
                  layout == MatrixLayout.RowMajor ? columns : rows,
                  layout)
        { }

        public BandMatrixDescriptor(
            int rows,
            int columns,
            int upperBandwidth,
            int lowerBandwidth,
            MatrixLayout layout = MatrixLayout.RowMajor)
            : this(
                  rows,
                  columns,
                  upperBandwidth,
                  lowerBandwidth,
                  0,
                  layout == MatrixLayout.RowMajor ? columns : rows,
                  layout)
        { }

        public BandMatrixDescriptor Transpose()
        {
            var layout = Layout == MatrixLayout.RowMajor
                ? MatrixLayout.ColumnMajor
                : MatrixLayout.RowMajor;
            return new BandMatrixDescriptor
            {
                Rows = Columns,
                Columns = Rows,
                UpperBandwidth = LowerBandwidth,
                LowerBandwidth = UpperBandwidth,
                Offset = Offset,
                Stride = Stride,
                Layout = layout,
                IsConjugated = IsConjugated
            };
        }

        public BandMatrixDescriptor ConjugateTranspose()
        {
            var descriptor = Transpose();
            descriptor.IsConjugated = !IsConjugated;
            return descriptor;
        }
    }
}
