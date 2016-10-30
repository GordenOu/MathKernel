using System;
using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    [Duplicate(typeof(float))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void ScalTest(float? value)
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;
            float alpha = 1.5f;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Scale(alpha, x);
            Assert.IsTrue(AreEqual(1.1 * alpha, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(1.2 * alpha, x.Storage[1], delta));
            BLAS.Scale(alpha, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(1.1 * alpha, xPtr[0], delta));
            Assert.IsTrue(AreEqual(1.2 * alpha, xPtr[1], delta));
            BLAS.Scale(alpha, y);
            Assert.IsTrue(AreEqual(1.3 * alpha, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.4 * alpha, y.Storage[4], delta));
            BLAS.Scale(alpha, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(1.3 * alpha, yPtr[1], delta));
            Assert.IsTrue(AreEqual(1.4 * alpha, yPtr[4], delta));
        }
    }

    [Duplicate(typeof(double))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void ScalTest(double? value)
        {
            Vector<double> x;
            Vector<double> y;
            double* xPtr;
            double* yPtr;
            double alpha = 1.5f;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Scale(alpha, x);
            Assert.IsTrue(AreEqual(1.1 * alpha, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(1.2 * alpha, x.Storage[1], delta));
            BLAS.Scale(alpha, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(1.1 * alpha, xPtr[0], delta));
            Assert.IsTrue(AreEqual(1.2 * alpha, xPtr[1], delta));
            BLAS.Scale(alpha, y);
            Assert.IsTrue(AreEqual(1.3 * alpha, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.4 * alpha, y.Storage[4], delta));
            BLAS.Scale(alpha, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(1.3 * alpha, yPtr[1], delta));
            Assert.IsTrue(AreEqual(1.4 * alpha, yPtr[4], delta));
        }
    }

    [Duplicate(typeof(complexf))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void ScalTest(complexf? value)
        {
            Vector<complexf> x;
            Vector<complexf> y;
            complexf* xPtr;
            complexf* yPtr;
            complexf alpha = 1.5f;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Scale(alpha, x);
            Assert.IsTrue(AreEqual(1.1 * alpha, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(1.2 * alpha, x.Storage[1], delta));
            BLAS.Scale(alpha, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(1.1 * alpha, xPtr[0], delta));
            Assert.IsTrue(AreEqual(1.2 * alpha, xPtr[1], delta));
            BLAS.Scale(alpha, y);
            Assert.IsTrue(AreEqual(1.3 * alpha, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.4 * alpha, y.Storage[4], delta));
            BLAS.Scale(alpha, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(1.3 * alpha, yPtr[1], delta));
            Assert.IsTrue(AreEqual(1.4 * alpha, yPtr[4], delta));
        }
    }

    [Duplicate(typeof(complex))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void ScalTest(complex? value)
        {
            Vector<complex> x;
            Vector<complex> y;
            complex* xPtr;
            complex* yPtr;
            complex alpha = 1.5f;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Scale(alpha, x);
            Assert.IsTrue(AreEqual(1.1 * alpha, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(1.2 * alpha, x.Storage[1], delta));
            BLAS.Scale(alpha, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(1.1 * alpha, xPtr[0], delta));
            Assert.IsTrue(AreEqual(1.2 * alpha, xPtr[1], delta));
            BLAS.Scale(alpha, y);
            Assert.IsTrue(AreEqual(1.3 * alpha, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.4 * alpha, y.Storage[4], delta));
            BLAS.Scale(alpha, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(1.3 * alpha, yPtr[1], delta));
            Assert.IsTrue(AreEqual(1.4 * alpha, yPtr[4], delta));
        }
    }

    [ComplexTypeDuplicate(typeof(complexf))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void ScalTest(Lazy<complexf> value)
        {
            Vector<complexf> x;
            Vector<complexf> y;
            complexf* xPtr;
            complexf* yPtr;
            float alpha = 1.5f;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Scale(alpha, x);
            Assert.IsTrue(AreEqual(1.1 * alpha, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(1.2 * alpha, x.Storage[1], delta));
            BLAS.Scale(alpha, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(1.1 * alpha, xPtr[0], delta));
            Assert.IsTrue(AreEqual(1.2 * alpha, xPtr[1], delta));
            BLAS.Scale(alpha, y);
            Assert.IsTrue(AreEqual(1.3 * alpha, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.4 * alpha, y.Storage[4], delta));
            BLAS.Scale(alpha, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(1.3 * alpha, yPtr[1], delta));
            Assert.IsTrue(AreEqual(1.4 * alpha, yPtr[4], delta));
        }
    }

    [ComplexTypeDuplicate(typeof(complex))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void ScalTest(Lazy<complex> value)
        {
            Vector<complex> x;
            Vector<complex> y;
            complex* xPtr;
            complex* yPtr;
            double alpha = 1.5f;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            BLAS.Scale(alpha, x);
            Assert.IsTrue(AreEqual(1.1 * alpha, x.Storage[0], delta));
            Assert.IsTrue(AreEqual(1.2 * alpha, x.Storage[1], delta));
            BLAS.Scale(alpha, x.Descriptor, xPtr + x.Offset);
            Assert.IsTrue(AreEqual(1.1 * alpha, xPtr[0], delta));
            Assert.IsTrue(AreEqual(1.2 * alpha, xPtr[1], delta));
            BLAS.Scale(alpha, y);
            Assert.IsTrue(AreEqual(1.3 * alpha, y.Storage[1], delta));
            Assert.IsTrue(AreEqual(1.4 * alpha, y.Storage[4], delta));
            BLAS.Scale(alpha, y.Descriptor, yPtr + y.Offset);
            Assert.IsTrue(AreEqual(1.3 * alpha, yPtr[1], delta));
            Assert.IsTrue(AreEqual(1.4 * alpha, yPtr[4], delta));
        }
    }
}
