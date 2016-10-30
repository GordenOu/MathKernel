using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    [RealTypeDuplicate(typeof(float))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void Norm2Test(float? value)
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            float norm = BLAS.Norm2(x);
            Assert.IsTrue(AreEqual(1.6279, norm, delta));
            norm = BLAS.Norm2(x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(1.6279, norm, delta));
            norm = BLAS.Norm2(y);
            Assert.IsTrue(AreEqual(1.9105, norm, delta));
            norm = BLAS.Norm2(y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(1.9105, norm, delta));
        }
    }

    [RealTypeDuplicate(typeof(double))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void Norm2Test(double? value)
        {
            Vector<double> x;
            Vector<double> y;
            double* xPtr;
            double* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            double norm = BLAS.Norm2(x);
            Assert.IsTrue(AreEqual(1.6279, norm, delta));
            norm = BLAS.Norm2(x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(1.6279, norm, delta));
            norm = BLAS.Norm2(y);
            Assert.IsTrue(AreEqual(1.9105, norm, delta));
            norm = BLAS.Norm2(y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(1.9105, norm, delta));
        }
    }

    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void Norm2Test(complexf? value)
        {
            Vector<complexf> x;
            Vector<complexf> y;
            complexf* xPtr;
            complexf* yPtr;

            GetComplexVectors(bytes, out x, out y, out xPtr, out yPtr);
            float norm = BLAS.Norm2(x);
            Assert.IsTrue(AreEqual(2.51, norm, delta));
            norm = BLAS.Norm2(x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(2.51, norm, delta));
            norm = BLAS.Norm2(y);
            Assert.IsTrue(AreEqual(3.3076, norm, delta));
            norm = BLAS.Norm2(y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(3.3076, norm, delta));
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void Norm2Test(complex? value)
        {
            Vector<complex> x;
            Vector<complex> y;
            complex* xPtr;
            complex* yPtr;

            GetComplexVectors(bytes, out x, out y, out xPtr, out yPtr);
            double norm = BLAS.Norm2(x);
            Assert.IsTrue(AreEqual(2.51, norm, delta));
            norm = BLAS.Norm2(x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(2.51, norm, delta));
            norm = BLAS.Norm2(y);
            Assert.IsTrue(AreEqual(3.3076, norm, delta));
            norm = BLAS.Norm2(y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(3.3076, norm, delta));
        }
    }
}
