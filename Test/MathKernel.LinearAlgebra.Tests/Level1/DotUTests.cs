using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void DotUTest(complexf? value)
        {
            Vector<complexf> x;
            Vector<complexf> y;
            complexf* xPtr;
            complexf* yPtr;
            complexf i = complexf.ImaginaryOne;

            GetComplexVectors(bytes, out x, out y, out xPtr, out yPtr);
            complexf dot = BLAS.Dot(x, y);
            Assert.IsTrue(AreEqual(-0.58 + 8.28 * i, dot, delta));
            dot = BLAS.Dot(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(-0.58 + 8.28 * i, dot, delta));
            dot = BLAS.Dot(y, x);
            Assert.IsTrue(AreEqual(-0.58 + 8.28 * i, dot, delta));
            dot = BLAS.Dot(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(-0.58 + 8.28 * i, dot, delta));
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void DotUTest(complex? value)
        {
            Vector<complex> x;
            Vector<complex> y;
            complex* xPtr;
            complex* yPtr;
            complex i = complex.ImaginaryOne;

            GetComplexVectors(bytes, out x, out y, out xPtr, out yPtr);
            complex dot = BLAS.Dot(x, y);
            Assert.IsTrue(AreEqual(-0.58 + 8.28 * i, dot, delta));
            dot = BLAS.Dot(x.Descriptor, xPtr + x.Offset, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(-0.58 + 8.28 * i, dot, delta));
            dot = BLAS.Dot(y, x);
            Assert.IsTrue(AreEqual(-0.58 + 8.28 * i, dot, delta));
            dot = BLAS.Dot(y.Descriptor, yPtr + y.Offset, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(-0.58 + 8.28 * i, dot, delta));
        }
    }
}
