using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.Tests
{
    [TestClass]
    public unsafe partial class BLASTests : MathKernelTests, IDisposable
    {
        private const double delta = 1e-6;

        private Bytes bytes;

        public BLASTests()
        {
            Initialize();
        }

        [TestInitialize]
        public void Initialize()
        {
            bytes = new Bytes(1024);
        }

        [TestCleanup]
        public void Dispose()
        {
            bytes.Dispose();
        }

        [TestMethod]
        public void Level1()
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;

            // SDot
            GetVectors(out x, out y, out xPtr, out yPtr);
            double sdot = BLAS.SDot(1, x, y);
            Assert.AreEqual(4.11, sdot, delta);
            sdot = BLAS.SDot(1, x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(4.11, sdot, delta);
            GetVectors(out x, out y, out xPtr, out yPtr);
            sdot = BLAS.SDot(x, y);
            Assert.AreEqual(3.11, sdot, delta);
            sdot = BLAS.SDot(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(3.11, sdot, delta);
        }
    }

    [Duplicate(typeof(float))]
    public unsafe partial class BLASTests
    {
        private void GetVectors(
            out Vector<float> x,
            out Vector<float> y,
            out float* xPtr,
            out float* yPtr)
        {
            x = Vector.Create(new float[2]);
            x.Storage[0] = 1.1f;
            x.Storage[1] = 1.2f;
            y = Vector.Create(new float[10], 2, 1, 3);
            y.Storage[1] = 1.3f;
            y.Storage[4] = 1.4f;
            xPtr = (float*)bytes;
            xPtr[0] = 1.1f;
            xPtr[1] = 1.2f;
            yPtr = (float*)bytes + 2 * sizeof(float);
            yPtr[1] = 1.3f;
            yPtr[4] = 1.4f;
        }

        [DataTestMethod]
        [DataRow(null)]
        public void Level1(float? dataType)
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;

            // ASum
            GetVectors(out x, out y, out xPtr, out yPtr);
            var sum = BLAS.ASum(x);
            Assert.AreEqual(2.3, sum, delta);
            sum = BLAS.ASum(x.Descriptor, xPtr);
            Assert.AreEqual(2.3, sum, delta);

            // AXPY
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.AXPY(1, x, y);
            Assert.AreEqual(2.4, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(2.6, y.Storage[4].AsDouble(), delta);
            BLAS.AXPY(1, x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(2.4, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(2.6, yPtr[4].AsDouble(), delta);

            // Copy
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.Copy(x, y);
            Assert.AreEqual(1.1, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.2, y.Storage[4].AsDouble(), delta);
            BLAS.Copy(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(1.1, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.2, yPtr[4].AsDouble(), delta);
        }
    }

    [Duplicate(typeof(double))]
    public unsafe partial class BLASTests
    {
        private void GetVectors(
            out Vector<double> x,
            out Vector<double> y,
            out double* xPtr,
            out double* yPtr)
        {
            x = Vector.Create(new double[2]);
            x.Storage[0] = 1.1f;
            x.Storage[1] = 1.2f;
            y = Vector.Create(new double[10], 2, 1, 3);
            y.Storage[1] = 1.3f;
            y.Storage[4] = 1.4f;
            xPtr = (double*)bytes;
            xPtr[0] = 1.1f;
            xPtr[1] = 1.2f;
            yPtr = (double*)bytes + 2 * sizeof(double);
            yPtr[1] = 1.3f;
            yPtr[4] = 1.4f;
        }

        [DataTestMethod]
        [DataRow(null)]
        public void Level1(double? dataType)
        {
            Vector<double> x;
            Vector<double> y;
            double* xPtr;
            double* yPtr;

            // ASum
            GetVectors(out x, out y, out xPtr, out yPtr);
            var sum = BLAS.ASum(x);
            Assert.AreEqual(2.3, sum, delta);
            sum = BLAS.ASum(x.Descriptor, xPtr);
            Assert.AreEqual(2.3, sum, delta);

            // AXPY
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.AXPY(1, x, y);
            Assert.AreEqual(2.4, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(2.6, y.Storage[4].AsDouble(), delta);
            BLAS.AXPY(1, x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(2.4, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(2.6, yPtr[4].AsDouble(), delta);

            // Copy
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.Copy(x, y);
            Assert.AreEqual(1.1, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.2, y.Storage[4].AsDouble(), delta);
            BLAS.Copy(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(1.1, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.2, yPtr[4].AsDouble(), delta);
        }
    }

    [Duplicate(typeof(complexf))]
    public unsafe partial class BLASTests
    {
        private void GetVectors(
            out Vector<complexf> x,
            out Vector<complexf> y,
            out complexf* xPtr,
            out complexf* yPtr)
        {
            x = Vector.Create(new complexf[2]);
            x.Storage[0] = 1.1f;
            x.Storage[1] = 1.2f;
            y = Vector.Create(new complexf[10], 2, 1, 3);
            y.Storage[1] = 1.3f;
            y.Storage[4] = 1.4f;
            xPtr = (complexf*)bytes;
            xPtr[0] = 1.1f;
            xPtr[1] = 1.2f;
            yPtr = (complexf*)bytes + 2 * sizeof(complexf);
            yPtr[1] = 1.3f;
            yPtr[4] = 1.4f;
        }

        [DataTestMethod]
        [DataRow(null)]
        public void Level1(complexf? dataType)
        {
            Vector<complexf> x;
            Vector<complexf> y;
            complexf* xPtr;
            complexf* yPtr;

            // ASum
            GetVectors(out x, out y, out xPtr, out yPtr);
            var sum = BLAS.ASum(x);
            Assert.AreEqual(2.3, sum, delta);
            sum = BLAS.ASum(x.Descriptor, xPtr);
            Assert.AreEqual(2.3, sum, delta);

            // AXPY
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.AXPY(1, x, y);
            Assert.AreEqual(2.4, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(2.6, y.Storage[4].AsDouble(), delta);
            BLAS.AXPY(1, x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(2.4, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(2.6, yPtr[4].AsDouble(), delta);

            // Copy
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.Copy(x, y);
            Assert.AreEqual(1.1, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.2, y.Storage[4].AsDouble(), delta);
            BLAS.Copy(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(1.1, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.2, yPtr[4].AsDouble(), delta);
        }
    }

    [Duplicate(typeof(complex))]
    public unsafe partial class BLASTests
    {
        private void GetVectors(
            out Vector<complex> x,
            out Vector<complex> y,
            out complex* xPtr,
            out complex* yPtr)
        {
            x = Vector.Create(new complex[2]);
            x.Storage[0] = 1.1f;
            x.Storage[1] = 1.2f;
            y = Vector.Create(new complex[10], 2, 1, 3);
            y.Storage[1] = 1.3f;
            y.Storage[4] = 1.4f;
            xPtr = (complex*)bytes;
            xPtr[0] = 1.1f;
            xPtr[1] = 1.2f;
            yPtr = (complex*)bytes + 2 * sizeof(complex);
            yPtr[1] = 1.3f;
            yPtr[4] = 1.4f;
        }

        [DataTestMethod]
        [DataRow(null)]
        public void Level1(complex? dataType)
        {
            Vector<complex> x;
            Vector<complex> y;
            complex* xPtr;
            complex* yPtr;

            // ASum
            GetVectors(out x, out y, out xPtr, out yPtr);
            var sum = BLAS.ASum(x);
            Assert.AreEqual(2.3, sum, delta);
            sum = BLAS.ASum(x.Descriptor, xPtr);
            Assert.AreEqual(2.3, sum, delta);

            // AXPY
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.AXPY(1, x, y);
            Assert.AreEqual(2.4, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(2.6, y.Storage[4].AsDouble(), delta);
            BLAS.AXPY(1, x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(2.4, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(2.6, yPtr[4].AsDouble(), delta);

            // Copy
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.Copy(x, y);
            Assert.AreEqual(1.1, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.2, y.Storage[4].AsDouble(), delta);
            BLAS.Copy(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(1.1, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.2, yPtr[4].AsDouble(), delta);
        }
    }

    [RealTypeDuplicate(typeof(float))]
    public unsafe partial class BLASTests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void Level1(Lazy<float> dataType)
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;

            // Dot
            GetVectors(out x, out y, out xPtr, out yPtr);
            var dot = BLAS.Dot(x, y);
            Assert.AreEqual(3.11, dot, delta);
            dot = BLAS.Dot(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(3.11, dot, delta);
        }
    }

    [RealTypeDuplicate(typeof(double))]
    public unsafe partial class BLASTests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void Level1(Lazy<double> dataType)
        {
            Vector<double> x;
            Vector<double> y;
            double* xPtr;
            double* yPtr;

            // Dot
            GetVectors(out x, out y, out xPtr, out yPtr);
            var dot = BLAS.Dot(x, y);
            Assert.AreEqual(3.11, dot, delta);
            dot = BLAS.Dot(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(3.11, dot, delta);
        }
    }

    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class BLASTests
    {
        private void GetComplexVectors(
            out Vector<complexf> x,
            out Vector<complexf> y,
            out complexf* xPtr,
            out complexf* yPtr)
        {
            x = Vector.Create(new complexf[2]);
            x.Storage[0] = new complexf(1.1f, 1.2f);
            x.Storage[1] = new complexf(1.3f, 1.4f);
            y = Vector.Create(new complexf[10], 2, 1, 3);
            y.Storage[1] = new complexf(1.5f, 1.6f);
            y.Storage[4] = new complexf(1.7f, 1.8f);
            xPtr = (complexf*)bytes;
            xPtr[0] = new complexf(1.1f, 1.2f);
            xPtr[1] = new complexf(1.3f, 1.4f);
            yPtr = (complexf*)bytes + 2 * sizeof(float);
            yPtr[1] = new complexf(1.5f, 1.6f);
            yPtr[4] = new complexf(1.7f, 1.8f);
        }

        public void Level1(Lazy<complexf> dataType)
        {
            Vector<complexf> x;
            Vector<complexf> y;
            complexf* xPtr;
            complexf* yPtr;

            // DotC
            GetVectors(out x, out y, out xPtr, out yPtr);
            complexf dotc = BLAS.DotC(x, y);
            complexf expected =
                complexf.Conjugate(new complexf(1.1f, 1.2f)) * new complexf(1.5f, 1.6f) +
                complexf.Conjugate(new complexf(1.3f, 1.4f)) * new complexf(1.8f, 1.7f);
            Assert.AreEqual(expected, dotc);
            dotc = BLAS.DotC(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(expected, dotc);

            // DotU
            GetVectors(out x, out y, out xPtr, out yPtr);
            complexf dotu = BLAS.DotC(x, y);
            expected =
                new complexf(1.1f, 1.2f) * new complexf(1.5f, 1.6f) +
                new complexf(1.3f, 1.4f) * new complexf(1.8f, 1.7f);
            Assert.AreEqual(expected, dotu);
            dotu = BLAS.DotC(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(expected, dotu);
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class BLASTests
    {
        private void GetComplexVectors(
            out Vector<complex> x,
            out Vector<complex> y,
            out complex* xPtr,
            out complex* yPtr)
        {
            x = Vector.Create(new complex[2]);
            x.Storage[0] = new complex(1.1f, 1.2f);
            x.Storage[1] = new complex(1.3f, 1.4f);
            y = Vector.Create(new complex[10], 2, 1, 3);
            y.Storage[1] = new complex(1.5f, 1.6f);
            y.Storage[4] = new complex(1.7f, 1.8f);
            xPtr = (complex*)bytes;
            xPtr[0] = new complex(1.1f, 1.2f);
            xPtr[1] = new complex(1.3f, 1.4f);
            yPtr = (complex*)bytes + 2 * sizeof(double);
            yPtr[1] = new complex(1.5f, 1.6f);
            yPtr[4] = new complex(1.7f, 1.8f);
        }

        public void Level1(Lazy<complex> dataType)
        {
            Vector<complex> x;
            Vector<complex> y;
            complex* xPtr;
            complex* yPtr;

            // DotC
            GetVectors(out x, out y, out xPtr, out yPtr);
            complex dotc = BLAS.DotC(x, y);
            complex expected =
                complex.Conjugate(new complex(1.1f, 1.2f)) * new complex(1.5f, 1.6f) +
                complex.Conjugate(new complex(1.3f, 1.4f)) * new complex(1.8f, 1.7f);
            Assert.AreEqual(expected, dotc);
            dotc = BLAS.DotC(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(expected, dotc);

            // DotU
            GetVectors(out x, out y, out xPtr, out yPtr);
            complex dotu = BLAS.DotC(x, y);
            expected =
                new complex(1.1f, 1.2f) * new complex(1.5f, 1.6f) +
                new complex(1.3f, 1.4f) * new complex(1.8f, 1.7f);
            Assert.AreEqual(expected, dotu);
            dotu = BLAS.DotC(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(expected, dotu);
        }
    }
}
