using System;
using Core.Diagnostics;
using MathKernel.Resources;

namespace MathKernel.LinearAlgebra
{
    public static unsafe partial class BLAS
    {
        #region Level 1

        #region asum

        private static float asum(VectorDescriptor descriptor, float* x)
        {
            return NativeMethods.cblas_sasum(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static float asum(VectorDescriptor descriptor, complexf* x)
        {
            return NativeMethods.cblas_scasum(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static double asum(VectorDescriptor descriptor, double* x)
        {
            return NativeMethods.cblas_dasum(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static double asum(VectorDescriptor descriptor, complex* x)
        {
            return NativeMethods.cblas_dzasum(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        #endregion

        #region axpy

        private static void axpy(
            float a,
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            NativeMethods.cblas_saxpy(
                xDescriptor.Size,
                a,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void axpy(
            double a,
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y)
        {
            NativeMethods.cblas_daxpy(
                xDescriptor.Size,
                a,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void axpy(
            complexf a,
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            NativeMethods.cblas_caxpy(
                xDescriptor.Size,
                &a,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void axpy(
            complex a,
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            NativeMethods.cblas_zaxpy(
                xDescriptor.Size,
                &a,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        #endregion

        #region copy

        private static void copy(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            NativeMethods.cblas_scopy(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void copy(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y)
        {
            NativeMethods.cblas_dcopy(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void copy(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            NativeMethods.cblas_ccopy(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void copy(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            NativeMethods.cblas_zcopy(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        #endregion

        #region dot

        private static float dot(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            return NativeMethods.cblas_sdot(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static double dot(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y)
        {
            return NativeMethods.cblas_ddot(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        #endregion

        #region sdot

        private static float sdot(
            float b,
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            return NativeMethods.cblas_sdsdot(
                xDescriptor.Size,
                b,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        /// <summary>
        /// (float)Sum(i => (double)x[i] * (double)y[i]) + b.
        /// </summary>
        [CLSCompliant(false)]
        public static float SDot(
            float b,
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            return sdot(b, xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// (float)Sum(i => (double)x[i] * (double)y[i]) + b.
        /// </summary>
        public static float SDot(float b, Vector<float> x, Vector<float> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                return sdot(b, x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        private static double sdot(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            return NativeMethods.cblas_dsdot(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        /// <summary>
        /// Sum(i => (double)x[i] * (double)y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static double SDot(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            return sdot(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => (double)x[i] * (double)y[i]).
        /// </summary>
        public static double SDot(Vector<float> x, Vector<float> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                return sdot(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        #endregion

        #region dotc

        private static complexf dotc(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            complexf result;
            NativeMethods.cblas_cdotc_sub(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride,
                &result);
            return result;
        }

        private static complex dotc(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            complex result;
            NativeMethods.cblas_zdotc_sub(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride,
                &result);
            return result;
        }

        #endregion

        #region dotu

        private static complexf dotu(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            complexf result;
            NativeMethods.cblas_cdotu_sub(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride,
                &result);
            return result;
        }

        private static complex dotu(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            complex result;
            NativeMethods.cblas_zdotu_sub(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride,
                &result);
            return result;
        }

        #endregion

        #region nrm2

        private static float nrm2(VectorDescriptor descriptor, float* x)
        {
            return NativeMethods.cblas_snrm2(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static double nrm2(VectorDescriptor descriptor, double* x)
        {
            return NativeMethods.cblas_dnrm2(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static float nrm2(VectorDescriptor descriptor, complexf* x)
        {
            return NativeMethods.cblas_scnrm2(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static double nrm2(VectorDescriptor descriptor, complex* x)
        {
            return NativeMethods.cblas_dznrm2(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        #endregion

        #region rot

        private static void rot(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y,
            float c, float s)
        {
            NativeMethods.cblas_srot(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride,
                c, s);
        }

        private static void rot(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y,
            double c, double s)
        {
            NativeMethods.cblas_drot(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride,
                c, s);
        }

        private static void rot(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y,
            float c, float s)
        {
            NativeMethods.cblas_csrot(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride,
                c, s);
        }

        private static void rot(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y,
            double c, double s)
        {
            NativeMethods.cblas_zdrot(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride,
                c, s);
        }

        #endregion

        #region rotm

        private static void rotm(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y,
            float h11, float h12, float h21, float h22)
        {
            var h = stackalloc float[5];
            h[1] = h11;
            h[2] = h21;
            h[3] = h12;
            h[4] = h22;
            if (h11 == 1 && h22 == 1)
            {
                if (h12 == 0 && h21 == 0)
                {
                    h[0] = -2;
                }
                else
                {
                    h[0] = 0;
                }
            }
            else if (h12 == 1 && h21 == -1)
            {
                h[0] = 1;
            }
            else
            {
                h[0] = -1;
            }

            NativeMethods.cblas_srotm(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride,
                h);
        }

        private static void rotm(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y,
            double h11, double h12, double h21, double h22)
        {
            var h = stackalloc double[5];
            h[1] = h11;
            h[2] = h21;
            h[3] = h12;
            h[4] = h22;
            if (h11 == 1 && h22 == 1)
            {
                if (h12 == 0 && h21 == 0)
                {
                    h[0] = -2;
                }
                else
                {
                    h[0] = 0;
                }
            }
            else if (h12 == 1 && h21 == -1)
            {
                h[0] = 1;
            }
            else
            {
                h[0] = -1;
            }

            NativeMethods.cblas_drotm(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride,
                h);
        }

        #endregion

        #region scal

        private static void scal(float a, VectorDescriptor descriptor, float* x)
        {
            NativeMethods.cblas_sscal(
                descriptor.Size,
                a,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static void scal(double a, VectorDescriptor descriptor, double* x)
        {
            NativeMethods.cblas_dscal(
                descriptor.Size,
                a,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static void scal(complexf a, VectorDescriptor descriptor, complexf* x)
        {
            NativeMethods.cblas_cscal(
                descriptor.Size,
                &a,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static void scal(complex a, VectorDescriptor descriptor, complex* x)
        {
            NativeMethods.cblas_zscal(
                descriptor.Size,
                &a,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static void scal(float a, VectorDescriptor descriptor, complexf* x)
        {
            NativeMethods.cblas_csscal(
                descriptor.Size,
                a,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static void scal(double a, VectorDescriptor descriptor, complex* x)
        {
            NativeMethods.cblas_zdscal(
                descriptor.Size,
                a,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        #endregion

        #region swap

        private static void swap(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            NativeMethods.cblas_sswap(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void swap(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y)
        {
            NativeMethods.cblas_dswap(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void swap(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            NativeMethods.cblas_cswap(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void swap(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            NativeMethods.cblas_zswap(
                xDescriptor.Size,
                x + xDescriptor.Offset, xDescriptor.Stride,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        #endregion

        #region iamax

        private static int iamax(VectorDescriptor descriptor, float* x)
        {
            return (int)NativeMethods.cblas_isamax(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static int iamax(VectorDescriptor descriptor, double* x)
        {
            return (int)NativeMethods.cblas_idamax(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static int iamax(VectorDescriptor descriptor, complexf* x)
        {
            return (int)NativeMethods.cblas_icamax(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static int iamax(VectorDescriptor descriptor, complex* x)
        {
            return (int)NativeMethods.cblas_izamax(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        #endregion

        #region iamin

        private static int iamin(VectorDescriptor descriptor, float* x)
        {
            return (int)NativeMethods.cblas_isamin(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static int iamin(VectorDescriptor descriptor, double* x)
        {
            return (int)NativeMethods.cblas_idamin(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static int iamin(VectorDescriptor descriptor, complexf* x)
        {
            return (int)NativeMethods.cblas_icamin(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        private static int iamin(VectorDescriptor descriptor, complex* x)
        {
            return (int)NativeMethods.cblas_izamin(
                descriptor.Size,
                x + descriptor.Offset,
                descriptor.Stride);
        }

        #endregion

        #endregion

        #region Level 2

        #region gbmv

        private static void gbmv(
            float alpha,
            BandMatrixDescriptor ADescriptor, float* A,
            VectorDescriptor xDescriptor, float* x,
            float beta,
            VectorDescriptor yDescriptor, float* y)
        {
            CBLAS_TRANSPOSE trans;
            if (ADescriptor.IsConjugated)
            {
                trans = CBLAS_TRANSPOSE.CblasConjTrans;
                ADescriptor = ADescriptor.Transpose();
            }
            else
            {
                trans = CBLAS_TRANSPOSE.CblasNoTrans;
            }
            NativeMethods.cblas_sgbmv(
                (CBLAS_LAYOUT)ADescriptor.Layout,
                trans,
                ADescriptor.Rows, ADescriptor.Columns,
                ADescriptor.LowerBandwidth, ADescriptor.UpperBandwidth,
                alpha,
                A + ADescriptor.Offset, ADescriptor.Stride,
                x + xDescriptor.Offset, xDescriptor.Stride,
                beta,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void gbmv(
           double alpha,
           BandMatrixDescriptor ADescriptor, double* A,
           VectorDescriptor xDescriptor, double* x,
           double beta,
           VectorDescriptor yDescriptor, double* y)
        {
            CBLAS_TRANSPOSE trans;
            if (ADescriptor.IsConjugated)
            {
                trans = CBLAS_TRANSPOSE.CblasConjTrans;
                ADescriptor = ADescriptor.Transpose();
            }
            else
            {
                trans = CBLAS_TRANSPOSE.CblasNoTrans;
            }
            NativeMethods.cblas_dgbmv(
                (CBLAS_LAYOUT)ADescriptor.Layout,
                trans,
                ADescriptor.Rows, ADescriptor.Columns,
                ADescriptor.LowerBandwidth, ADescriptor.UpperBandwidth,
                alpha,
                A + ADescriptor.Offset, ADescriptor.Stride,
                x + xDescriptor.Offset, xDescriptor.Stride,
                beta,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void gbmv(
           complexf alpha,
           BandMatrixDescriptor ADescriptor, complexf* A,
           VectorDescriptor xDescriptor, complexf* x,
           complexf beta,
           VectorDescriptor yDescriptor, complexf* y)
        {
            CBLAS_TRANSPOSE trans;
            if (ADescriptor.IsConjugated)
            {
                trans = CBLAS_TRANSPOSE.CblasConjTrans;
                ADescriptor = ADescriptor.Transpose();
            }
            else
            {
                trans = CBLAS_TRANSPOSE.CblasNoTrans;
            }
            NativeMethods.cblas_cgbmv(
                (CBLAS_LAYOUT)ADescriptor.Layout,
                trans,
                ADescriptor.Rows, ADescriptor.Columns,
                ADescriptor.LowerBandwidth, ADescriptor.UpperBandwidth,
                &alpha,
                A + ADescriptor.Offset, ADescriptor.Stride,
                x + xDescriptor.Offset, xDescriptor.Stride,
                &beta,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void gbmv(
           complex alpha,
           BandMatrixDescriptor ADescriptor, complex* A,
           VectorDescriptor xDescriptor, complex* x,
           complex beta,
           VectorDescriptor yDescriptor, complex* y)
        {
            CBLAS_TRANSPOSE trans;
            if (ADescriptor.IsConjugated)
            {
                trans = CBLAS_TRANSPOSE.CblasConjTrans;
                ADescriptor = ADescriptor.Transpose();
            }
            else
            {
                trans = CBLAS_TRANSPOSE.CblasNoTrans;
            }
            NativeMethods.cblas_zgbmv(
                (CBLAS_LAYOUT)ADescriptor.Layout,
                trans,
                ADescriptor.Rows, ADescriptor.Columns,
                ADescriptor.LowerBandwidth, ADescriptor.UpperBandwidth,
                &alpha,
                A + ADescriptor.Offset, ADescriptor.Stride,
                x + xDescriptor.Offset, xDescriptor.Stride,
                &beta,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        #endregion

        #region gemv

        private static void gemv(
            float alpha,
            MatrixDescriptor ADescriptor, float* A,
            VectorDescriptor xDescriptor, float* x,
            float beta,
            VectorDescriptor yDescriptor, float* y)
        {
            CBLAS_TRANSPOSE trans;
            if (ADescriptor.IsConjugated)
            {
                trans = CBLAS_TRANSPOSE.CblasConjTrans;
                ADescriptor = ADescriptor.Transpose();
            }
            else
            {
                trans = CBLAS_TRANSPOSE.CblasNoTrans;
            }
            NativeMethods.cblas_sgemv(
                (CBLAS_LAYOUT)ADescriptor.Layout,
                trans,
                ADescriptor.Rows, ADescriptor.Columns,
                alpha,
                A + ADescriptor.Offset, ADescriptor.Stride,
                x + xDescriptor.Offset, xDescriptor.Stride,
                beta,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void gemv(
            double alpha,
            MatrixDescriptor ADescriptor, double* A,
            VectorDescriptor xDescriptor, double* x,
            double beta,
            VectorDescriptor yDescriptor, double* y)
        {
            CBLAS_TRANSPOSE trans;
            if (ADescriptor.IsConjugated)
            {
                trans = CBLAS_TRANSPOSE.CblasConjTrans;
                ADescriptor = ADescriptor.Transpose();
            }
            else
            {
                trans = CBLAS_TRANSPOSE.CblasNoTrans;
            }
            NativeMethods.cblas_dgemv(
                (CBLAS_LAYOUT)ADescriptor.Layout,
                trans,
                ADescriptor.Rows, ADescriptor.Columns,
                alpha,
                A + ADescriptor.Offset, ADescriptor.Stride,
                x + xDescriptor.Offset, xDescriptor.Stride,
                beta,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void gemv(
            complexf alpha,
            MatrixDescriptor ADescriptor, complexf* A,
            VectorDescriptor xDescriptor, complexf* x,
            complexf beta,
            VectorDescriptor yDescriptor, complexf* y)
        {
            CBLAS_TRANSPOSE trans;
            if (ADescriptor.IsConjugated)
            {
                trans = CBLAS_TRANSPOSE.CblasConjTrans;
                ADescriptor = ADescriptor.Transpose();
            }
            else
            {
                trans = CBLAS_TRANSPOSE.CblasNoTrans;
            }
            NativeMethods.cblas_cgemv(
                (CBLAS_LAYOUT)ADescriptor.Layout,
                trans,
                ADescriptor.Rows, ADescriptor.Columns,
                &alpha,
                A + ADescriptor.Offset, ADescriptor.Stride,
                x + xDescriptor.Offset, xDescriptor.Stride,
                &beta,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        private static void gemv(
            complex alpha,
            MatrixDescriptor ADescriptor, complex* A,
            VectorDescriptor xDescriptor, complex* x,
            complex beta,
            VectorDescriptor yDescriptor, complex* y)
        {
            CBLAS_TRANSPOSE trans;
            if (ADescriptor.IsConjugated)
            {
                trans = CBLAS_TRANSPOSE.CblasConjTrans;
                ADescriptor = ADescriptor.Transpose();
            }
            else
            {
                trans = CBLAS_TRANSPOSE.CblasNoTrans;
            }
            NativeMethods.cblas_zgemv(
                (CBLAS_LAYOUT)ADescriptor.Layout,
                trans,
                ADescriptor.Rows, ADescriptor.Columns,
                &alpha,
                A + ADescriptor.Offset, ADescriptor.Stride,
                x + xDescriptor.Offset, xDescriptor.Stride,
                &beta,
                y + yDescriptor.Offset, yDescriptor.Stride);
        }

        #endregion

        #endregion
    }

    [Duplicate(typeof(float))]
    public static unsafe partial class BLAS
    {
        #region Level 1

        /// <summary>
        /// y = a * x + y.
        /// </summary>
        [CLSCompliant(false)]
        public static void AXPY(
            float a,
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            axpy(a, xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = a * x + y.
        /// </summary>
        public static void AXPY(float a, Vector<float> x, Vector<float> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                axpy(a, x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// y = x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Copy(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            copy(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = x.
        /// </summary>
        public static void Copy(Vector<float> x, Vector<float> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                copy(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Scale(float a, VectorDescriptor descriptor, float* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            scal(a, descriptor, x);
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        public static void Scale(float a, Vector<float> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (float* xPtr = x.Storage)
            {
                scal(a, x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// (x, y) = (y, x).
        /// </summary>
        [CLSCompliant(false)]
        public static void Swap(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            swap(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// (x, y) = (y, x).
        /// </summary>
        public static void Swap(Vector<float> x, Vector<float> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                swap(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// x.IndexOf(Max(Abs(x))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMax(VectorDescriptor descriptor, float* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamax(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Max(Abs(x))).
        /// </summary>
        public static int IAMax(Vector<float> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (float* xPtr = x.Storage)
            {
                return iamax(x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// x.IndexOf(Min(Abs(x))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMin(VectorDescriptor descriptor, float* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamin(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Min(Abs(x))).
        /// </summary>
        public static int IAMin(Vector<float> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (float* xPtr = x.Storage)
            {
                return iamin(x.Descriptor, xPtr);
            }
        }

        #endregion

        #region Level 2

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        [CLSCompliant(false)]
        public static void GBMV(
            float alpha,
            BandMatrixDescriptor ADescriptor, float* A,
            VectorDescriptor xDescriptor, float* x,
            float beta,
            VectorDescriptor yDescriptor, float* y)
        {
            Requires.NotNull(ADescriptor, nameof(ADescriptor));
            Requires.NotNullPtr(A, nameof(A));
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));

            gbmv(alpha, ADescriptor, A, xDescriptor, x, beta, yDescriptor, y);
        }

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        public static void GBMV(
            float alpha,
            BandMatrix<float> A,
            Vector<float> x,
            float beta,
            Vector<float> y)
        {
            Requires.NotNull(A, nameof(A));
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));

            fixed (float* APtr = A.Storage, xPtr = x.Storage, yPtr = y.Storage)
            {
                gbmv(alpha, A.Descriptor, APtr, x.Descriptor, xPtr, beta, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        [CLSCompliant(false)]
        public static void GEMV(
            float alpha,
            MatrixDescriptor ADescriptor, float* A,
            VectorDescriptor xDescriptor, float* x,
            float beta,
            VectorDescriptor yDescriptor, float* y)
        {
            Requires.NotNull(ADescriptor, nameof(ADescriptor));
            Requires.NotNullPtr(A, nameof(A));
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));

            gemv(alpha, ADescriptor, A, xDescriptor, x, beta, yDescriptor, y);
        }

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        public static void GEMV(
            float alpha,
            Matrix<float> A,
            Vector<float> x,
            float beta,
            Vector<float> y)
        {
            Requires.NotNull(A, nameof(A));
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));

            fixed (float* APtr = A.Storage, xPtr = x.Storage, yPtr = y.Storage)
            {
                gemv(alpha, A.Descriptor, APtr, x.Descriptor, xPtr, beta, y.Descriptor, yPtr);
            }
        }

        #endregion
    }

    [Duplicate(typeof(complexf))]
    public static unsafe partial class BLAS
    {
        #region Level 1

        /// <summary>
        /// y = a * x + y.
        /// </summary>
        [CLSCompliant(false)]
        public static void AXPY(
            complexf a,
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            axpy(a, xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = a * x + y.
        /// </summary>
        public static void AXPY(complexf a, Vector<complexf> x, Vector<complexf> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complexf* xPtr = x.Storage, yPtr = y.Storage)
            {
                axpy(a, x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// y = x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Copy(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            copy(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = x.
        /// </summary>
        public static void Copy(Vector<complexf> x, Vector<complexf> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complexf* xPtr = x.Storage, yPtr = y.Storage)
            {
                copy(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Scale(complexf a, VectorDescriptor descriptor, complexf* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            scal(a, descriptor, x);
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        public static void Scale(complexf a, Vector<complexf> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complexf* xPtr = x.Storage)
            {
                scal(a, x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// (x, y) = (y, x).
        /// </summary>
        [CLSCompliant(false)]
        public static void Swap(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            swap(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// (x, y) = (y, x).
        /// </summary>
        public static void Swap(Vector<complexf> x, Vector<complexf> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complexf* xPtr = x.Storage, yPtr = y.Storage)
            {
                swap(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// x.IndexOf(Max(Abs(x))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMax(VectorDescriptor descriptor, complexf* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamax(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Max(Abs(x))).
        /// </summary>
        public static int IAMax(Vector<complexf> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complexf* xPtr = x.Storage)
            {
                return iamax(x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// x.IndexOf(Min(Abs(x))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMin(VectorDescriptor descriptor, complexf* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamin(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Min(Abs(x))).
        /// </summary>
        public static int IAMin(Vector<complexf> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complexf* xPtr = x.Storage)
            {
                return iamin(x.Descriptor, xPtr);
            }
        }

        #endregion

        #region Level 2

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        [CLSCompliant(false)]
        public static void GBMV(
            complexf alpha,
            BandMatrixDescriptor ADescriptor, complexf* A,
            VectorDescriptor xDescriptor, complexf* x,
            complexf beta,
            VectorDescriptor yDescriptor, complexf* y)
        {
            Requires.NotNull(ADescriptor, nameof(ADescriptor));
            Requires.NotNullPtr(A, nameof(A));
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));

            gbmv(alpha, ADescriptor, A, xDescriptor, x, beta, yDescriptor, y);
        }

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        public static void GBMV(
            complexf alpha,
            BandMatrix<complexf> A,
            Vector<complexf> x,
            complexf beta,
            Vector<complexf> y)
        {
            Requires.NotNull(A, nameof(A));
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));

            fixed (complexf* APtr = A.Storage, xPtr = x.Storage, yPtr = y.Storage)
            {
                gbmv(alpha, A.Descriptor, APtr, x.Descriptor, xPtr, beta, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        [CLSCompliant(false)]
        public static void GEMV(
            complexf alpha,
            MatrixDescriptor ADescriptor, complexf* A,
            VectorDescriptor xDescriptor, complexf* x,
            complexf beta,
            VectorDescriptor yDescriptor, complexf* y)
        {
            Requires.NotNull(ADescriptor, nameof(ADescriptor));
            Requires.NotNullPtr(A, nameof(A));
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));

            gemv(alpha, ADescriptor, A, xDescriptor, x, beta, yDescriptor, y);
        }

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        public static void GEMV(
            complexf alpha,
            Matrix<complexf> A,
            Vector<complexf> x,
            complexf beta,
            Vector<complexf> y)
        {
            Requires.NotNull(A, nameof(A));
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));

            fixed (complexf* APtr = A.Storage, xPtr = x.Storage, yPtr = y.Storage)
            {
                gemv(alpha, A.Descriptor, APtr, x.Descriptor, xPtr, beta, y.Descriptor, yPtr);
            }
        }

        #endregion
    }

    [Duplicate(typeof(double))]
    public static unsafe partial class BLAS
    {
        #region Level 1

        /// <summary>
        /// y = a * x + y.
        /// </summary>
        [CLSCompliant(false)]
        public static void AXPY(
            double a,
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            axpy(a, xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = a * x + y.
        /// </summary>
        public static void AXPY(double a, Vector<double> x, Vector<double> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (double* xPtr = x.Storage, yPtr = y.Storage)
            {
                axpy(a, x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// y = x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Copy(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            copy(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = x.
        /// </summary>
        public static void Copy(Vector<double> x, Vector<double> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (double* xPtr = x.Storage, yPtr = y.Storage)
            {
                copy(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Scale(double a, VectorDescriptor descriptor, double* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            scal(a, descriptor, x);
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        public static void Scale(double a, Vector<double> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (double* xPtr = x.Storage)
            {
                scal(a, x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// (x, y) = (y, x).
        /// </summary>
        [CLSCompliant(false)]
        public static void Swap(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            swap(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// (x, y) = (y, x).
        /// </summary>
        public static void Swap(Vector<double> x, Vector<double> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (double* xPtr = x.Storage, yPtr = y.Storage)
            {
                swap(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// x.IndexOf(Max(Abs(x))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMax(VectorDescriptor descriptor, double* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamax(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Max(Abs(x))).
        /// </summary>
        public static int IAMax(Vector<double> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (double* xPtr = x.Storage)
            {
                return iamax(x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// x.IndexOf(Min(Abs(x))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMin(VectorDescriptor descriptor, double* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamin(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Min(Abs(x))).
        /// </summary>
        public static int IAMin(Vector<double> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (double* xPtr = x.Storage)
            {
                return iamin(x.Descriptor, xPtr);
            }
        }

        #endregion

        #region Level 2

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        [CLSCompliant(false)]
        public static void GBMV(
            double alpha,
            BandMatrixDescriptor ADescriptor, double* A,
            VectorDescriptor xDescriptor, double* x,
            double beta,
            VectorDescriptor yDescriptor, double* y)
        {
            Requires.NotNull(ADescriptor, nameof(ADescriptor));
            Requires.NotNullPtr(A, nameof(A));
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));

            gbmv(alpha, ADescriptor, A, xDescriptor, x, beta, yDescriptor, y);
        }

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        public static void GBMV(
            double alpha,
            BandMatrix<double> A,
            Vector<double> x,
            double beta,
            Vector<double> y)
        {
            Requires.NotNull(A, nameof(A));
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));

            fixed (double* APtr = A.Storage, xPtr = x.Storage, yPtr = y.Storage)
            {
                gbmv(alpha, A.Descriptor, APtr, x.Descriptor, xPtr, beta, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        [CLSCompliant(false)]
        public static void GEMV(
            double alpha,
            MatrixDescriptor ADescriptor, double* A,
            VectorDescriptor xDescriptor, double* x,
            double beta,
            VectorDescriptor yDescriptor, double* y)
        {
            Requires.NotNull(ADescriptor, nameof(ADescriptor));
            Requires.NotNullPtr(A, nameof(A));
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));

            gemv(alpha, ADescriptor, A, xDescriptor, x, beta, yDescriptor, y);
        }

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        public static void GEMV(
            double alpha,
            Matrix<double> A,
            Vector<double> x,
            double beta,
            Vector<double> y)
        {
            Requires.NotNull(A, nameof(A));
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));

            fixed (double* APtr = A.Storage, xPtr = x.Storage, yPtr = y.Storage)
            {
                gemv(alpha, A.Descriptor, APtr, x.Descriptor, xPtr, beta, y.Descriptor, yPtr);
            }
        }

        #endregion
    }

    [Duplicate(typeof(complex))]
    public static unsafe partial class BLAS
    {
        #region Level 1

        /// <summary>
        /// y = a * x + y.
        /// </summary>
        [CLSCompliant(false)]
        public static void AXPY(
            complex a,
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            axpy(a, xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = a * x + y.
        /// </summary>
        public static void AXPY(complex a, Vector<complex> x, Vector<complex> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complex* xPtr = x.Storage, yPtr = y.Storage)
            {
                axpy(a, x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// y = x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Copy(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            copy(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// y = x.
        /// </summary>
        public static void Copy(Vector<complex> x, Vector<complex> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complex* xPtr = x.Storage, yPtr = y.Storage)
            {
                copy(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Scale(complex a, VectorDescriptor descriptor, complex* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            scal(a, descriptor, x);
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        public static void Scale(complex a, Vector<complex> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complex* xPtr = x.Storage)
            {
                scal(a, x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// (x, y) = (y, x).
        /// </summary>
        [CLSCompliant(false)]
        public static void Swap(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            swap(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// (x, y) = (y, x).
        /// </summary>
        public static void Swap(Vector<complex> x, Vector<complex> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complex* xPtr = x.Storage, yPtr = y.Storage)
            {
                swap(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// x.IndexOf(Max(Abs(x))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMax(VectorDescriptor descriptor, complex* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamax(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Max(Abs(x))).
        /// </summary>
        public static int IAMax(Vector<complex> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complex* xPtr = x.Storage)
            {
                return iamax(x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// x.IndexOf(Min(Abs(x))).
        /// </summary>
        [CLSCompliant(false)]
        public static int IAMin(VectorDescriptor descriptor, complex* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return iamin(descriptor, x);
        }

        /// <summary>
        /// x.IndexOf(Min(Abs(x))).
        /// </summary>
        public static int IAMin(Vector<complex> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complex* xPtr = x.Storage)
            {
                return iamin(x.Descriptor, xPtr);
            }
        }

        #endregion

        #region Level 2

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        [CLSCompliant(false)]
        public static void GBMV(
            complex alpha,
            BandMatrixDescriptor ADescriptor, complex* A,
            VectorDescriptor xDescriptor, complex* x,
            complex beta,
            VectorDescriptor yDescriptor, complex* y)
        {
            Requires.NotNull(ADescriptor, nameof(ADescriptor));
            Requires.NotNullPtr(A, nameof(A));
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));

            gbmv(alpha, ADescriptor, A, xDescriptor, x, beta, yDescriptor, y);
        }

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        public static void GBMV(
            complex alpha,
            BandMatrix<complex> A,
            Vector<complex> x,
            complex beta,
            Vector<complex> y)
        {
            Requires.NotNull(A, nameof(A));
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));

            fixed (complex* APtr = A.Storage, xPtr = x.Storage, yPtr = y.Storage)
            {
                gbmv(alpha, A.Descriptor, APtr, x.Descriptor, xPtr, beta, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        [CLSCompliant(false)]
        public static void GEMV(
            complex alpha,
            MatrixDescriptor ADescriptor, complex* A,
            VectorDescriptor xDescriptor, complex* x,
            complex beta,
            VectorDescriptor yDescriptor, complex* y)
        {
            Requires.NotNull(ADescriptor, nameof(ADescriptor));
            Requires.NotNullPtr(A, nameof(A));
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));

            gemv(alpha, ADescriptor, A, xDescriptor, x, beta, yDescriptor, y);
        }

        /// <summary>
        /// y = alpha * A * x + beta * y.
        /// </summary>
        public static void GEMV(
            complex alpha,
            Matrix<complex> A,
            Vector<complex> x,
            complex beta,
            Vector<complex> y)
        {
            Requires.NotNull(A, nameof(A));
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));

            fixed (complex* APtr = A.Storage, xPtr = x.Storage, yPtr = y.Storage)
            {
                gemv(alpha, A.Descriptor, APtr, x.Descriptor, xPtr, beta, y.Descriptor, yPtr);
            }
        }

        #endregion
    }

    [RealTypeDuplicate(typeof(float))]
    public static unsafe partial class BLAS
    {
        /// <summary>
        /// Sum(Abs(x)).
        /// </summary>
        [CLSCompliant(false)]
        public static float ASum(VectorDescriptor descriptor, float* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return asum(descriptor, x);
        }

        /// <summary>
        /// Sum(Abs(x)).
        /// </summary>
        public static float ASum(Vector<float> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (float* xPtr = x.Storage)
            {
                return asum(x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static float Dot(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            return dot(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        public static float Dot(Vector<float> x, Vector<float> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dot(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// Sqrt(Sum(i => x[i] * x[i])).
        /// </summary>
        [CLSCompliant(false)]
        public static float Norm2(VectorDescriptor descriptor, float* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return nrm2(descriptor, x);
        }

        /// <summary>
        /// Sqrt(Sum(i => x[i] * x[i])).
        /// </summary>
        public static float Norm2(Vector<float> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (float* xPtr = x.Storage)
            {
                return nrm2(x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        [CLSCompliant(false)]
        public static void Rotate(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y,
            float c, float s)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            rot(xDescriptor, x, yDescriptor, y, c, s);
        }

        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        public static void Rotate(Vector<float> x, Vector<float> y, float c, float s)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                rot(x.Descriptor, xPtr, y.Descriptor, yPtr, c, s);
            }
        }

        /// <summary>
        /// (x, y) = ((h11 * x + h12 * y), (h21 * x + h22 * y)).
        /// </summary>
        [CLSCompliant(false)]
        public static void Rotate(
            VectorDescriptor xDescriptor, float* x,
            VectorDescriptor yDescriptor, float* y,
            float h11, float h12, float h21, float h22)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            rotm(xDescriptor, x, yDescriptor, y, h11, h12, h21, h22);
        }

        /// <summary>
        /// (x, y) = ((h11 * x + h12 * y), (h21 * x + h22 * y)).
        /// </summary>
        public static void Rotate(
            Vector<float> x, Vector<float> y,
            float h11, float h12, float h21, float h22)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (float* xPtr = x.Storage, yPtr = y.Storage)
            {
                rotm(x.Descriptor, xPtr, y.Descriptor, yPtr, h11, h12, h21, h22);
            }
        }
    }

    [RealTypeDuplicate(typeof(double))]
    public static unsafe partial class BLAS
    {
        /// <summary>
        /// Sum(Abs(x)).
        /// </summary>
        [CLSCompliant(false)]
        public static double ASum(VectorDescriptor descriptor, double* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return asum(descriptor, x);
        }

        /// <summary>
        /// Sum(Abs(x)).
        /// </summary>
        public static double ASum(Vector<double> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (double* xPtr = x.Storage)
            {
                return asum(x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static double Dot(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            return dot(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        public static double Dot(Vector<double> x, Vector<double> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (double* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dot(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// Sqrt(Sum(i => x[i] * x[i])).
        /// </summary>
        [CLSCompliant(false)]
        public static double Norm2(VectorDescriptor descriptor, double* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return nrm2(descriptor, x);
        }

        /// <summary>
        /// Sqrt(Sum(i => x[i] * x[i])).
        /// </summary>
        public static double Norm2(Vector<double> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (double* xPtr = x.Storage)
            {
                return nrm2(x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        [CLSCompliant(false)]
        public static void Rotate(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y,
            double c, double s)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            rot(xDescriptor, x, yDescriptor, y, c, s);
        }

        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        public static void Rotate(Vector<double> x, Vector<double> y, double c, double s)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (double* xPtr = x.Storage, yPtr = y.Storage)
            {
                rot(x.Descriptor, xPtr, y.Descriptor, yPtr, c, s);
            }
        }

        /// <summary>
        /// (x, y) = ((h11 * x + h12 * y), (h21 * x + h22 * y)).
        /// </summary>
        [CLSCompliant(false)]
        public static void Rotate(
            VectorDescriptor xDescriptor, double* x,
            VectorDescriptor yDescriptor, double* y,
            double h11, double h12, double h21, double h22)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            rotm(xDescriptor, x, yDescriptor, y, h11, h12, h21, h22);
        }

        /// <summary>
        /// (x, y) = ((h11 * x + h12 * y), (h21 * x + h22 * y)).
        /// </summary>
        public static void Rotate(
            Vector<double> x, Vector<double> y,
            double h11, double h12, double h21, double h22)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (double* xPtr = x.Storage, yPtr = y.Storage)
            {
                rotm(x.Descriptor, xPtr, y.Descriptor, yPtr, h11, h12, h21, h22);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complexf))]
    public static unsafe partial class BLAS
    {
        /// <summary>
        /// Sum(Abs(x)).
        /// </summary>
        [CLSCompliant(false)]
        public static float ASum(VectorDescriptor descriptor, complexf* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return asum(descriptor, x);
        }

        /// <summary>
        /// Sum(Abs(x)).
        /// </summary>
        public static float ASum(Vector<complexf> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complexf* xPtr = x.Storage)
            {
                return asum(x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// Sum(i => Conjugate(x[i]) * y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static complexf DotC(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            return dotc(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => Conjugate(x[i]) * y[i]).
        /// </summary>
        public static complexf DotC(Vector<complexf> x, Vector<complexf> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complexf* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dotc(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static complexf DotU(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            return dotu(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        public static complexf DotU(Vector<complexf> x, Vector<complexf> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complexf* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dotu(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// Sqrt(Sum(i => Conjugate(x[i]) * x[i])).
        /// </summary>
        [CLSCompliant(false)]
        public static float Norm2(VectorDescriptor descriptor, complexf* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return nrm2(descriptor, x);
        }

        /// <summary>
        /// Sqrt(Sum(i => Conjugate(x[i]) * x[i])).
        /// </summary>
        public static float Norm2(Vector<complexf> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complexf* xPtr = x.Storage)
            {
                return nrm2(x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        [CLSCompliant(false)]
        public static void Rotate(
            VectorDescriptor xDescriptor, complexf* x,
            VectorDescriptor yDescriptor, complexf* y,
            float c, float s)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            rot(xDescriptor, x, yDescriptor, y, c, s);
        }

        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        public static void Rotate(Vector<complexf> x, Vector<complexf> y, float c, float s)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complexf* xPtr = x.Storage, yPtr = y.Storage)
            {
                rot(x.Descriptor, xPtr, y.Descriptor, yPtr, c, s);
            }
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Scale(float a, VectorDescriptor descriptor, complexf* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            scal(a, descriptor, x);
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        public static void Scale(float a, Vector<complexf> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complexf* xPtr = x.Storage)
            {
                scal(a, x.Descriptor, xPtr);
            }
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public static unsafe partial class BLAS
    {
        /// <summary>
        /// Sum(Abs(x)).
        /// </summary>
        [CLSCompliant(false)]
        public static double ASum(VectorDescriptor descriptor, complex* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return asum(descriptor, x);
        }

        /// <summary>
        /// Sum(Abs(x)).
        /// </summary>
        public static double ASum(Vector<complex> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complex* xPtr = x.Storage)
            {
                return asum(x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// Sum(i => Conjugate(x[i]) * y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static complex DotC(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            return dotc(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => Conjugate(x[i]) * y[i]).
        /// </summary>
        public static complex DotC(Vector<complex> x, Vector<complex> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complex* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dotc(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        [CLSCompliant(false)]
        public static complex DotU(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            return dotu(xDescriptor, x, yDescriptor, y);
        }

        /// <summary>
        /// Sum(i => x[i] * y[i]).
        /// </summary>
        public static complex DotU(Vector<complex> x, Vector<complex> y)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complex* xPtr = x.Storage, yPtr = y.Storage)
            {
                return dotu(x.Descriptor, xPtr, y.Descriptor, yPtr);
            }
        }

        /// <summary>
        /// Sqrt(Sum(i => Conjugate(x[i]) * x[i])).
        /// </summary>
        [CLSCompliant(false)]
        public static double Norm2(VectorDescriptor descriptor, complex* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            return nrm2(descriptor, x);
        }

        /// <summary>
        /// Sqrt(Sum(i => Conjugate(x[i]) * x[i])).
        /// </summary>
        public static double Norm2(Vector<complex> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complex* xPtr = x.Storage)
            {
                return nrm2(x.Descriptor, xPtr);
            }
        }

        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        [CLSCompliant(false)]
        public static void Rotate(
            VectorDescriptor xDescriptor, complex* x,
            VectorDescriptor yDescriptor, complex* y,
            double c, double s)
        {
            Requires.NotNull(xDescriptor, nameof(xDescriptor));
            Requires.NotNullPtr(x, nameof(x));
            Requires.NotNull(yDescriptor, nameof(yDescriptor));
            Requires.NotNullPtr(y, nameof(y));
            if (xDescriptor.Size != yDescriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            rot(xDescriptor, x, yDescriptor, y, c, s);
        }

        /// <summary>
        /// (x, y) = ((c * x + s * y), (c * y - s * x)).
        /// </summary>
        public static void Rotate(Vector<complex> x, Vector<complex> y, double c, double s)
        {
            Requires.NotNull(x, nameof(x));
            Requires.NotNull(y, nameof(y));
            if (x.Descriptor.Size != y.Descriptor.Size)
            {
                throw new ArgumentException(Strings.VectorSizesAreNotEqual);
            }

            fixed (complex* xPtr = x.Storage, yPtr = y.Storage)
            {
                rot(x.Descriptor, xPtr, y.Descriptor, yPtr, c, s);
            }
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        [CLSCompliant(false)]
        public static void Scale(double a, VectorDescriptor descriptor, complex* x)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNullPtr(x, nameof(x));

            scal(a, descriptor, x);
        }

        /// <summary>
        /// x = a * x.
        /// </summary>
        public static void Scale(double a, Vector<complex> x)
        {
            Requires.NotNull(x, nameof(x));

            fixed (complex* xPtr = x.Storage)
            {
                scal(a, x.Descriptor, xPtr);
            }
        }
    }
}
