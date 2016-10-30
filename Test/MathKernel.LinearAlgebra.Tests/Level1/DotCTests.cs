using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void DotCTest(complexf? value)
        {
            Vector<complexf> x;
            Vector<complexf> y;
            complexf* xPtr;
            complexf* yPtr;
            complexf i = complexf.ImaginaryOne;

            GetComplexVectors(bytes, out x, out y, out xPtr, out yPtr);

            complexf dot = BLAS.Dot(x.Conjugate(), y);
            Assert.IsTrue(AreEqual(8.3 - 0.08 * i, dot, delta));
            dot = BLAS.Dot(
                x.Descriptor.Conjugate(), xPtr + x.Offset,
                y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(8.3 - 0.08 * i, dot, delta));

            dot = BLAS.Dot(x, y.Conjugate());
            Assert.IsTrue(AreEqual(8.3 + 0.08 * i, dot, delta));
            dot = BLAS.Dot(
                x.Descriptor, xPtr + x.Offset,
                y.Descriptor.Conjugate(), yPtr + y.Offset);
            Assert.IsTrue(AreEqual(8.3 + 0.08 * i, dot, delta));

            dot = BLAS.Dot(y.Conjugate(), x);
            Assert.IsTrue(AreEqual(8.3 + 0.08 * i, dot, delta));
            dot = BLAS.Dot(
                y.Descriptor.Conjugate(), yPtr + y.Offset,
                x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(8.3 + 0.08 * i, dot, delta));

            dot = BLAS.Dot(y, x.Conjugate());
            Assert.IsTrue(AreEqual(8.3 - 0.08 * i, dot, delta));
            dot = BLAS.Dot(
                y.Descriptor, yPtr + y.Offset,
                x.Descriptor.Conjugate(), xPtr + x.Offset);
            Assert.IsTrue(AreEqual(8.3 - 0.08 * i, dot, delta));
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void DotCTest(complex? value)
        {
            Vector<complex> x;
            Vector<complex> y;
            complex* xPtr;
            complex* yPtr;
            complex i = complex.ImaginaryOne;

            GetComplexVectors(bytes, out x, out y, out xPtr, out yPtr);

            complex dot = BLAS.Dot(x.Conjugate(), y);
            Assert.IsTrue(AreEqual(8.3 - 0.08 * i, dot, delta));
            dot = BLAS.Dot(
                x.Descriptor.Conjugate(), xPtr + x.Offset,
                y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(8.3 - 0.08 * i, dot, delta));

            dot = BLAS.Dot(x, y.Conjugate());
            Assert.IsTrue(AreEqual(8.3 + 0.08 * i, dot, delta));
            dot = BLAS.Dot(
                x.Descriptor, xPtr + x.Offset,
                y.Descriptor.Conjugate(), yPtr + y.Offset);
            Assert.IsTrue(AreEqual(8.3 + 0.08 * i, dot, delta));

            dot = BLAS.Dot(y.Conjugate(), x);
            Assert.IsTrue(AreEqual(8.3 + 0.08 * i, dot, delta));
            dot = BLAS.Dot(
                y.Descriptor.Conjugate(), yPtr + y.Offset,
                x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(8.3 + 0.08 * i, dot, delta));

            dot = BLAS.Dot(y, x.Conjugate());
            Assert.IsTrue(AreEqual(8.3 - 0.08 * i, dot, delta));
            dot = BLAS.Dot(
                y.Descriptor, yPtr + y.Offset,
                x.Descriptor.Conjugate(), xPtr + x.Offset);
            Assert.IsTrue(AreEqual(8.3 - 0.08 * i, dot, delta));
        }
    }
}
