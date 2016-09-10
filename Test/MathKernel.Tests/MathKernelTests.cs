using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace MathKernel.Tests
{
    public class MathKernelTests
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
    }
}
