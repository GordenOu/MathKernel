using System;
using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Math;

namespace MathKernel.LinearAlgebra.Tests
{
    [TestClass]
    public partial class BandMatrixTests : MathKernelTests
    {
        private const double delta = 1e-6;

        private MatrixDescriptor descriptor1;
        private MatrixDescriptor descriptor2;
        private BandMatrixDescriptor descriptor3;
        private BandMatrixDescriptor descriptor4;

        public BandMatrixTests()
        {
            Initialize();
        }

        [TestInitialize]
        public void Initialize()
        {
            descriptor1 = new MatrixDescriptor(4, 5);
            descriptor2 = new MatrixDescriptor(4, 5, 1, 6, MatrixLayout.ColumnMajor);
            descriptor3 = new BandMatrixDescriptor(4, 5, 2, 1);
            descriptor4 = new BandMatrixDescriptor(4, 5, 2, 1, 1, 6, MatrixLayout.ColumnMajor);
        }
    }

    [Duplicate(typeof(float))]
    public partial class BandMatrixTests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void GBMV(float? dataType)
        {
            var matrix1 = Matrix.Create(
                new float[]
                {
                    1.1f, 1.2f, 1.3f, 1.4f, 1.5f,
                    1.6f, 1.7f, 1.8f, 1.9f, 2.1f,
                    2.2f, 2.3f, 2.4f, 2.5f, 2.6f,
                    2.7f, 2.8f, 2.9f, 3.1f, 3.2f
                },
                descriptor1);
            var matrix2 = Matrix.Create(
                new float[]
                {
                    0,
                    1.1f, 1.6f, 2.2f, 2.7f, 0, 0,
                    1.2f, 1.7f, 2.3f, 2.8f, 0, 0,
                    1.3f, 1.8f, 2.4f, 2.9f, 0, 0,
                    1.4f, 1.9f, 2.5f, 3.1f, 0, 0,
                    1.5f, 2.1f, 2.6f, 3.2f, 0, 0
                },
                descriptor2);
            var matrix3 = BandMatrix.Create(
                new float[]
                {
                    9.9f, 1.1f, 1.2f, 1.3f,
                    1.6f, 1.7f, 1.8f, 1.9f,
                    2.3f, 2.4f, 2.5f, 2.6f,
                    2.9f, 3.1f, 3.2f, 9.9f,
                },
                descriptor3);
            var matrix4 = BandMatrix.Create(
                new float[]
                {
                    0,
                    9.9f, 9.9f, 1.1f, 1.6f, 0, 0,
                    9.9f, 1.2f, 1.7f, 2.3f, 0, 0,
                    1.3f, 1.8f, 2.4f, 2.9f, 0, 0,
                    1.9f, 2.5f, 3.1f, 9.9f, 0, 0,
                    2.6f, 3.2f, 9.9f, 9.9f, 0, 0
                },
                descriptor4);
            var x = Vector.Create(new float[] { 3.8f, 3.9f, 4.1f, 4.2f, 4.3f });
            var yStorage = new float[] { 4.4f, 4.5f, 4.6f, 4.7f };
            var result = new float[] { 91.971f, 160.493f, 221.861f, 213.453f };
            var y = Vector.Create(new float[4]);

