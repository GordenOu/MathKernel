using System;
using System.IO;
using System.Runtime.CompilerServices;
using static System.Math;

namespace MathKernel.Tests
{
    public abstract class MathKernelTests
    {
        private static string GetFilePath([CallerFilePath] string filePath = null)
        {
            return filePath;
        }

        static MathKernelTests()
        {
            var solutionDirectory = new FileInfo(GetFilePath()).Directory.Parent.Parent;
            string path = Environment.GetEnvironmentVariable(nameof(Path));
            path = string.Join(Path.PathSeparator.ToString(),
                Path.Combine(solutionDirectory.FullName, "Native", "MKL"),
                path);
            Environment.SetEnvironmentVariable(nameof(Path), path);
        }

        public static bool AreEqual(double x, double y, double delta)
        {
            return (Abs(x - y) < Max(delta * Max(Abs(x), Abs(y)), 1e-6));
        }

        public static bool AreEqual(complex x, complex y, double delta)
        {
            return AreEqual(x.Real, y.Real, delta) && AreEqual(x.Imaginary, y.Imaginary, delta);
        }
    }
}
