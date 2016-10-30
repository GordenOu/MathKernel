using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    [RealTypeDuplicate(typeof(float))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void ASumTest(float? value)
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            var sum = BLAS.ASum(x);
            Assert.IsTrue(AreEqual(2.3, sum, delta));
            sum = BLAS.ASum(x.Descriptor, xPtr);
            Assert.IsTrue(AreEqual(2.3, sum, delta));
            sum = BLAS.ASum(y);
            Assert.IsTrue(AreEqual(2.7, sum, delta));
            sum = BLAS.ASum(y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(2.7, sum, delta));
        }
    }

    [RealTypeDuplicate(typeof(double))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void ASumTest(double? value)
        {
            Vector<double> x;
            Vector<double> y;
            double* xPtr;
            double* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            var sum = BLAS.ASum(x);
            Assert.IsTrue(AreEqual(2.3, sum, delta));
            sum = BLAS.ASum(x.Descriptor, xPtr);
            Assert.IsTrue(AreEqual(2.3, sum, delta));
            sum = BLAS.ASum(y);
            Assert.IsTrue(AreEqual(2.7, sum, delta));
            sum = BLAS.ASum(y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(2.7, sum, delta));
        }
    }

    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void ASumTest(complexf? value)
        {
            Vector<complexf> x;
            Vector<complexf> y;
            complexf* xPtr;
            complexf* yPtr;

            GetComplexVectors(bytes, out x, out y, out xPtr, out yPtr);
            var sum = BLAS.ASum(x);
            Assert.IsTrue(AreEqual(5, sum, delta));
            sum = BLAS.ASum(x.Descriptor, xPtr);
            Assert.IsTrue(AreEqual(5, sum, delta));
            sum = BLAS.ASum(y);
            Assert.IsTrue(AreEqual(6.6, sum, delta));
            sum = BLAS.ASum(y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(6.6, sum, delta));
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void ASumTest(complex? value)
        {
            Vector<complex> x;
            Vector<complex> y;
            complex* xPtr;
            complex* yPtr;

            GetComplexVectors(bytes, out x, out y, out xPtr, out yPtr);
            var sum = BLAS.ASum(x);
            Assert.IsTrue(AreEqual(5, sum, delta));
            sum = BLAS.ASum(x.Descriptor, xPtr);
            Assert.IsTrue(AreEqual(5, sum, delta));
            sum = BLAS.ASum(y);
            Assert.IsTrue(AreEqual(6.6, sum, delta));
            sum = BLAS.ASum(y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(6.6, sum, delta));
        }
    }
}
