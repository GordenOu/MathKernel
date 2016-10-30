using System;
using MathKernel.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.LinearAlgebra.Tests.Level1
{
    [TestClass]
    public partial class Level1Tests : BLASTests, IDisposable
    {
        private Bytes bytes;

        public Level1Tests()
        {
            Initialize();
        }

        [TestInitialize]
        public void Initialize()
        {
            bytes = new Bytes(65536);
        }

        [TestCleanup]
        public void Dispose()
        {
            bytes.Dispose();
        }
    }
}
