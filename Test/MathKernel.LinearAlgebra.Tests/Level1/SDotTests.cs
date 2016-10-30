using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    public unsafe partial class Level1Tests
    {
        [TestMethod]
        public void SDotTest()
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            double sdot = BLAS.SDot(1, x, y);
            Assert.AreEqual(4.11, sdot, delta);
            sdot = BLAS.SDot(1, x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.AreEqual(4.11, sdot, delta);

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            sdot = BLAS.SDot(1, y, x);
            Assert.AreEqual(4.11, sdot, delta);
            sdot = BLAS.SDot(1, y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.AreEqual(4.11, sdot, delta);

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            sdot = BLAS.SDot(x, y);
            Assert.AreEqual(3.11, sdot, delta);
            sdot = BLAS.SDot(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.AreEqual(3.11, sdot, delta);

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            sdot = BLAS.SDot(y, x);
            Assert.AreEqual(3.11, sdot, delta);
            sdot = BLAS.SDot(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.AreEqual(3.11, sdot, delta);
        }
    }
}
