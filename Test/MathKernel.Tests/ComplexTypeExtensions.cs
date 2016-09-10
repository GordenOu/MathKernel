using System;

namespace MathKernel.Tests
{
    internal static class ComplexTypeExtensions
    {
        public static double AsDouble(this float value)
        {
            return value;
        }

        public static double AsDouble(this double value)
        {
            return value;
        }

        public static double AsDouble(this complexf value)
        {
            if (value.Imaginary != 0)
            {
                throw new ArgumentException();
            }

            return value.Real;
        }

        public static double AsDouble(this complex value)
        {
            if (value.Imaginary != 0)
            {
                throw new ArgumentException();
            }

            return value.Real;
        }
    }
}