            Action checkResult = () =>
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(
                        result[i].AsDouble(),
                        y.Storage[i].AsDouble(),
                        delta * Abs(result[i].AsDouble()));
                }
            };

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix1, 2, 1), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix2, 2, 1), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix3, x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix4, x, 5.1f, y);
            checkResult();

            x = Vector.Create(new float[] { 3.8f, 3.9f, 4.1f, 4.2f });
            yStorage = new float[] { 4.4f, 4.5f, 4.6f, 4.7f, 4.8f };
            result = new float[] { 73.498f, 123.988f, 189.962f, 174.302f, 142.57f };
            y = Vector.Create(new float[5]);

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix1, 2, 1).Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix1, 2, 1).ConjugateTranspose(), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix2, 2, 1).Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix2, 2, 1).ConjugateTranspose(), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix3.Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix3.ConjugateTranspose(), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix4.Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix4.ConjugateTranspose(), x, 5.1f, y);
            checkResult();
        }
    }

    [Duplicate(typeof(double))]
    public partial class BandMatrixTests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void GBMV(double? dataType)
        {
            var matrix1 = Matrix.Create(
                new double[]
                {
                    1.1f, 1.2f, 1.3f, 1.4f, 1.5f,
                    1.6f, 1.7f, 1.8f, 1.9f, 2.1f,
                    2.2f, 2.3f, 2.4f, 2.5f, 2.6f,
                    2.7f, 2.8f, 2.9f, 3.1f, 3.2f
                },
                descriptor1);
            var matrix2 = Matrix.Create(
                new double[]
                {
                    0,
                    1.1f, 1.6f, 2.2f, 2.7f, 0, 0,
                    1.2f, 1.7f, 2.3f, 2.8f, 0, 0,
                    1.3f, 1.8f, 2.4f, 2.9f, 0, 0,
                    1.4f, 1.9f, 2.5f, 3.1f, 0, 0,
                    1.5f, 2.1f, 2.6f, 3.2f, 0, 0
                },
                descriptor2);
            var matrix3 = BandMatrix.Create(
                new double[]
                {
                    9.9f, 1.1f, 1.2f, 1.3f,
                    1.6f, 1.7f, 1.8f, 1.9f,
                    2.3f, 2.4f, 2.5f, 2.6f,
                    2.9f, 3.1f, 3.2f, 9.9f,
                },
                descriptor3);
            var matrix4 = BandMatrix.Create(
                new double[]
                {
                    0,
                    9.9f, 9.9f, 1.1f, 1.6f, 0, 0,
                    9.9f, 1.2f, 1.7f, 2.3f, 0, 0,
                    1.3f, 1.8f, 2.4f, 2.9f, 0, 0,
                    1.9f, 2.5f, 3.1f, 9.9f, 0, 0,
                    2.6f, 3.2f, 9.9f, 9.9f, 0, 0
                },
                descriptor4);
            var x = Vector.Create(new double[] { 3.8f, 3.9f, 4.1f, 4.2f, 4.3f });
            var yStorage = new double[] { 4.4f, 4.5f, 4.6f, 4.7f };
            var result = new double[] { 91.971f, 160.493f, 221.861f, 213.453f };
            var y = Vector.Create(new double[4]);

            Action checkResult = () =>
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(
                        result[i].AsDouble(),
                        y.Storage[i].AsDouble(),
                        delta * Abs(result[i].AsDouble()));
                }
            };

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix1, 2, 1), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix2, 2, 1), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix3, x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix4, x, 5.1f, y);
            checkResult();

            x = Vector.Create(new double[] { 3.8f, 3.9f, 4.1f, 4.2f });
            yStorage = new double[] { 4.4f, 4.5f, 4.6f, 4.7f, 4.8f };
            result = new double[] { 73.498f, 123.988f, 189.962f, 174.302f, 142.57f };
            y = Vector.Create(new double[5]);

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix1, 2, 1).Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix1, 2, 1).ConjugateTranspose(), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix2, 2, 1).Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix2, 2, 1).ConjugateTranspose(), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix3.Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix3.ConjugateTranspose(), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix4.Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix4.ConjugateTranspose(), x, 5.1f, y);
            checkResult();
        }
    }

    [Duplicate(typeof(complexf))]
    public partial class BandMatrixTests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void GBMV(complexf? dataType)
        {
            var matrix1 = Matrix.Create(
                new complexf[]
                {
                    1.1f, 1.2f, 1.3f, 1.4f, 1.5f,
                    1.6f, 1.7f, 1.8f, 1.9f, 2.1f,
                    2.2f, 2.3f, 2.4f, 2.5f, 2.6f,
                    2.7f, 2.8f, 2.9f, 3.1f, 3.2f
                },
                descriptor1);
            var matrix2 = Matrix.Create(
                new complexf[]
                {
                    0,
                    1.1f, 1.6f, 2.2f, 2.7f, 0, 0,
                    1.2f, 1.7f, 2.3f, 2.8f, 0, 0,
                    1.3f, 1.8f, 2.4f, 2.9f, 0, 0,
                    1.4f, 1.9f, 2.5f, 3.1f, 0, 0,
                    1.5f, 2.1f, 2.6f, 3.2f, 0, 0
                },
                descriptor2);
            var matrix3 = BandMatrix.Create(
                new complexf[]
                {
                    9.9f, 1.1f, 1.2f, 1.3f,
                    1.6f, 1.7f, 1.8f, 1.9f,
                    2.3f, 2.4f, 2.5f, 2.6f,
                    2.9f, 3.1f, 3.2f, 9.9f,
                },
                descriptor3);
            var matrix4 = BandMatrix.Create(
                new complexf[]
                {
                    0,
                    9.9f, 9.9f, 1.1f, 1.6f, 0, 0,
                    9.9f, 1.2f, 1.7f, 2.3f, 0, 0,
                    1.3f, 1.8f, 2.4f, 2.9f, 0, 0,
                    1.9f, 2.5f, 3.1f, 9.9f, 0, 0,
                    2.6f, 3.2f, 9.9f, 9.9f, 0, 0
                },
                descriptor4);
            var x = Vector.Create(new complexf[] { 3.8f, 3.9f, 4.1f, 4.2f, 4.3f });
            var yStorage = new complexf[] { 4.4f, 4.5f, 4.6f, 4.7f };
            var result = new complexf[] { 91.971f, 160.493f, 221.861f, 213.453f };
            var y = Vector.Create(new complexf[4]);

            Action checkResult = () =>
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(
                        result[i].AsDouble(),
                        y.Storage[i].AsDouble(),
                        delta * Abs(result[i].AsDouble()));
                }
            };

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix1, 2, 1), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix2, 2, 1), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix3, x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix4, x, 5.1f, y);
            checkResult();

            x = Vector.Create(new complexf[] { 3.8f, 3.9f, 4.1f, 4.2f });
            yStorage = new complexf[] { 4.4f, 4.5f, 4.6f, 4.7f, 4.8f };
            result = new complexf[] { 73.498f, 123.988f, 189.962f, 174.302f, 142.57f };
            y = Vector.Create(new complexf[5]);

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix1, 2, 1).Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix1, 2, 1).ConjugateTranspose(), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix2, 2, 1).Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix2, 2, 1).ConjugateTranspose(), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix3.Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix3.ConjugateTranspose(), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix4.Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix4.ConjugateTranspose(), x, 5.1f, y);
            checkResult();
        }
    }

    [Duplicate(typeof(complex))]
    public partial class BandMatrixTests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void GBMV(complex? dataType)
        {
            var matrix1 = Matrix.Create(
                new complex[]
                {
                    1.1f, 1.2f, 1.3f, 1.4f, 1.5f,
                    1.6f, 1.7f, 1.8f, 1.9f, 2.1f,
                    2.2f, 2.3f, 2.4f, 2.5f, 2.6f,
                    2.7f, 2.8f, 2.9f, 3.1f, 3.2f
                },
                descriptor1);
            var matrix2 = Matrix.Create(
                new complex[]
                {
                    0,
                    1.1f, 1.6f, 2.2f, 2.7f, 0, 0,
                    1.2f, 1.7f, 2.3f, 2.8f, 0, 0,
                    1.3f, 1.8f, 2.4f, 2.9f, 0, 0,
                    1.4f, 1.9f, 2.5f, 3.1f, 0, 0,
                    1.5f, 2.1f, 2.6f, 3.2f, 0, 0
                },
                descriptor2);
            var matrix3 = BandMatrix.Create(
                new complex[]
                {
                    9.9f, 1.1f, 1.2f, 1.3f,
                    1.6f, 1.7f, 1.8f, 1.9f,
                    2.3f, 2.4f, 2.5f, 2.6f,
                    2.9f, 3.1f, 3.2f, 9.9f,
                },
                descriptor3);
            var matrix4 = BandMatrix.Create(
                new complex[]
                {
                    0,
                    9.9f, 9.9f, 1.1f, 1.6f, 0, 0,
                    9.9f, 1.2f, 1.7f, 2.3f, 0, 0,
                    1.3f, 1.8f, 2.4f, 2.9f, 0, 0,
                    1.9f, 2.5f, 3.1f, 9.9f, 0, 0,
                    2.6f, 3.2f, 9.9f, 9.9f, 0, 0
                },
                descriptor4);
            var x = Vector.Create(new complex[] { 3.8f, 3.9f, 4.1f, 4.2f, 4.3f });
            var yStorage = new complex[] { 4.4f, 4.5f, 4.6f, 4.7f };
            var result = new complex[] { 91.971f, 160.493f, 221.861f, 213.453f };
            var y = Vector.Create(new complex[4]);

            Action checkResult = () =>
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(
                        result[i].AsDouble(),
                        y.Storage[i].AsDouble(),
                        delta * Abs(result[i].AsDouble()));
                }
            };

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix1, 2, 1), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix2, 2, 1), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix3, x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix4, x, 5.1f, y);
            checkResult();

            x = Vector.Create(new complex[] { 3.8f, 3.9f, 4.1f, 4.2f });
            yStorage = new complex[] { 4.4f, 4.5f, 4.6f, 4.7f, 4.8f };
            result = new complex[] { 73.498f, 123.988f, 189.962f, 174.302f, 142.57f };
            y = Vector.Create(new complex[5]);

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix1, 2, 1).Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix1, 2, 1).ConjugateTranspose(), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix2, 2, 1).Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, BandMatrix.FromMatrix(matrix2, 2, 1).ConjugateTranspose(), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix3.Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix3.ConjugateTranspose(), x, 5.1f, y);
            checkResult();

            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix4.Transpose(), x, 5.1f, y);
            checkResult();
            yStorage.CopyTo(y.Storage, 0);
            BLAS.GBMV(4.9f, matrix4.ConjugateTranspose(), x, 5.1f, y);
            checkResult();
        }
    }
}
