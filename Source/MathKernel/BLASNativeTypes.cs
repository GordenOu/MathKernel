namespace MathKernel
{
    internal enum CBLAS_LAYOUT
    {
        CblasRowMajor = 101,
        CblasColMajor = 102
    }

    internal enum CBLAS_TRANSPOSE
    {
        CblasNoTrans = 111,
        CblasTrans = 112,
        CblasConjTrans = 113
    }

    internal enum CBLAS_UPLO
    {
        CblasUpper = 121,
        CblasLower = 122
    }

    internal enum CBLAS_DIAG
    {
        CblasNonUnit = 131,
        CblasUnit = 132
    }

    internal enum CBLAS_SIDE
    {
        CblasLeft = 141,
        CblasRight = 142
    }

    internal enum CBLAS_IDENTIFIER
    {
        CblasAMatrix = 161,
        CblasBMatrix = 162
    }
}
