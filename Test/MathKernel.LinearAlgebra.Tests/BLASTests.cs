using MathKernel.Tests;

namespace MathKernel.LinearAlgebra.Tests
{
    public unsafe partial class BLASTests : MathKernelTests
    {
        public const double delta = 1e-3;
    }

    [Duplicate(typeof(float))]
    public unsafe partial class BLASTests
    {
        public static void GetVectors(
            Bytes bytes,
            out Vector<float> x,
            out Vector<float> y,
            out float* xPtr,
            out float* yPtr)
        {
            x = Vector.Create(new float[2]);
            x.Storage[0] = 1.1f;
            x.Storage[1] = 1.2f;
            y = Vector.Create(new VectorDescriptor(2, 3), new float[10], 1);
            y.Storage[1] = 1.3f;
            y.Storage[4] = 1.4f;
            xPtr = (float*)bytes;
            xPtr[0] = 1.1f;
            xPtr[1] = 1.2f;
            yPtr = (float*)bytes + 2 * sizeof(float);
            yPtr[1] = 1.3f;
            yPtr[4] = 1.4f;
        }

        private static void GetRealMatrices(
            Bytes bytes,
            out Matrix<float> A,
            out Matrix<float> B,
            out float* APtr,
            out float* BPtr)
        {
            A = Matrix.Create(
                new MatrixDescriptor(2, 2),
                new float[]
                {
                    1.5f, 1.6f,
                    1.7f, 1.8f
                });
            B = Matrix.Create(
                new MatrixDescriptor(2, 2, 3),
                new float[]
                {
                    0,
                    1.9f, 2.1f, 0,
                    2.2f, 2.3f, 0
                },
                1);
            APtr = (float*)bytes + 100 * sizeof(float);
            APtr[0] = 1.5f;
            APtr[1] = 1.6f;
            APtr[2] = 1.7f;
            APtr[3] = 1.8f;
            BPtr = (float*)bytes + 104 * sizeof(float);
            BPtr[1] = 1.9f;
            BPtr[2] = 2.1f;
            BPtr[4] = 2.2f;
            BPtr[5] = 2.3f;
        }
    }

    [Duplicate(typeof(double))]
    public unsafe partial class BLASTests
    {
        public static void GetVectors(
            Bytes bytes,
            out Vector<double> x,
            out Vector<double> y,
            out double* xPtr,
            out double* yPtr)
        {
            x = Vector.Create(new double[2]);
            x.Storage[0] = 1.1f;
            x.Storage[1] = 1.2f;
            y = Vector.Create(new VectorDescriptor(2, 3), new double[10], 1);
            y.Storage[1] = 1.3f;
            y.Storage[4] = 1.4f;
            xPtr = (double*)bytes;
            xPtr[0] = 1.1f;
            xPtr[1] = 1.2f;
            yPtr = (double*)bytes + 2 * sizeof(double);
            yPtr[1] = 1.3f;
            yPtr[4] = 1.4f;
        }

        private static void GetRealMatrices(
            Bytes bytes,
            out Matrix<double> A,
            out Matrix<double> B,
            out double* APtr,
            out double* BPtr)
        {
            A = Matrix.Create(
                new MatrixDescriptor(2, 2),
                new double[]
                {
                    1.5f, 1.6f,
                    1.7f, 1.8f
                });
            B = Matrix.Create(
                new MatrixDescriptor(2, 2, 3),
                new double[]
                {
                    0,
                    1.9f, 2.1f, 0,
                    2.2f, 2.3f, 0
                },
                1);
            APtr = (double*)bytes + 100 * sizeof(double);
            APtr[0] = 1.5f;
            APtr[1] = 1.6f;
            APtr[2] = 1.7f;
            APtr[3] = 1.8f;
            BPtr = (double*)bytes + 104 * sizeof(double);
            BPtr[1] = 1.9f;
            BPtr[2] = 2.1f;
            BPtr[4] = 2.2f;
            BPtr[5] = 2.3f;
        }
    }

