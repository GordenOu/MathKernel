using System.Runtime.InteropServices;

namespace MathKernel.LinearAlgebra
{
    internal static unsafe class BLASNativeMethods
    {
        private const string dllName = "mkl_rt";

        [DllImport(dllName)]
        public static extern double cblas_dcabs1(
            void* z);

        [DllImport(dllName)]
        public static extern float cblas_scabs1(
            void* c);

        [DllImport(dllName)]
        public static extern float cblas_sdot(
            int N,
            float* X,
            int incX,
            float* Y,
            int incY);

        [DllImport(dllName)]
        public static extern float cblas_sdoti(
            int N,
            float* X,
            int* indx,
            float* Y);

        [DllImport(dllName)]
        public static extern double cblas_ddot(
            int N,
            double* X,
            int incX,
            double* Y,
            int incY);

        [DllImport(dllName)]
        public static extern double cblas_ddoti(
            int N,
            double* X,
            int* indx,
            double* Y);

        [DllImport(dllName)]
        public static extern double cblas_dsdot(
            int N,
            float* X,
            int incX,
            float* Y,
            int incY);

        [DllImport(dllName)]
        public static extern float cblas_sdsdot(
            int N,
            float sb,
            float* X,
            int incX,
            float* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_cdotu_sub(
            int N,
            void* X,
            int incX,
            void* Y,
            int incY,
            void* dotu);

        [DllImport(dllName)]
        public static extern void cblas_cdotui_sub(
            int N,
            void* X,
            int* indx,
            void* Y,
            void* dotui);

        [DllImport(dllName)]
        public static extern void cblas_cdotc_sub(
            int N,
            void* X,
            int incX,
            void* Y,
            int incY,
            void* dotc);

        [DllImport(dllName)]
        public static extern void cblas_cdotci_sub(
            int N,
            void* X,
            int* indx,
            void* Y,
            void* dotui);

        [DllImport(dllName)]
        public static extern void cblas_zdotu_sub(
            int N,
            void* X,
            int incX,
            void* Y,
            int incY,
            void* dotu);

        [DllImport(dllName)]
        public static extern void cblas_zdotui_sub(
            int N,
            void* X,
            int* indx,
            void* Y,
            void* dotui);

        [DllImport(dllName)]
        public static extern void cblas_zdotc_sub(
            int N,
            void* X,
            int incX,
            void* Y,
            int incY,
            void* dotc);

        [DllImport(dllName)]
        public static extern void cblas_zdotci_sub(
            int N,
            void* X,
            int* indx,
            void* Y,
            void* dotui);

        [DllImport(dllName)]
        public static extern float cblas_snrm2(
            int N,
            float* X,
            int incX);

        [DllImport(dllName)]
        public static extern float cblas_sasum(
            int N,
            float* X,
            int incX);

        [DllImport(dllName)]
        public static extern double cblas_dnrm2(
            int N,
            double* X,
            int incX);

        [DllImport(dllName)]
        public static extern double cblas_dasum(
            int N,
            double* X,
            int incX);

        [DllImport(dllName)]
        public static extern float cblas_scnrm2(
            int N,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern float cblas_scasum(
            int N,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern double cblas_dznrm2(
            int N,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern double cblas_dzasum(
            int N,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern ulong cblas_isamax(
            int N,
            float* X,
            int incX);

        [DllImport(dllName)]
        public static extern ulong cblas_idamax(
            int N,
            double* X,
            int incX);

        [DllImport(dllName)]
        public static extern ulong cblas_icamax(
            int N,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern ulong cblas_izamax(
            int N,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern ulong cblas_isamin(
            int N,
            float* X,
            int incX);

        [DllImport(dllName)]
        public static extern ulong cblas_idamin(
            int N,
            double* X,
            int incX);

        [DllImport(dllName)]
        public static extern ulong cblas_icamin(
            int N,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern ulong cblas_izamin(
            int N,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_sswap(
            int N,
            float* X,
            int incX,
            float* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_scopy(
            int N,
            float* X,
            int incX,
            float* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_saxpy(
            int N,
            float alpha,
            float* X,
            int incX,
            float* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_saxpby(
            int N,
            float alpha,
            float* X,
            int incX,
            float beta,
            float* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_saxpyi(
            int N,
            float alpha,
            float* X,
            int* indx,
            float* Y);

        [DllImport(dllName)]
        public static extern void cblas_sgthr(
            int N,
            float* Y,
            float* X,
            int* indx);

        [DllImport(dllName)]
        public static extern void cblas_sgthrz(
            int N,
            float* Y,
            float* X,
            int* indx);

        [DllImport(dllName)]
        public static extern void cblas_ssctr(
            int N,
            float* X,
            int* indx,
            float* Y);

        [DllImport(dllName)]
        public static extern void cblas_srotg(
            float* a,
            float* b,
            float* c,
            float* s);

        [DllImport(dllName)]
        public static extern void cblas_dswap(
            int N,
            double* X,
            int incX,
            double* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_dcopy(
            int N,
            double* X,
            int incX,
            double* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_daxpy(
            int N,
            double alpha,
            double* X,
            int incX,
            double* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_daxpby(
            int N,
            double alpha,
            double* X,
            int incX,
            double beta,
            double* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_daxpyi(
            int N,
            double alpha,
            double* X,
            int* indx,
            double* Y);

        [DllImport(dllName)]
        public static extern void cblas_dgthr(
            int N,
            double* Y,
            double* X,
            int* indx);

        [DllImport(dllName)]
        public static extern void cblas_dgthrz(
            int N,
            double* Y,
            double* X,
            int* indx);

        [DllImport(dllName)]
        public static extern void cblas_dsctr(
            int N,
            double* X,
            int* indx,
            double* Y);

        [DllImport(dllName)]
        public static extern void cblas_drotg(
            double* a,
            double* b,
            double* c,
            double* s);

        [DllImport(dllName)]
        public static extern void cblas_cswap(
            int N,
            void* X,
            int incX,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_ccopy(
            int N,
            void* X,
            int incX,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_caxpy(
            int N,
            void* alpha,
            void* X,
            int incX,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_caxpby(
            int N,
            void* alpha,
            void* X,
            int incX,
            void* beta,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_caxpyi(
            int N,
            void* alpha,
            void* X,
            int* indx,
            void* Y);

        [DllImport(dllName)]
        public static extern void cblas_cgthr(
            int N,
            void* Y,
            void* X,
            int* indx);

        [DllImport(dllName)]
        public static extern void cblas_cgthrz(
            int N,
            void* Y,
            void* X,
            int* indx);

        [DllImport(dllName)]
        public static extern void cblas_csctr(
            int N,
            void* X,
            int* indx,
            void* Y);

        [DllImport(dllName)]
        public static extern void cblas_crotg(
            void* a,
            void* b,
            float* c,
            void* s);

        [DllImport(dllName)]
        public static extern void cblas_zswap(
            int N,
            void* X,
            int incX,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_zcopy(
            int N,
            void* X,
            int incX,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_zaxpy(
            int N,
            void* alpha,
            void* X,
            int incX,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_zaxpby(
            int N,
            void* alpha,
            void* X,
            int incX,
            void* beta,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_zaxpyi(
            int N,
            void* alpha,
            void* X,
            int* indx,
            void* Y);

        [DllImport(dllName)]
        public static extern void cblas_zgthr(
            int N,
            void* Y,
            void* X,
            int* indx);

        [DllImport(dllName)]
        public static extern void cblas_zgthrz(
            int N,
            void* Y,
            void* X,
            int* indx);

        [DllImport(dllName)]
        public static extern void cblas_zsctr(
            int N,
            void* X,
            int* indx,
            void* Y);

        [DllImport(dllName)]
        public static extern void cblas_zrotg(
            void* a,
            void* b,
            double* c,
            void* s);

        [DllImport(dllName)]
        public static extern void cblas_srotmg(
            float* d1,
            float* d2,
            float* b1,
            float b2,
            float* P);

        [DllImport(dllName)]
        public static extern void cblas_srot(
            int N,
            float* X,
            int incX,
            float* Y,
            int incY,
            float c,
            float s);

        [DllImport(dllName)]
        public static extern void cblas_sroti(
            int N,
            float* X,
            int* indx,
            float* Y,
            float c,
            float s);

        [DllImport(dllName)]
        public static extern void cblas_srotm(
            int N,
            float* X,
            int incX,
            float* Y,
            int incY,
            float* P);

        [DllImport(dllName)]
        public static extern void cblas_drotmg(
            double* d1,
            double* d2,
            double* b1,
            double b2,
            double* P);

        [DllImport(dllName)]
        public static extern void cblas_drot(
            int N,
            double* X,
            int incX,
            double* Y,
            int incY,
            double c,
            double s);

        [DllImport(dllName)]
        public static extern void cblas_drotm(
            int N,
            double* X,
            int incX,
            double* Y,
            int incY,
            double* P);

        [DllImport(dllName)]
        public static extern void cblas_droti(
            int N,
            double* X,
            int* indx,
            double* Y,
            double c,
            double s);

        [DllImport(dllName)]
        public static extern void cblas_csrot(
            int N,
            void* X,
            int incX,
            void* Y,
            int incY,
            float c,
            float s);

        [DllImport(dllName)]
        public static extern void cblas_zdrot(
            int N,
            void* X,
            int incX,
            void* Y,
            int incY,
            double c,
            double s);

        [DllImport(dllName)]
        public static extern void cblas_sscal(
            int N,
            float alpha,
            float* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_dscal(
            int N,
            double alpha,
            double* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_cscal(
            int N,
            void* alpha,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_zscal(
            int N,
            void* alpha,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_csscal(
            int N,
            float alpha,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_zdscal(
            int N,
            double alpha,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_sgemv(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            int M,
            int N,
            float alpha,
            float* A,
            int lda,
            float* X,
            int incX,
            float beta,
            float* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_sgbmv(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            int M,
            int N,
            int KL,
            int KU,
            float alpha,
            float* A,
            int lda,
            float* X,
            int incX,
            float beta,
            float* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_strmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            float* A,
            int lda,
            float* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_stbmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            int K,
            float* A,
            int lda,
            float* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_stpmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            float* Ap,
            float* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_strsv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            float* A,
            int lda,
            float* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_stbsv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            int K,
            float* A,
            int lda,
            float* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_stpsv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            float* Ap,
            float* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_dgemv(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            int M,
            int N,
            double alpha,
            double* A,
            int lda,
            double* X,
            int incX,
            double beta,
            double* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_dgbmv(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            int M,
            int N,
            int KL,
            int KU,
            double alpha,
            double* A,
            int lda,
            double* X,
            int incX,
            double beta,
            double* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_dtrmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            double* A,
            int lda,
            double* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_dtbmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            int K,
            double* A,
            int lda,
            double* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_dtpmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            double* Ap,
            double* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_dtrsv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            double* A,
            int lda,
            double* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_dtbsv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            int K,
            double* A,
            int lda,
            double* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_dtpsv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            double* Ap,
            double* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_cgemv(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            int M,
            int N,
            void* alpha,
            void* A,
            int lda,
            void* X,
            int incX,
            void* beta,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_cgbmv(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            int M,
            int N,
            int KL,
            int KU,
            void* alpha,
            void* A,
            int lda,
            void* X,
            int incX,
            void* beta,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_ctrmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            void* A,
            int lda,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_ctbmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            int K,
            void* A,
            int lda,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_ctpmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            void* Ap,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_ctrsv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            void* A,
            int lda,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_ctbsv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            int K,
            void* A,
            int lda,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_ctpsv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            void* Ap,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_zgemv(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            int M,
            int N,
            void* alpha,
            void* A,
            int lda,
            void* X,
            int incX,
            void* beta,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_zgbmv(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            int M,
            int N,
            int KL,
            int KU,
            void* alpha,
            void* A,
            int lda,
            void* X,
            int incX,
            void* beta,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_ztrmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            void* A,
            int lda,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_ztbmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            int K,
            void* A,
            int lda,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_ztpmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            void* Ap,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_ztrsv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            void* A,
            int lda,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_ztbsv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            int K,
            void* A,
            int lda,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_ztpsv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int N,
            void* Ap,
            void* X,
            int incX);

        [DllImport(dllName)]
        public static extern void cblas_ssymv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            float alpha,
            float* A,
            int lda,
            float* X,
            int incX,
            float beta,
            float* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_ssbmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            int K,
            float alpha,
            float* A,
            int lda,
            float* X,
            int incX,
            float beta,
            float* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_sspmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            float alpha,
            float* Ap,
            float* X,
            int incX,
            float beta,
            float* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_sger(
            CBLAS_LAYOUT Layout,
            int M,
            int N,
            float alpha,
            float* X,
            int incX,
            float* Y,
            int incY,
            float* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_ssyr(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            float alpha,
            float* X,
            int incX,
            float* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_sspr(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            float alpha,
            float* X,
            int incX,
            float* Ap);

        [DllImport(dllName)]
        public static extern void cblas_ssyr2(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            float alpha,
            float* X,
            int incX,
            float* Y,
            int incY,
            float* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_sspr2(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            float alpha,
            float* X,
            int incX,
            float* Y,
            int incY,
            float* A);

        [DllImport(dllName)]
        public static extern void cblas_dsymv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            double alpha,
            double* A,
            int lda,
            double* X,
            int incX,
            double beta,
            double* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_dsbmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            int K,
            double alpha,
            double* A,
            int lda,
            double* X,
            int incX,
            double beta,
            double* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_dspmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            double alpha,
            double* Ap,
            double* X,
            int incX,
            double beta,
            double* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_dger(
            CBLAS_LAYOUT Layout,
            int M,
            int N,
            double alpha,
            double* X,
            int incX,
            double* Y,
            int incY,
            double* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_dsyr(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            double alpha,
            double* X,
            int incX,
            double* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_dspr(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            double alpha,
            double* X,
            int incX,
            double* Ap);

        [DllImport(dllName)]
        public static extern void cblas_dsyr2(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            double alpha,
            double* X,
            int incX,
            double* Y,
            int incY,
            double* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_dspr2(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            double alpha,
            double* X,
            int incX,
            double* Y,
            int incY,
            double* A);

        [DllImport(dllName)]
        public static extern void cblas_chemv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            void* alpha,
            void* A,
            int lda,
            void* X,
            int incX,
            void* beta,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_chbmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* X,
            int incX,
            void* beta,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_chpmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            void* alpha,
            void* Ap,
            void* X,
            int incX,
            void* beta,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_cgeru(
            CBLAS_LAYOUT Layout,
            int M,
            int N,
            void* alpha,
            void* X,
            int incX,
            void* Y,
            int incY,
            void* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_cgerc(
            CBLAS_LAYOUT Layout,
            int M,
            int N,
            void* alpha,
            void* X,
            int incX,
            void* Y,
            int incY,
            void* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_cher(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            float alpha,
            void* X,
            int incX,
            void* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_chpr(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            float alpha,
            void* X,
            int incX,
            void* A);

        [DllImport(dllName)]
        public static extern void cblas_cher2(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            void* alpha,
            void* X,
            int incX,
            void* Y,
            int incY,
            void* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_chpr2(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            void* alpha,
            void* X,
            int incX,
            void* Y,
            int incY,
            void* Ap);

        [DllImport(dllName)]
        public static extern void cblas_zhemv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            void* alpha,
            void* A,
            int lda,
            void* X,
            int incX,
            void* beta,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_zhbmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* X,
            int incX,
            void* beta,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_zhpmv(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            void* alpha,
            void* Ap,
            void* X,
            int incX,
            void* beta,
            void* Y,
            int incY);

        [DllImport(dllName)]
        public static extern void cblas_zgeru(
            CBLAS_LAYOUT Layout,
            int M,
            int N,
            void* alpha,
            void* X,
            int incX,
            void* Y,
            int incY,
            void* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_zgerc(
            CBLAS_LAYOUT Layout,
            int M,
            int N,
            void* alpha,
            void* X,
            int incX,
            void* Y,
            int incY,
            void* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_zher(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            double alpha,
            void* X,
            int incX,
            void* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_zhpr(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            double alpha,
            void* X,
            int incX,
            void* A);

        [DllImport(dllName)]
        public static extern void cblas_zher2(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            void* alpha,
            void* X,
            int incX,
            void* Y,
            int incY,
            void* A,
            int lda);

        [DllImport(dllName)]
        public static extern void cblas_zhpr2(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            int N,
            void* alpha,
            void* X,
            int incX,
            void* Y,
            int incY,
            void* Ap);

        [DllImport(dllName)]
        public static extern void cblas_sgemm(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            CBLAS_TRANSPOSE TransB,
            int M,
            int N,
            int K,
            float alpha,
            float* A,
            int lda,
            float* B,
            int ldb,
            float beta,
            float* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_sgemm_batch(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE* TransA_Array,
            CBLAS_TRANSPOSE* TransB_Array,
            int* M_Array,
            int* N_Array,
            int* K_Array,
            float* alpha_Array,
            float** A_Array,
            int* lda_Array,
            float** B_Array,
            int* ldb_Array,
            float* beta_Array,
            float** C_Array,
            int* ldc_Array,
            int group_count,
            int* group_size);

        [DllImport(dllName)]
        public static extern void cblas_sgemmt(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_TRANSPOSE TransB,
            int N,
            int K,
            float alpha,
            float* A,
            int lda,
            float* B,
            int ldb,
            float beta,
            float* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_ssymm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            int M,
            int N,
            float alpha,
            float* A,
            int lda,
            float* B,
            int ldb,
            float beta,
            float* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_ssyrk(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE Trans,
            int N,
            int K,
            float alpha,
            float* A,
            int lda,
            float beta,
            float* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_ssyr2k(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE Trans,
            int N,
            int K,
            float alpha,
            float* A,
            int lda,
            float* B,
            int ldb,
            float beta,
            float* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_strmm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int M,
            int N,
            float alpha,
            float* A,
            int lda,
            float* B,
            int ldb);

        [DllImport(dllName)]
        public static extern void cblas_strsm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int M,
            int N,
            float alpha,
            float* A,
            int lda,
            float* B,
            int ldb);

        [DllImport(dllName)]
        public static extern void cblas_dgemm(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            CBLAS_TRANSPOSE TransB,
            int M,
            int N,
            int K,
            double alpha,
            double* A,
            int lda,
            double* B,
            int ldb,
            double beta,
            double* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_dgemm_batch(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE* TransA_Array,
            CBLAS_TRANSPOSE* TransB_Array,
            int* M_Array,
            int* N_Array,
            int* K_Array,
            double* alpha_Array,
            double** A_Array,
            int* lda_Array,
            double** B_Array,
            int* ldb_Array,
            double* beta_Array,
            double** C_Array,
            int* ldc_Array,
            int group_count,
            int* group_size);

        [DllImport(dllName)]
        public static extern void cblas_dgemmt(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_TRANSPOSE TransB,
            int N,
            int K,
            double alpha,
            double* A,
            int lda,
            double* B,
            int ldb,
            double beta,
            double* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_dsymm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            int M,
            int N,
            double alpha,
            double* A,
            int lda,
            double* B,
            int ldb,
            double beta,
            double* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_dsyrk(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE Trans,
            int N,
            int K,
            double alpha,
            double* A,
            int lda,
            double beta,
            double* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_dsyr2k(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE Trans,
            int N,
            int K,
            double alpha,
            double* A,
            int lda,
            double* B,
            int ldb,
            double beta,
            double* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_dtrmm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int M,
            int N,
            double alpha,
            double* A,
            int lda,
            double* B,
            int ldb);

        [DllImport(dllName)]
        public static extern void cblas_dtrsm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int M,
            int N,
            double alpha,
            double* A,
            int lda,
            double* B,
            int ldb);

        [DllImport(dllName)]
        public static extern void cblas_cgemm(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            CBLAS_TRANSPOSE TransB,
            int M,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_cgemm3m(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            CBLAS_TRANSPOSE TransB,
            int M,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_cgemm_batch(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE* TransA_Array,
            CBLAS_TRANSPOSE* TransB_Array,
            int* M_Array,
            int* N_Array,
            int* K_Array,
            void* alpha_Array,
            void** A_Array,
            int* lda_Array,
            void** B_Array,
            int* ldb_Array,
            void* beta_Array,
            void** C_Array,
            int* ldc_Array,
            int group_count,
            int* group_size);

        [DllImport(dllName)]
        public static extern void cblas_cgemm3m_batch(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE* TransA_Array,
            CBLAS_TRANSPOSE* TransB_Array,
            int* M_Array,
            int* N_Array,
            int* K_Array,
            void* alpha_Array,
            void** A_Array,
            int* lda_Array,
            void** B_Array,
            int* ldb_Array,
            void* beta_Array,
            void** C_Array,
            int* ldc_Array,
            int group_count,
            int* group_size);

        [DllImport(dllName)]
        public static extern void cblas_cgemmt(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_TRANSPOSE TransB,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_csymm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            int M,
            int N,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_csyrk(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE Trans,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_csyr2k(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE Trans,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_ctrmm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int M,
            int N,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb);

        [DllImport(dllName)]
        public static extern void cblas_ctrsm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int M,
            int N,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb);

        [DllImport(dllName)]
        public static extern void cblas_zgemm(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            CBLAS_TRANSPOSE TransB,
            int M,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_zgemm3m(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE TransA,
            CBLAS_TRANSPOSE TransB,
            int M,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_zgemm_batch(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE* TransA_Array,
            CBLAS_TRANSPOSE* TransB_Array,
            int* M_Array,
            int* N_Array,
            int* K_Array,
            void* alpha_Array,
            void** A_Array,
            int* lda_Array,
            void** B_Array,
            int* ldb_Array,
            void* beta_Array,
            void** C_Array,
            int* ldc_Array,
            int group_count,
            int* group_size);

        [DllImport(dllName)]
        public static extern void cblas_zgemm3m_batch(
            CBLAS_LAYOUT Layout,
            CBLAS_TRANSPOSE* TransA_Array,
            CBLAS_TRANSPOSE* TransB_Array,
            int* M_Array,
            int* N_Array,
            int* K_Array,
            void* alpha_Array,
            void** A_Array,
            int* lda_Array,
            void** B_Array,
            int* ldb_Array,
            void* beta_Array,
            void** C_Array,
            int* ldc_Array,
            int group_count,
            int* group_size);

        [DllImport(dllName)]
        public static extern void cblas_zgemmt(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_TRANSPOSE TransB,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_zsymm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            int M,
            int N,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_zsyrk(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE Trans,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_zsyr2k(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE Trans,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_ztrmm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int M,
            int N,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb);

        [DllImport(dllName)]
        public static extern void cblas_ztrsm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE TransA,
            CBLAS_DIAG Diag,
            int M,
            int N,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb);

        [DllImport(dllName)]
        public static extern void cblas_chemm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            int M,
            int N,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_cherk(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE Trans,
            int N,
            int K,
            float alpha,
            void* A,
            int lda,
            float beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_cher2k(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE Trans,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            float beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_zhemm(
            CBLAS_LAYOUT Layout,
            CBLAS_SIDE Side,
            CBLAS_UPLO Uplo,
            int M,
            int N,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            void* beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_zherk(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE Trans,
            int N,
            int K,
            double alpha,
            void* A,
            int lda,
            double beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_zher2k(
            CBLAS_LAYOUT Layout,
            CBLAS_UPLO Uplo,
            CBLAS_TRANSPOSE Trans,
            int N,
            int K,
            void* alpha,
            void* A,
            int lda,
            void* B,
            int ldb,
            double beta,
            void* C,
            int ldc);

        [DllImport(dllName)]
        public static extern float* cblas_sgemm_alloc(
            CBLAS_IDENTIFIER identifier,
            int M,
            int N,
            int K);

        [DllImport(dllName)]
        public static extern void cblas_sgemm_pack(
            CBLAS_LAYOUT Layout,
            CBLAS_IDENTIFIER identifier,
            CBLAS_TRANSPOSE Trans,
            int M,
            int N,
            int K,
            float alpha,
            float* src,
            int ld,
            float* dest);

        [DllImport(dllName)]
        public static extern void cblas_sgemm_compute(
            CBLAS_LAYOUT Layout,
            int TransA,
            int TransB,
            int M,
            int N,
            int K,
            float* A,
            int lda,
            float* B,
            int ldb,
            float beta,
            float* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_sgemm_free(
            float* dest);

        [DllImport(dllName)]
        public static extern double* cblas_dgemm_alloc(
            CBLAS_IDENTIFIER identifier,
            int M,
            int N,
            int K);

        [DllImport(dllName)]
        public static extern void cblas_dgemm_pack(
            CBLAS_LAYOUT Layout,
            CBLAS_IDENTIFIER identifier,
            CBLAS_TRANSPOSE Trans,
            int M,
            int N,
            int K,
            double alpha,
            double* src,
            int ld,
            double* dest);

        [DllImport(dllName)]
        public static extern void cblas_dgemm_compute(
            CBLAS_LAYOUT Layout,
            int TransA,
            int TransB,
            int M,
            int N,
            int K,
            double* A,
            int lda,
            double* B,
            int ldb,
            double beta,
            double* C,
            int ldc);

        [DllImport(dllName)]
        public static extern void cblas_dgemm_free(
            double* dest);
    }
}
