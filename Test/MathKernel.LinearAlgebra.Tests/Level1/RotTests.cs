using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    [Duplicate(typeof(float))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void RotTests(float? value)
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;

            var c = 1.5f;
            var s = 1.6f;
            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Rotate(x, y, c, s);
            Assert.IsTrue(AreEqual(3.73, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(4.04, x.Storage[1], delta));
            Assert.IsTrue(AreEqual(0.19, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(0.18, y.Storage[4], delta));
            BLAS.Rotate(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset, c, s);
            Assert.IsTrue(AreEqual(3.73, xPtr[0], delta));
            Assert.IsTrue(AreEqual(4.04, xPtr[1], delta));
            Assert.IsTrue(AreEqual(0.19, yPtr[1], delta));
            Assert.IsTrue(AreEqual(0.18, yPtr[4], delta));
            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Rotate(y, x, c, s);
            Assert.IsTrue(AreEqual(3.71, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(4.02, y.Storage[4], delta));
            Assert.IsTrue(AreEqual(-0.43, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(-0.44, x.Storage[1], delta));
            BLAS.Rotate(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset, c, s);
            Assert.IsTrue(AreEqual(3.71, yPtr[1], delta));
            Assert.IsTrue(AreEqual(4.02, yPtr[4], delta));
            Assert.IsTrue(AreEqual(-0.43, xPtr[0], delta));
            Assert.IsTrue(AreEqual(-0.44, xPtr[1], delta));
        }
    }

    [Duplicate(typeof(double))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void RotTests(double? value)
        {
            Vector<double> x;
            Vector<double> y;
            double* xPtr;
            double* yPtr;

            var c = 1.5f;
            var s = 1.6f;
            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Rotate(x, y, c, s);
            Assert.IsTrue(AreEqual(3.73, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(4.04, x.Storage[1], delta));
            Assert.IsTrue(AreEqual(0.19, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(0.18, y.Storage[4], delta));
            BLAS.Rotate(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset, c, s);
            Assert.IsTrue(AreEqual(3.73, xPtr[0], delta));
            Assert.IsTrue(AreEqual(4.04, xPtr[1], delta));
            Assert.IsTrue(AreEqual(0.19, yPtr[1], delta));
            Assert.IsTrue(AreEqual(0.18, yPtr[4], delta));
            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Rotate(y, x, c, s);
            Assert.IsTrue(AreEqual(3.71, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(4.02, y.Storage[4], delta));
            Assert.IsTrue(AreEqual(-0.43, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(-0.44, x.Storage[1], delta));
            BLAS.Rotate(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset, c, s);
            Assert.IsTrue(AreEqual(3.71, yPtr[1], delta));
            Assert.IsTrue(AreEqual(4.02, yPtr[4], delta));
            Assert.IsTrue(AreEqual(-0.43, xPtr[0], delta));
            Assert.IsTrue(AreEqual(-0.44, xPtr[1], delta));
        }
    }

    [Duplicate(typeof(complexf))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void RotTests(complexf? value)
        {
            Vector<complexf> x;
            Vector<complexf> y;
            complexf* xPtr;
            complexf* yPtr;

            var c = 1.5f;
            var s = 1.6f;
            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Rotate(x, y, c, s);
            Assert.IsTrue(AreEqual(3.73, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(4.04, x.Storage[1], delta));
            Assert.IsTrue(AreEqual(0.19, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(0.18, y.Storage[4], delta));
            BLAS.Rotate(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset, c, s);
            Assert.IsTrue(AreEqual(3.73, xPtr[0], delta));
            Assert.IsTrue(AreEqual(4.04, xPtr[1], delta));
            Assert.IsTrue(AreEqual(0.19, yPtr[1], delta));
            Assert.IsTrue(AreEqual(0.18, yPtr[4], delta));
            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Rotate(y, x, c, s);
            Assert.IsTrue(AreEqual(3.71, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(4.02, y.Storage[4], delta));
            Assert.IsTrue(AreEqual(-0.43, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(-0.44, x.Storage[1], delta));
            BLAS.Rotate(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset, c, s);
            Assert.IsTrue(AreEqual(3.71, yPtr[1], delta));
            Assert.IsTrue(AreEqual(4.02, yPtr[4], delta));
            Assert.IsTrue(AreEqual(-0.43, xPtr[0], delta));
            Assert.IsTrue(AreEqual(-0.44, xPtr[1], delta));
        }
    }

    [Duplicate(typeof(complex))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void RotTests(complex? value)
        {
            Vector<complex> x;
            Vector<complex> y;
            complex* xPtr;
            complex* yPtr;

            var c = 1.5f;
            var s = 1.6f;
            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Rotate(x, y, c, s);
            Assert.IsTrue(AreEqual(3.73, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(4.04, x.Storage[1], delta));
            Assert.IsTrue(AreEqual(0.19, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(0.18, y.Storage[4], delta));
            BLAS.Rotate(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset, c, s);
            Assert.IsTrue(AreEqual(3.73, xPtr[0], delta));
            Assert.IsTrue(AreEqual(4.04, xPtr[1], delta));
            Assert.IsTrue(AreEqual(0.19, yPtr[1], delta));
            Assert.IsTrue(AreEqual(0.18, yPtr[4], delta));
            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Rotate(y, x, c, s);
            Assert.IsTrue(AreEqual(3.71, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(4.02, y.Storage[4], delta));
            Assert.IsTrue(AreEqual(-0.43, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(-0.44, x.Storage[1], delta));
            BLAS.Rotate(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset, c, s);
            Assert.IsTrue(AreEqual(3.71, yPtr[1], delta));
            Assert.IsTrue(AreEqual(4.02, yPtr[4], delta));
            Assert.IsTrue(AreEqual(-0.43, xPtr[0], delta));
            Assert.IsTrue(AreEqual(-0.44, xPtr[1], delta));
        }
    }
}
