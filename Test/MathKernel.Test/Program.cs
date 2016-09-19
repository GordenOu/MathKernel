using System;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.DotNet.Cli.Utils;

namespace MathKernel.Test
{
    public class Program
    {
        private static string GetFilePath([CallerFilePath] string filePath = null)
        {
            return filePath;
        }

        public static void Main(string[] args)
        {
            var testProjectDirectories = new FileInfo(GetFilePath())
                .Directory
                .Parent
                .EnumerateDirectories("MathKernel*Tests", SearchOption.TopDirectoryOnly);
            bool passed = true;
            foreach (var directory in testProjectDirectories)
            {
                Console.WriteLine();
                Command.CreateDotNet("test", new[] { directory.FullName })
                    .OnErrorLine(line => passed = false)
                    .Execute();
            }
            if (!passed)
            {
                Environment.Exit(1);
            }
        }
    }
}
