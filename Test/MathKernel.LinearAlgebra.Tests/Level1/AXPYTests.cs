using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    [Duplicate(typeof(float))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void AXPYTest(float? value)
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.AXPY(1, x, y);
            Assert.IsTrue(AreEqual(2.4, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(2.6, y.Storage[4], delta));
            BLAS.AXPY(1, x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(2.4, yPtr[1], delta));
            Assert.IsTrue(AreEqual(2.6, yPtr[4], delta));

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.AXPY(1, y, x);
            Assert.IsTrue(AreEqual(2.4, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(2.6, x.Storage[1], delta));
            BLAS.AXPY(1, y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(2.4, xPtr[0], delta));
            Assert.IsTrue(AreEqual(2.6, xPtr[1], delta));
        }
    }

    [Duplicate(typeof(double))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void AXPYTest(double? value)
        {
            Vector<double> x;
            Vector<double> y;
            double* xPtr;
            double* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.AXPY(1, x, y);
            Assert.IsTrue(AreEqual(2.4, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(2.6, y.Storage[4], delta));
            BLAS.AXPY(1, x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(2.4, yPtr[1], delta));
            Assert.IsTrue(AreEqual(2.6, yPtr[4], delta));

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.AXPY(1, y, x);
            Assert.IsTrue(AreEqual(2.4, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(2.6, x.Storage[1], delta));
            BLAS.AXPY(1, y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(2.4, xPtr[0], delta));
            Assert.IsTrue(AreEqual(2.6, xPtr[1], delta));
        }
    }

    [Duplicate(typeof(complexf))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void AXPYTest(complexf? value)
        {
            Vector<complexf> x;
            Vector<complexf> y;
            complexf* xPtr;
            complexf* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.AXPY(1, x, y);
            Assert.IsTrue(AreEqual(2.4, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(2.6, y.Storage[4], delta));
            BLAS.AXPY(1, x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(2.4, yPtr[1], delta));
            Assert.IsTrue(AreEqual(2.6, yPtr[4], delta));

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.AXPY(1, y, x);
            Assert.IsTrue(AreEqual(2.4, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(2.6, x.Storage[1], delta));
            BLAS.AXPY(1, y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(2.4, xPtr[0], delta));
            Assert.IsTrue(AreEqual(2.6, xPtr[1], delta));
        }
    }

    [Duplicate(typeof(complex))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void AXPYTest(complex? value)
        {
            Vector<complex> x;
            Vector<complex> y;
            complex* xPtr;
            complex* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.AXPY(1, x, y);
            Assert.IsTrue(AreEqual(2.4, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(2.6, y.Storage[4], delta));
            BLAS.AXPY(1, x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(2.4, yPtr[1], delta));
            Assert.IsTrue(AreEqual(2.6, yPtr[4], delta));

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.AXPY(1, y, x);
            Assert.IsTrue(AreEqual(2.4, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(2.6, x.Storage[1], delta));
            BLAS.AXPY(1, y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(2.4, xPtr[0], delta));
            Assert.IsTrue(AreEqual(2.6, xPtr[1], delta));
        }
    }
}
