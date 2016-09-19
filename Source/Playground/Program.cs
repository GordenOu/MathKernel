using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Playground
{
    public unsafe class Program
    {
        private static string GetFilePath([CallerFilePath] string filePath = null)
        {
            return filePath;
        }

        static Program()
        {
            var solutionDirectory = new FileInfo(GetFilePath()).Directory.Parent.Parent;
            string path = Environment.GetEnvironmentVariable(nameof(Path));
            path = string.Join(Path.PathSeparator.ToString(),
                Path.Combine(solutionDirectory.FullName, "Native", "MKL"),
                path);
            Environment.SetEnvironmentVariable(nameof(Path), path);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Yo~");
        }
    }
}
