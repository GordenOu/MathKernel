using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Math;

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
            y = Vector.Create(new float[10], new VectorDescriptor(2, 1, 3));
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

            // Norm2
            GetVectors(out x, out y, out xPtr, out yPtr);
            var norm = BLAS.Norm2(x);
            Assert.AreEqual(Sqrt(1.1 * 1.1 + 1.2 * 1.2), norm, delta);
            norm = BLAS.Norm2(x.Descriptor, xPtr);
            Assert.AreEqual(Sqrt(1.1 * 1.1 + 1.2 * 1.2), norm, delta);
            norm = BLAS.Norm2(y);
            Assert.AreEqual(Sqrt(1.3 * 1.3 + 1.4 * 1.4), norm, delta);
            norm = BLAS.Norm2(y.Descriptor, yPtr);
            Assert.AreEqual(Sqrt(1.3 * 1.3 + 1.4 * 1.4), norm, delta);

            // Rotate
            var c = 1.5f;
            var s = 1.6f;
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.Rotate(x, y, c, s);
            Assert.AreEqual(x.Storage[0].AsDouble(), 3.73f, delta);
            Assert.AreEqual(x.Storage[1].AsDouble(), 4.04f, delta);
            Assert.AreEqual(y.Storage[1].AsDouble(), 0.19f, delta);
            Assert.AreEqual(y.Storage[4].AsDouble(), 0.18f, delta);
            BLAS.Rotate(x.Descriptor, xPtr, y.Descriptor, yPtr, c, s);
            Assert.AreEqual(xPtr[0].AsDouble(), 3.73f, delta);
            Assert.AreEqual(xPtr[1].AsDouble(), 4.04f, delta);
            Assert.AreEqual(yPtr[1].AsDouble(), 0.19f, delta);
            Assert.AreEqual(yPtr[4].AsDouble(), 0.18f, delta);

            // Scale
            GetVectors(out x, out y, out xPtr, out yPtr);
            float alpha = 1.5f;
            BLAS.Scale(alpha, x);
            Assert.AreEqual(1.1f * alpha.AsDouble(), x.Storage[0].AsDouble(), delta);
            Assert.AreEqual(1.2f * alpha.AsDouble(), x.Storage[1].AsDouble(), delta);
            BLAS.Scale(alpha, y);
            Assert.AreEqual(1.3f * alpha.AsDouble(), y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.4f * alpha.AsDouble(), y.Storage[4].AsDouble(), delta);
            BLAS.Scale(alpha, x.Descriptor, xPtr);
            Assert.AreEqual(1.1f * alpha.AsDouble(), xPtr[0].AsDouble(), delta);
            Assert.AreEqual(1.2f * alpha.AsDouble(), xPtr[1].AsDouble(), delta);
            BLAS.Scale(alpha, y.Descriptor, yPtr);
            Assert.AreEqual(1.3f * alpha.AsDouble(), yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.4f * alpha.AsDouble(), yPtr[4].AsDouble(), delta);

            // Swap
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.Swap(x, y);
            Assert.AreEqual(1.3f, x.Storage[0].AsDouble(), delta);
            Assert.AreEqual(1.4f, x.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.1f, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.2f, y.Storage[4].AsDouble(), delta);
            BLAS.Swap(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(1.3f, xPtr[0].AsDouble(), delta);
            Assert.AreEqual(1.4f, xPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.1f, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.2f, yPtr[4].AsDouble(), delta);

            // IAMax and IAMin
            GetVectors(out x, out y, out xPtr, out yPtr);
            int iAMax;
            int iAMin;
            iAMax = BLAS.IAMax(x);
            iAMin = BLAS.IAMin(x);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
            iAMax = BLAS.IAMax(y);
            iAMin = BLAS.IAMin(y);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
            iAMax = BLAS.IAMax(x.Descriptor, xPtr);
            iAMin = BLAS.IAMin(x.Descriptor, xPtr);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
            iAMax = BLAS.IAMax(y.Descriptor, yPtr);
            iAMin = BLAS.IAMin(y.Descriptor, yPtr);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
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
            y = Vector.Create(new double[10], new VectorDescriptor(2, 1, 3));
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

            // Norm2
            GetVectors(out x, out y, out xPtr, out yPtr);
            var norm = BLAS.Norm2(x);
            Assert.AreEqual(Sqrt(1.1 * 1.1 + 1.2 * 1.2), norm, delta);
            norm = BLAS.Norm2(x.Descriptor, xPtr);
            Assert.AreEqual(Sqrt(1.1 * 1.1 + 1.2 * 1.2), norm, delta);
            norm = BLAS.Norm2(y);
            Assert.AreEqual(Sqrt(1.3 * 1.3 + 1.4 * 1.4), norm, delta);
            norm = BLAS.Norm2(y.Descriptor, yPtr);
            Assert.AreEqual(Sqrt(1.3 * 1.3 + 1.4 * 1.4), norm, delta);

            // Rotate
            var c = 1.5f;
            var s = 1.6f;
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.Rotate(x, y, c, s);
            Assert.AreEqual(x.Storage[0].AsDouble(), 3.73f, delta);
            Assert.AreEqual(x.Storage[1].AsDouble(), 4.04f, delta);
            Assert.AreEqual(y.Storage[1].AsDouble(), 0.19f, delta);
            Assert.AreEqual(y.Storage[4].AsDouble(), 0.18f, delta);
            BLAS.Rotate(x.Descriptor, xPtr, y.Descriptor, yPtr, c, s);
            Assert.AreEqual(xPtr[0].AsDouble(), 3.73f, delta);
            Assert.AreEqual(xPtr[1].AsDouble(), 4.04f, delta);
            Assert.AreEqual(yPtr[1].AsDouble(), 0.19f, delta);
            Assert.AreEqual(yPtr[4].AsDouble(), 0.18f, delta);

            // Scale
            GetVectors(out x, out y, out xPtr, out yPtr);
            double alpha = 1.5f;
            BLAS.Scale(alpha, x);
            Assert.AreEqual(1.1f * alpha.AsDouble(), x.Storage[0].AsDouble(), delta);
            Assert.AreEqual(1.2f * alpha.AsDouble(), x.Storage[1].AsDouble(), delta);
            BLAS.Scale(alpha, y);
            Assert.AreEqual(1.3f * alpha.AsDouble(), y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.4f * alpha.AsDouble(), y.Storage[4].AsDouble(), delta);
            BLAS.Scale(alpha, x.Descriptor, xPtr);
            Assert.AreEqual(1.1f * alpha.AsDouble(), xPtr[0].AsDouble(), delta);
            Assert.AreEqual(1.2f * alpha.AsDouble(), xPtr[1].AsDouble(), delta);
            BLAS.Scale(alpha, y.Descriptor, yPtr);
            Assert.AreEqual(1.3f * alpha.AsDouble(), yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.4f * alpha.AsDouble(), yPtr[4].AsDouble(), delta);

            // Swap
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.Swap(x, y);
            Assert.AreEqual(1.3f, x.Storage[0].AsDouble(), delta);
            Assert.AreEqual(1.4f, x.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.1f, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.2f, y.Storage[4].AsDouble(), delta);
            BLAS.Swap(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(1.3f, xPtr[0].AsDouble(), delta);
            Assert.AreEqual(1.4f, xPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.1f, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.2f, yPtr[4].AsDouble(), delta);

            // IAMax and IAMin
            GetVectors(out x, out y, out xPtr, out yPtr);
            int iAMax;
            int iAMin;
            iAMax = BLAS.IAMax(x);
            iAMin = BLAS.IAMin(x);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
            iAMax = BLAS.IAMax(y);
            iAMin = BLAS.IAMin(y);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
            iAMax = BLAS.IAMax(x.Descriptor, xPtr);
            iAMin = BLAS.IAMin(x.Descriptor, xPtr);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
            iAMax = BLAS.IAMax(y.Descriptor, yPtr);
            iAMin = BLAS.IAMin(y.Descriptor, yPtr);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
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
            y = Vector.Create(new complexf[10], new VectorDescriptor(2, 1, 3));
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

            // Norm2
            GetVectors(out x, out y, out xPtr, out yPtr);
            var norm = BLAS.Norm2(x);
            Assert.AreEqual(Sqrt(1.1 * 1.1 + 1.2 * 1.2), norm, delta);
            norm = BLAS.Norm2(x.Descriptor, xPtr);
            Assert.AreEqual(Sqrt(1.1 * 1.1 + 1.2 * 1.2), norm, delta);
            norm = BLAS.Norm2(y);
            Assert.AreEqual(Sqrt(1.3 * 1.3 + 1.4 * 1.4), norm, delta);
            norm = BLAS.Norm2(y.Descriptor, yPtr);
            Assert.AreEqual(Sqrt(1.3 * 1.3 + 1.4 * 1.4), norm, delta);

            // Rotate
            var c = 1.5f;
            var s = 1.6f;
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.Rotate(x, y, c, s);
            Assert.AreEqual(x.Storage[0].AsDouble(), 3.73f, delta);
            Assert.AreEqual(x.Storage[1].AsDouble(), 4.04f, delta);
            Assert.AreEqual(y.Storage[1].AsDouble(), 0.19f, delta);
            Assert.AreEqual(y.Storage[4].AsDouble(), 0.18f, delta);
            BLAS.Rotate(x.Descriptor, xPtr, y.Descriptor, yPtr, c, s);
            Assert.AreEqual(xPtr[0].AsDouble(), 3.73f, delta);
            Assert.AreEqual(xPtr[1].AsDouble(), 4.04f, delta);
            Assert.AreEqual(yPtr[1].AsDouble(), 0.19f, delta);
            Assert.AreEqual(yPtr[4].AsDouble(), 0.18f, delta);

            // Scale
            GetVectors(out x, out y, out xPtr, out yPtr);
            complexf alpha = 1.5f;
            BLAS.Scale(alpha, x);
            Assert.AreEqual(1.1f * alpha.AsDouble(), x.Storage[0].AsDouble(), delta);
            Assert.AreEqual(1.2f * alpha.AsDouble(), x.Storage[1].AsDouble(), delta);
            BLAS.Scale(alpha, y);
            Assert.AreEqual(1.3f * alpha.AsDouble(), y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.4f * alpha.AsDouble(), y.Storage[4].AsDouble(), delta);
            BLAS.Scale(alpha, x.Descriptor, xPtr);
            Assert.AreEqual(1.1f * alpha.AsDouble(), xPtr[0].AsDouble(), delta);
            Assert.AreEqual(1.2f * alpha.AsDouble(), xPtr[1].AsDouble(), delta);
            BLAS.Scale(alpha, y.Descriptor, yPtr);
            Assert.AreEqual(1.3f * alpha.AsDouble(), yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.4f * alpha.AsDouble(), yPtr[4].AsDouble(), delta);

            // Swap
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.Swap(x, y);
            Assert.AreEqual(1.3f, x.Storage[0].AsDouble(), delta);
            Assert.AreEqual(1.4f, x.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.1f, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.2f, y.Storage[4].AsDouble(), delta);
            BLAS.Swap(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(1.3f, xPtr[0].AsDouble(), delta);
            Assert.AreEqual(1.4f, xPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.1f, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.2f, yPtr[4].AsDouble(), delta);

            // IAMax and IAMin
            GetVectors(out x, out y, out xPtr, out yPtr);
            int iAMax;
            int iAMin;
            iAMax = BLAS.IAMax(x);
            iAMin = BLAS.IAMin(x);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
            iAMax = BLAS.IAMax(y);
            iAMin = BLAS.IAMin(y);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
            iAMax = BLAS.IAMax(x.Descriptor, xPtr);
            iAMin = BLAS.IAMin(x.Descriptor, xPtr);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
            iAMax = BLAS.IAMax(y.Descriptor, yPtr);
            iAMin = BLAS.IAMin(y.Descriptor, yPtr);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
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
            y = Vector.Create(new complex[10], new VectorDescriptor(2, 1, 3));
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

            // Norm2
            GetVectors(out x, out y, out xPtr, out yPtr);
            var norm = BLAS.Norm2(x);
            Assert.AreEqual(Sqrt(1.1 * 1.1 + 1.2 * 1.2), norm, delta);
            norm = BLAS.Norm2(x.Descriptor, xPtr);
            Assert.AreEqual(Sqrt(1.1 * 1.1 + 1.2 * 1.2), norm, delta);
            norm = BLAS.Norm2(y);
            Assert.AreEqual(Sqrt(1.3 * 1.3 + 1.4 * 1.4), norm, delta);
            norm = BLAS.Norm2(y.Descriptor, yPtr);
            Assert.AreEqual(Sqrt(1.3 * 1.3 + 1.4 * 1.4), norm, delta);

            // Rotate
            var c = 1.5f;
            var s = 1.6f;
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.Rotate(x, y, c, s);
            Assert.AreEqual(x.Storage[0].AsDouble(), 3.73f, delta);
            Assert.AreEqual(x.Storage[1].AsDouble(), 4.04f, delta);
            Assert.AreEqual(y.Storage[1].AsDouble(), 0.19f, delta);
            Assert.AreEqual(y.Storage[4].AsDouble(), 0.18f, delta);
            BLAS.Rotate(x.Descriptor, xPtr, y.Descriptor, yPtr, c, s);
            Assert.AreEqual(xPtr[0].AsDouble(), 3.73f, delta);
            Assert.AreEqual(xPtr[1].AsDouble(), 4.04f, delta);
            Assert.AreEqual(yPtr[1].AsDouble(), 0.19f, delta);
            Assert.AreEqual(yPtr[4].AsDouble(), 0.18f, delta);

            // Scale
            GetVectors(out x, out y, out xPtr, out yPtr);
            complex alpha = 1.5f;
            BLAS.Scale(alpha, x);
            Assert.AreEqual(1.1f * alpha.AsDouble(), x.Storage[0].AsDouble(), delta);
            Assert.AreEqual(1.2f * alpha.AsDouble(), x.Storage[1].AsDouble(), delta);
            BLAS.Scale(alpha, y);
            Assert.AreEqual(1.3f * alpha.AsDouble(), y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.4f * alpha.AsDouble(), y.Storage[4].AsDouble(), delta);
            BLAS.Scale(alpha, x.Descriptor, xPtr);
            Assert.AreEqual(1.1f * alpha.AsDouble(), xPtr[0].AsDouble(), delta);
            Assert.AreEqual(1.2f * alpha.AsDouble(), xPtr[1].AsDouble(), delta);
            BLAS.Scale(alpha, y.Descriptor, yPtr);
            Assert.AreEqual(1.3f * alpha.AsDouble(), yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.4f * alpha.AsDouble(), yPtr[4].AsDouble(), delta);

            // Swap
            GetVectors(out x, out y, out xPtr, out yPtr);
            BLAS.Swap(x, y);
            Assert.AreEqual(1.3f, x.Storage[0].AsDouble(), delta);
            Assert.AreEqual(1.4f, x.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.1f, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.2f, y.Storage[4].AsDouble(), delta);
            BLAS.Swap(x.Descriptor, xPtr, y.Descriptor, yPtr);
            Assert.AreEqual(1.3f, xPtr[0].AsDouble(), delta);
            Assert.AreEqual(1.4f, xPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.1f, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.2f, yPtr[4].AsDouble(), delta);

            // IAMax and IAMin
            GetVectors(out x, out y, out xPtr, out yPtr);
            int iAMax;
            int iAMin;
            iAMax = BLAS.IAMax(x);
            iAMin = BLAS.IAMin(x);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
            iAMax = BLAS.IAMax(y);
            iAMin = BLAS.IAMin(y);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
            iAMax = BLAS.IAMax(x.Descriptor, xPtr);
            iAMin = BLAS.IAMin(x.Descriptor, xPtr);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
            iAMax = BLAS.IAMax(y.Descriptor, yPtr);
            iAMin = BLAS.IAMin(y.Descriptor, yPtr);
            Assert.AreEqual(1, iAMax);
            Assert.AreEqual(0, iAMin);
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

            // Rotate
            foreach (var h in new[]
            {
                new[] { 1.5f, 1.6f, 1.7f, 1.8f },
                new[] { 1f, 0f, 0f, 1f },
                new[] { 1f, 1.5f, 1.6f, 1f },
                new[] { 1.5f, 1f, -1f, 1.6f }
            })
            {
                var h11 = h[0];
                var h12 = h[1];
                var h21 = h[2];
                var h22 = h[3];
                GetVectors(out x, out y, out xPtr, out yPtr);
                BLAS.Rotate(x, y, h11, h12, h21, h22);
                Assert.AreEqual(1.1f * h11 + 1.3f * h12, x.Storage[0], delta);
                Assert.AreEqual(1.2f * h11 + 1.4f * h12, x.Storage[1], delta);
                Assert.AreEqual(1.1f * h21 + 1.3f * h22, y.Storage[1], delta);
                Assert.AreEqual(1.2f * h21 + 1.4f * h22, y.Storage[4], delta);
                BLAS.Rotate(x.Descriptor, xPtr, y.Descriptor, yPtr, h11, h12, h21, h22);
                Assert.AreEqual(1.1f * h11 + 1.3f * h12, xPtr[0], delta);
                Assert.AreEqual(1.2f * h11 + 1.4f * h12, xPtr[1], delta);
                Assert.AreEqual(1.1f * h21 + 1.3f * h22, yPtr[1], delta);
                Assert.AreEqual(1.2f * h21 + 1.4f * h22, yPtr[4], delta);
            }
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

            // Rotate
            foreach (var h in new[]
            {
                new[] { 1.5f, 1.6f, 1.7f, 1.8f },
                new[] { 1f, 0f, 0f, 1f },
                new[] { 1f, 1.5f, 1.6f, 1f },
                new[] { 1.5f, 1f, -1f, 1.6f }
            })
            {
                var h11 = h[0];
                var h12 = h[1];
                var h21 = h[2];
                var h22 = h[3];
                GetVectors(out x, out y, out xPtr, out yPtr);
                BLAS.Rotate(x, y, h11, h12, h21, h22);
                Assert.AreEqual(1.1f * h11 + 1.3f * h12, x.Storage[0], delta);
                Assert.AreEqual(1.2f * h11 + 1.4f * h12, x.Storage[1], delta);
                Assert.AreEqual(1.1f * h21 + 1.3f * h22, y.Storage[1], delta);
                Assert.AreEqual(1.2f * h21 + 1.4f * h22, y.Storage[4], delta);
                BLAS.Rotate(x.Descriptor, xPtr, y.Descriptor, yPtr, h11, h12, h21, h22);
                Assert.AreEqual(1.1f * h11 + 1.3f * h12, xPtr[0], delta);
                Assert.AreEqual(1.2f * h11 + 1.4f * h12, xPtr[1], delta);
                Assert.AreEqual(1.1f * h21 + 1.3f * h22, yPtr[1], delta);
                Assert.AreEqual(1.2f * h21 + 1.4f * h22, yPtr[4], delta);
            }
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
            y = Vector.Create(new complexf[10], new VectorDescriptor(2, 1, 3));
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

            // Scale
            GetVectors(out x, out y, out xPtr, out yPtr);
            float alpha = 1.5f;
            BLAS.Scale(alpha, x);
            Assert.AreEqual(1.1f * alpha, x.Storage[0].AsDouble(), delta);
            Assert.AreEqual(1.2f * alpha, x.Storage[1].AsDouble(), delta);
            BLAS.Scale(alpha, y);
            Assert.AreEqual(1.3f * alpha, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.4f * alpha, y.Storage[4].AsDouble(), delta);
            BLAS.Scale(alpha, x.Descriptor, xPtr);
            Assert.AreEqual(1.1f * alpha, xPtr[0].AsDouble(), delta);
            Assert.AreEqual(1.2f * alpha, xPtr[1].AsDouble(), delta);
            BLAS.Scale(alpha, y.Descriptor, yPtr);
            Assert.AreEqual(1.3f * alpha, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.4f * alpha, yPtr[4].AsDouble(), delta);
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
            y = Vector.Create(new complex[10], new VectorDescriptor(2, 1, 3));
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

            // Scale
            GetVectors(out x, out y, out xPtr, out yPtr);
            double alpha = 1.5f;
            BLAS.Scale(alpha, x);
            Assert.AreEqual(1.1f * alpha, x.Storage[0].AsDouble(), delta);
            Assert.AreEqual(1.2f * alpha, x.Storage[1].AsDouble(), delta);
            BLAS.Scale(alpha, y);
            Assert.AreEqual(1.3f * alpha, y.Storage[1].AsDouble(), delta);
            Assert.AreEqual(1.4f * alpha, y.Storage[4].AsDouble(), delta);
            BLAS.Scale(alpha, x.Descriptor, xPtr);
            Assert.AreEqual(1.1f * alpha, xPtr[0].AsDouble(), delta);
            Assert.AreEqual(1.2f * alpha, xPtr[1].AsDouble(), delta);
            BLAS.Scale(alpha, y.Descriptor, yPtr);
            Assert.AreEqual(1.3f * alpha, yPtr[1].AsDouble(), delta);
            Assert.AreEqual(1.4f * alpha, yPtr[4].AsDouble(), delta);
        }
    }
}
