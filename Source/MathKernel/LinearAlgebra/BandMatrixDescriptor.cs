using Core.Diagnostics;

namespace MathKernel.LinearAlgebra
{
    public class BandMatrixDescriptor
    {
        public int Rows { get; private set; }

        public int Columns { get; private set; }

        public int UpperBandwidth { get; private set; }

        public int LowerBandwidth { get; private set; }

        public int Stride { get; private set; }

        public MatrixLayout Layout { get; private set; }

        private BandMatrixDescriptor() { }

        public BandMatrixDescriptor(
            int rows,
            int columns,
            int upperBandwidth,
            int lowerBandwidth,
            int stride,
            MatrixLayout layout = MatrixLayout.RowMajor)
        {
            Requires.Positive(rows, nameof(rows));
            Requires.Positive(columns, nameof(columns));
            Requires.NonNegative(upperBandwidth, nameof(upperBandwidth));
            Requires.Range(upperBandwidth, nameof(upperBandwidth), upperBandwidth < columns);
            Requires.NonNegative(lowerBandwidth, nameof(lowerBandwidth));
            Requires.Range(lowerBandwidth, nameof(lowerBandwidth), lowerBandwidth < rows);
            Requires.Range(stride, nameof(stride), stride >= upperBandwidth + lowerBandwidth + 1);
            Requires.Range(
                layout,
                nameof(layout),
                layout == MatrixLayout.RowMajor || layout == MatrixLayout.ColumnMajor);

            Rows = rows;
            Columns = columns;
            UpperBandwidth = upperBandwidth;
            LowerBandwidth = lowerBandwidth;
            Stride = stride;
            Layout = layout;
        }

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
                  upperBandwidth + lowerBandwidth + 1,
                  layout)
        { }

        public BandMatrixDescriptor Transpose()
        {
            return new BandMatrixDescriptor
            {
                Rows = Columns,
                Columns = Rows,
                UpperBandwidth = LowerBandwidth,
                LowerBandwidth = UpperBandwidth,
                Stride = Stride,
                Layout = Layout.Transpose()
            };
        }
    }
}
