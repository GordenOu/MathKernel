using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    [Duplicate(typeof(float))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void IAMinTest(float? value)
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            Assert.AreEqual(0, BLAS.IAMin(x));
            Assert.AreEqual(0, BLAS.IAMin(y));
            x.Storage[0] = 3;
            y.Storage[1] = 3;
            Assert.AreEqual(1, BLAS.IAMin(y));
            Assert.AreEqual(1, BLAS.IAMin(x));
            Assert.AreEqual(0, BLAS.IAMin(x.Descriptor, xPtr + x.Offset));
            Assert.AreEqual(0, BLAS.IAMin(y.Descriptor, yPtr + y.Offset));
            xPtr[0] = 3;
            yPtr[1] = 3;
            Assert.AreEqual(1, BLAS.IAMin(x.Descriptor, xPtr + x.Offset));
            Assert.AreEqual(1, BLAS.IAMin(y.Descriptor, yPtr + y.Offset));
        }
    }

    [Duplicate(typeof(double))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void IAMinTest(double? value)
        {
            Vector<double> x;
            Vector<double> y;
            double* xPtr;
            double* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            Assert.AreEqual(0, BLAS.IAMin(x));
            Assert.AreEqual(0, BLAS.IAMin(y));
            x.Storage[0] = 3;
            y.Storage[1] = 3;
            Assert.AreEqual(1, BLAS.IAMin(y));
            Assert.AreEqual(1, BLAS.IAMin(x));
            Assert.AreEqual(0, BLAS.IAMin(x.Descriptor, xPtr + x.Offset));
            Assert.AreEqual(0, BLAS.IAMin(y.Descriptor, yPtr + y.Offset));
            xPtr[0] = 3;
            yPtr[1] = 3;
            Assert.AreEqual(1, BLAS.IAMin(x.Descriptor, xPtr + x.Offset));
            Assert.AreEqual(1, BLAS.IAMin(y.Descriptor, yPtr + y.Offset));
        }
    }

    [Duplicate(typeof(complexf))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void IAMinTest(complexf? value)
        {
            Vector<complexf> x;
            Vector<complexf> y;
            complexf* xPtr;
            complexf* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            Assert.AreEqual(0, BLAS.IAMin(x));
            Assert.AreEqual(0, BLAS.IAMin(y));
            x.Storage[0] = 3;
            y.Storage[1] = 3;
            Assert.AreEqual(1, BLAS.IAMin(y));
            Assert.AreEqual(1, BLAS.IAMin(x));
            Assert.AreEqual(0, BLAS.IAMin(x.Descriptor, xPtr + x.Offset));
            Assert.AreEqual(0, BLAS.IAMin(y.Descriptor, yPtr + y.Offset));
            xPtr[0] = 3;
            yPtr[1] = 3;
            Assert.AreEqual(1, BLAS.IAMin(x.Descriptor, xPtr + x.Offset));
            Assert.AreEqual(1, BLAS.IAMin(y.Descriptor, yPtr + y.Offset));
        }
    }

    [Duplicate(typeof(complex))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void IAMinTest(complex? value)
        {
            Vector<complex> x;
            Vector<complex> y;
            complex* xPtr;
            complex* yPtr;

            GetVectors(bytes, out x, out y, out xPtr, out yPtr);
            Assert.AreEqual(0, BLAS.IAMin(x));
            Assert.AreEqual(0, BLAS.IAMin(y));
            x.Storage[0] = 3;
            y.Storage[1] = 3;
            Assert.AreEqual(1, BLAS.IAMin(y));
            Assert.AreEqual(1, BLAS.IAMin(x));
            Assert.AreEqual(0, BLAS.IAMin(x.Descriptor, xPtr + x.Offset));
            Assert.AreEqual(0, BLAS.IAMin(y.Descriptor, yPtr + y.Offset));
            xPtr[0] = 3;
            yPtr[1] = 3;
            Assert.AreEqual(1, BLAS.IAMin(x.Descriptor, xPtr + x.Offset));
            Assert.AreEqual(1, BLAS.IAMin(y.Descriptor, yPtr + y.Offset));
        }
    }
}
