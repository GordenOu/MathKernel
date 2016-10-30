using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    [RealTypeDuplicate(typeof(float))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void DotTest(float? value)
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            var dot = BLAS.Dot(x, y);
            Assert.AreEqual(3.11, dot, delta);
            dot = BLAS.Dot(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.AreEqual(3.11, dot, delta);

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            dot = BLAS.Dot(y, x);
            Assert.AreEqual(3.11, dot, delta);
            dot = BLAS.Dot(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.AreEqual(3.11, dot, delta);
        }
    }

    [RealTypeDuplicate(typeof(double))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void DotTest(double? value)
        {
            Vector<double> x;
            Vector<double> y;
            double* xPtr;
            double* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            var dot = BLAS.Dot(x, y);
            Assert.AreEqual(3.11, dot, delta);
            dot = BLAS.Dot(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.AreEqual(3.11, dot, delta);

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            dot = BLAS.Dot(y, x);
            Assert.AreEqual(3.11, dot, delta);
            dot = BLAS.Dot(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.AreEqual(3.11, dot, delta);
        }
    }
}