    [Duplicate(typeof(complexf))]
    public unsafe partial class BLASTests
    {
        public static void GetVectors(
            Bytes bytes,
            out Vector<complexf> x,
            out Vector<complexf> y,
            out complexf* xPtr,
            out complexf* yPtr)
        {
            x = Vector.Create(new complexf[2]);
            x.Storage[0] = 1.1f;
            x.Storage[1] = 1.2f;
            y = Vector.Create(new VectorDescriptor(2, 3), new complexf[10], 1);
            y.Storage[1] = 1.3f;
            y.Storage[4] = 1.4f;
            xPtr = (complexf*)bytes;
            xPtr[0] = 1.1f;
            xPtr[1] = 1.2f;
            yPtr = (complexf*)bytes + 2 * sizeof(complexf);
            yPtr[1] = 1.3f;
            yPtr[4] = 1.4f;
        }

        private static void GetRealMatrices(
            Bytes bytes,
            out Matrix<complexf> A,
            out Matrix<complexf> B,
            out complexf* APtr,
            out complexf* BPtr)
        {
            A = Matrix.Create(
                new MatrixDescriptor(2, 2),
                new complexf[]
                {
                    1.5f, 1.6f,
                    1.7f, 1.8f
                });
            B = Matrix.Create(
                new MatrixDescriptor(2, 2, 3),
                new complexf[]
                {
                    0,
                    1.9f, 2.1f, 0,
                    2.2f, 2.3f, 0
                },
                1);
            APtr = (complexf*)bytes + 100 * sizeof(complexf);
            APtr[0] = 1.5f;
            APtr[1] = 1.6f;
            APtr[2] = 1.7f;
            APtr[3] = 1.8f;
            BPtr = (complexf*)bytes + 104 * sizeof(complexf);
            BPtr[1] = 1.9f;
            BPtr[2] = 2.1f;
            BPtr[4] = 2.2f;
            BPtr[5] = 2.3f;
        }
    }

    [Duplicate(typeof(complex))]
    public unsafe partial class BLASTests
    {
        public static void GetVectors(
            Bytes bytes,
            out Vector<complex> x,
            out Vector<complex> y,
            out complex* xPtr,
            out complex* yPtr)
        {
            x = Vector.Create(new complex[2]);
            x.Storage[0] = 1.1f;
            x.Storage[1] = 1.2f;
            y = Vector.Create(new VectorDescriptor(2, 3), new complex[10], 1);
            y.Storage[1] = 1.3f;
            y.Storage[4] = 1.4f;
            xPtr = (complex*)bytes;
            xPtr[0] = 1.1f;
            xPtr[1] = 1.2f;
            yPtr = (complex*)bytes + 2 * sizeof(complex);
            yPtr[1] = 1.3f;
            yPtr[4] = 1.4f;
        }

