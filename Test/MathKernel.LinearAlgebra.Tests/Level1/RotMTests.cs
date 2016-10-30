using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    [RealTypeDuplicate(typeof(float))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void RotmTest(float? value)
        {
            Vector<float> x;
            Vector<float> y;
            float* xPtr;
            float* yPtr;

            // Rotate
            foreach (var h in new[]
            {
                new[] { 1.5f, 1.6f, 1.7f, 1.8f },
                new[] { 1f, 0f, 0f, 1f },
                new[] { 1f, 1.5f, 1.6f, 1f },
                new[] { 1.5f, 1f, -1f, 1.6f }
            })
            {
                var h11 = h[0];
                var h12 = h[1];
                var h21 = h[2];
                var h22 = h[3];

                GetVectors(bytes, out x, out y, out xPtr, out yPtr);
                BLAS.Rotate(x, y, h11, h12, h21, h22);
                Assert.IsTrue(AreEqual(1.1 * h11 + 1.3 * h12, x.Storage[0], delta));
                Assert.IsTrue(AreEqual(1.2 * h11 + 1.4 * h12, x.Storage[1], delta));
                Assert.IsTrue(AreEqual(1.1 * h21 + 1.3 * h22, y.Storage[1], delta));
                Assert.IsTrue(AreEqual(1.2 * h21 + 1.4 * h22, y.Storage[4], delta));
                BLAS.Rotate(
                    x.Descriptor, xPtr + x.Offset,
                    y.Descriptor, yPtr + y.Offset,
                    h11, h12, h21, h22);
                Assert.IsTrue(AreEqual(1.1 * h11 + 1.3 * h12, xPtr[0], delta));
                Assert.IsTrue(AreEqual(1.2 * h11 + 1.4 * h12, xPtr[1], delta));
                Assert.IsTrue(AreEqual(1.1 * h21 + 1.3 * h22, yPtr[1], delta));
                Assert.IsTrue(AreEqual(1.2 * h21 + 1.4 * h22, yPtr[4], delta));

                GetVectors(bytes, out x, out y, out xPtr, out yPtr);
                BLAS.Rotate(y, x, h11, h12, h21, h22);
                Assert.IsTrue(AreEqual(1.3 * h11 + 1.1 * h12, y.Storage[1], delta));
                Assert.IsTrue(AreEqual(1.4 * h11 + 1.2 * h12, y.Storage[4], delta));
                Assert.IsTrue(AreEqual(1.3 * h21 + 1.1 * h22, x.Storage[0], delta));
                Assert.IsTrue(AreEqual(1.4 * h21 + 1.2 * h22, x.Storage[1], delta));
                BLAS.Rotate(
                    y.Descriptor, yPtr + y.Offset,
                    x.Descriptor, xPtr + x.Offset,
                    h11, h12, h21, h22);
                Assert.IsTrue(AreEqual(1.3 * h11 + 1.1 * h12, yPtr[1], delta));
                Assert.IsTrue(AreEqual(1.4 * h11 + 1.2 * h12, yPtr[4], delta));
                Assert.IsTrue(AreEqual(1.3 * h21 + 1.1 * h22, xPtr[0], delta));
                Assert.IsTrue(AreEqual(1.4 * h21 + 1.2 * h22, xPtr[1], delta));
            }
        }
    }

    [RealTypeDuplicate(typeof(double))]
    public unsafe partial class Level1Tests
    {
        [DataTestMethod]
        [DataRow(null)]
        public void RotmTest(double? value)
        {
            Vector<double> x;
            Vector<double> y;
            double* xPtr;
            double* yPtr;

            // Rotate
            foreach (var h in new[]
            {
                new[] { 1.5f, 1.6f, 1.7f, 1.8f },
                new[] { 1f, 0f, 0f, 1f },
                new[] { 1f, 1.5f, 1.6f, 1f },
                new[] { 1.5f, 1f, -1f, 1.6f }
            })
            {
                var h11 = h[0];
                var h12 = h[1];
                var h21 = h[2];
                var h22 = h[3];

                GetVectors(bytes, out x, out y, out xPtr, out yPtr);
                BLAS.Rotate(x, y, h11, h12, h21, h22);
                Assert.IsTrue(AreEqual(1.1 * h11 + 1.3 * h12, x.Storage[0], delta));
                Assert.IsTrue(AreEqual(1.2 * h11 + 1.4 * h12, x.Storage[1], delta));
                Assert.IsTrue(AreEqual(1.1 * h21 + 1.3 * h22, y.Storage[1], delta));
                Assert.IsTrue(AreEqual(1.2 * h21 + 1.4 * h22, y.Storage[4], delta));
                BLAS.Rotate(
                    x.Descriptor, xPtr + x.Offset,
                    y.Descriptor, yPtr + y.Offset,
                    h11, h12, h21, h22);
                Assert.IsTrue(AreEqual(1.1 * h11 + 1.3 * h12, xPtr[0], delta));
                Assert.IsTrue(AreEqual(1.2 * h11 + 1.4 * h12, xPtr[1], delta));
                Assert.IsTrue(AreEqual(1.1 * h21 + 1.3 * h22, yPtr[1], delta));
                Assert.IsTrue(AreEqual(1.2 * h21 + 1.4 * h22, yPtr[4], delta));

                GetVectors(bytes, out x, out y, out xPtr, out yPtr);
                BLAS.Rotate(y, x, h11, h12, h21, h22);
                Assert.IsTrue(AreEqual(1.3 * h11 + 1.1 * h12, y.Storage[1], delta));
                Assert.IsTrue(AreEqual(1.4 * h11 + 1.2 * h12, y.Storage[4], delta));
                Assert.IsTrue(AreEqual(1.3 * h21 + 1.1 * h22, x.Storage[0], delta));
                Assert.IsTrue(AreEqual(1.4 * h21 + 1.2 * h22, x.Storage[1], delta));
                BLAS.Rotate(
                    y.Descriptor, yPtr + y.Offset,
                    x.Descriptor, xPtr + x.Offset,
                    h11, h12, h21, h22);
                Assert.IsTrue(AreEqual(1.3 * h11 + 1.1 * h12, yPtr[1], delta));
                Assert.IsTrue(AreEqual(1.4 * h11 + 1.2 * h12, yPtr[4], delta));
                Assert.IsTrue(AreEqual(1.3 * h21 + 1.1 * h22, xPtr[0], delta));
                Assert.IsTrue(AreEqual(1.4 * h21 + 1.2 * h22, xPtr[1], delta));
            }
        }
    }
}
