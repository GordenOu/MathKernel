using System.Linq;
using System.Reflection;
using MathKernel.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathKernel.Tests.Resources
{
    [TestClass]
    public class StringsTests : MathKernelTests
    {
        [TestMethod]
        public void AllResourceStringsAreValid()
        {
            var properties = typeof(Strings).GetProperties();
            Assert.AreNotEqual(0, properties.Length);
            Assert.IsTrue(properties.All(x => x.PropertyType == typeof(string)));
            foreach (var property in properties)
            {
                string value = property.GetValue(null) as string;
                Assert.IsFalse(string.IsNullOrEmpty(value));
            }
        }
    }
}
