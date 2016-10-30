using System;
using System.Diagnostics;
using MathKernel.Resources;

namespace MathKernel.LinearAlgebra
{
    public enum MatrixLayout
    {
        RowMajor = 101,
        ColumnMajor = 102
    }

    internal static class MatrixLayoutExtensions
    {
        public static MatrixLayout Transpose(this MatrixLayout layout)
        {
            switch (layout)
            {
                case MatrixLayout.RowMajor:
                    return MatrixLayout.ColumnMajor;
                case MatrixLayout.ColumnMajor:
                    return MatrixLayout.RowMajor;
                default:
                    Debug.Fail(Strings.Unreachable);
                    throw new ArgumentOutOfRangeException(nameof(layout));
            }
        }
    }
}