        private static void GetRealMatrices(
            Bytes bytes,
            out Matrix<complex> A,
            out Matrix<complex> B,
            out complex* APtr,
            out complex* BPtr)
        {
            A = Matrix.Create(
                new MatrixDescriptor(2, 2),
                new complex[]
                {
                    1.5f, 1.6f,
                    1.7f, 1.8f
                });
            B = Matrix.Create(
                new MatrixDescriptor(2, 2, 3),
                new complex[]
                {
                    0,
                    1.9f, 2.1f, 0,
                    2.2f, 2.3f, 0
                },
                1);
            APtr = (complex*)bytes + 100 * sizeof(complex);
            APtr[0] = 1.5f;
            APtr[1] = 1.6f;
            APtr[2] = 1.7f;
            APtr[3] = 1.8f;
            BPtr = (complex*)bytes + 104 * sizeof(complex);
            BPtr[1] = 1.9f;
            BPtr[2] = 2.1f;
            BPtr[4] = 2.2f;
            BPtr[5] = 2.3f;
        }
    }

    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class BLASTests
    {
        public static void GetComplexVectors(
            Bytes bytes,
            out Vector<complexf> x,
            out Vector<complexf> y,
            out complexf* xPtr,
            out complexf* yPtr)
        {
            complexf i = complexf.ImaginaryOne;

            x = Vector.Create(new complexf[2]);
            x.Storage[0] = 1.1f + 1.2f * i;
            x.Storage[1] = 1.3f + 1.4f * i;
            y = Vector.Create(new VectorDescriptor(2, 3), new complexf[10], 1);
            y.Storage[1] = 1.5f + 1.6f * i;
            y.Storage[4] = 1.7f + 1.8f * i;
            xPtr = (complexf*)bytes;
            xPtr[0] = 1.1f + 1.2f * i;
            xPtr[1] = 1.3f + 1.4f * i;
            yPtr = (complexf*)bytes + 2 * sizeof(complexf);
            yPtr[1] = 1.5f + 1.6f * i;
            yPtr[4] = 1.7f + 1.8f * i;
        }

        public static void GetComplexMatrices(
            Bytes bytes,
            out Matrix<complexf> A,
            out Matrix<complexf> B,
            out complexf* APtr,
            out complexf* BPtr)
        {
            complexf i = complexf.ImaginaryOne;

            A = Matrix.Create(
                new MatrixDescriptor(2, 2),
                new complexf[]
                {
                    1.1f + 1.2f * i, 1.3f + 1.4f * i,
                    1.5f + 1.6f * i, 1.7f + 1.8f * i
                });
            B = Matrix.Create(
                new MatrixDescriptor(2, 2, 3),
                new complexf[]
                {
                    0,
                    1.9f + 2.1f * i, 2.2f + 2.3f * i, 0,
                    2.4f + 2.5f * i, 2.6f + 2.7f * i, 0
                },
                1);
            APtr = (complexf*)bytes + 200 * sizeof(complexf);
            APtr[0] = 1.1f + 1.2f * i;
            APtr[1] = 1.3f + 1.4f * i;
            APtr[2] = 1.5f + 1.6f * i;
            APtr[3] = 1.7f + 1.8f * i;
            BPtr = (complexf*)bytes + 208 * sizeof(complexf);
            BPtr[1] = 1.9f + 2.1f * i;
            BPtr[2] = 2.2f + 2.3f * i;
            BPtr[4] = 2.4f + 2.5f * i;
            BPtr[5] = 2.6f + 2.7f * i;
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class BLASTests
    {
        public static void GetComplexVectors(
            Bytes bytes,
            out Vector<complex> x,
            out Vector<complex> y,
            out complex* xPtr,
            out complex* yPtr)
        {
            complex i = complex.ImaginaryOne;

            x = Vector.Create(new complex[2]);
            x.Storage[0] = 1.1f + 1.2f * i;
            x.Storage[1] = 1.3f + 1.4f * i;
            y = Vector.Create(new VectorDescriptor(2, 3), new complex[10], 1);
            y.Storage[1] = 1.5f + 1.6f * i;
            y.Storage[4] = 1.7f + 1.8f * i;
            xPtr = (complex*)bytes;
            xPtr[0] = 1.1f + 1.2f * i;
            xPtr[1] = 1.3f + 1.4f * i;
            yPtr = (complex*)bytes + 2 * sizeof(complex);
            yPtr[1] = 1.5f + 1.6f * i;
            yPtr[4] = 1.7f + 1.8f * i;
        }

        public static void GetComplexMatrices(
            Bytes bytes,
            out Matrix<complex> A,
            out Matrix<complex> B,
            out complex* APtr,
            out complex* BPtr)
        {
            complex i = complex.ImaginaryOne;

            A = Matrix.Create(
                new MatrixDescriptor(2, 2),
                new complex[]
                {
                    1.1f + 1.2f * i, 1.3f + 1.4f * i,
                    1.5f + 1.6f * i, 1.7f + 1.8f * i
                });
            B = Matrix.Create(
                new MatrixDescriptor(2, 2, 3),
                new complex[]
                {
                    0,
                    1.9f + 2.1f * i, 2.2f + 2.3f * i, 0,
                    2.4f + 2.5f * i, 2.6f + 2.7f * i, 0
                },
                1);
            APtr = (complex*)bytes + 200 * sizeof(complex);
            APtr[0] = 1.1f + 1.2f * i;
            APtr[1] = 1.3f + 1.4f * i;
            APtr[2] = 1.5f + 1.6f * i;
            APtr[3] = 1.7f + 1.8f * i;
            BPtr = (complex*)bytes + 208 * sizeof(complex);
            BPtr[1] = 1.9f + 2.1f * i;
            BPtr[2] = 2.2f + 2.3f * i;
            BPtr[4] = 2.4f + 2.5f * i;
            BPtr[5] = 2.6f + 2.7f * i;
        }
    }
}
