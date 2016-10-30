using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    [Duplicate(typeof(float))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void SwapTest(float? value)
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Swap(x, y);
            Assert.IsTrue(AreEqual(1.3, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(1.4, x.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.1, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.2, y.Storage[4], delta));
            BLAS.Swap(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(1.3, xPtr[0], delta));
            Assert.IsTrue(AreEqual(1.4, xPtr[1], delta));
            Assert.IsTrue(AreEqual(1.1, yPtr[1], delta));
            Assert.IsTrue(AreEqual(1.2, yPtr[4], delta));

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Swap(y, x);
            Assert.IsTrue(AreEqual(1.3, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(1.4, x.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.1, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.2, y.Storage[4], delta));
            BLAS.Swap(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(1.3, xPtr[0], delta));
            Assert.IsTrue(AreEqual(1.4, xPtr[1], delta));
            Assert.IsTrue(AreEqual(1.1, yPtr[1], delta));
            Assert.IsTrue(AreEqual(1.2, yPtr[4], delta));
        }
    }
}
