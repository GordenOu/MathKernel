using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    [Duplicate(typeof(float))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void CopyTest(float? value)
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Copy(x, y);
            Assert.IsTrue(AreEqual(1.1, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.2, y.Storage[4], delta));
            BLAS.Copy(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(1.1, yPtr[1], delta));
            Assert.IsTrue(AreEqual(1.2, yPtr[4], delta));

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Copy(y, x);
            Assert.IsTrue(AreEqual(1.3, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(1.4, x.Storage[1], delta));
            BLAS.Copy(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(1.3, xPtr[0], delta));
            Assert.IsTrue(AreEqual(1.4, xPtr[1], delta));
        }
    }

    [Duplicate(typeof(double))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void CopyTest(double? value)
        {
            Vector<double> x;
            Vector<double> y;
            double* xPtr;
            double* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Copy(x, y);
            Assert.IsTrue(AreEqual(1.1, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.2, y.Storage[4], delta));
            BLAS.Copy(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(1.1, yPtr[1], delta));
            Assert.IsTrue(AreEqual(1.2, yPtr[4], delta));

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Copy(y, x);
            Assert.IsTrue(AreEqual(1.3, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(1.4, x.Storage[1], delta));
            BLAS.Copy(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(1.3, xPtr[0], delta));
            Assert.IsTrue(AreEqual(1.4, xPtr[1], delta));
        }
    }

    [Duplicate(typeof(complexf))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void CopyTest(complexf? value)
        {
            Vector<complexf> x;
            Vector<complexf> y;
            complexf* xPtr;
            complexf* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Copy(x, y);
            Assert.IsTrue(AreEqual(1.1, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.2, y.Storage[4], delta));
            BLAS.Copy(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(1.1, yPtr[1], delta));
            Assert.IsTrue(AreEqual(1.2, yPtr[4], delta));

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Copy(y, x);
            Assert.IsTrue(AreEqual(1.3, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(1.4, x.Storage[1], delta));
            BLAS.Copy(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(1.3, xPtr[0], delta));
            Assert.IsTrue(AreEqual(1.4, xPtr[1], delta));
        }
    }

    [Duplicate(typeof(complex))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void CopyTest(complex? value)
        {
            Vector<complex> x;
            Vector<complex> y;
            complex* xPtr;
            complex* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Copy(x, y);
            Assert.IsTrue(AreEqual(1.1, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.2, y.Storage[4], delta));
            BLAS.Copy(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(1.1, yPtr[1], delta));
            Assert.IsTrue(AreEqual(1.2, yPtr[4], delta));

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Copy(y, x);
            Assert.IsTrue(AreEqual(1.3, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(1.4, x.Storage[1], delta));
            BLAS.Copy(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(1.3, xPtr[0], delta));
            Assert.IsTrue(AreEqual(1.4, xPtr[1], delta));
        }
    }
}
