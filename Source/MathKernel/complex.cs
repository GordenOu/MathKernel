using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices;

namespace MathKernel
{
    [StructLayout(LayoutKind.Sequential)]
    public struct complex : IEquatable<complex>, IFormattable
    {
        public static readonly complex Zero = new complex(0, 0);
        public static readonly complex One = new complex(1, 0);
        public static readonly complex ImaginaryOne = new complex(0, 1);

        public double Real { get; }

        public double Imaginary { get; }

        public complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static complex Negate(complex value)
        {
            return -value;
        }

        public static complex Add(complex left, complex right)
        {
            return left + right;
        }

        public static complex Subtract(complex left, complex right)
        {
            return left - right;
        }

        public static complex Multiply(complex left, complex right)
        {
            return left * right;
        }

        public static complex Divide(complex dividend, complex divisor)
        {
            return dividend / divisor;
        }

        public static complex operator -(complex value)
        {
            return new complex(-value.Real, -value.Imaginary);
        }

        public static complex operator +(complex left, complex right)
        {
            return new complex(left.Real + right.Real, left.Imaginary + right.Imaginary);
        }

        public static complex operator -(complex left, complex right)
        {
            return new complex(left.Real - right.Real, left.Imaginary - right.Imaginary);
        }

        public static complex operator *(complex left, complex right)
        {
            double real = (left.Real * right.Real) - (left.Imaginary * right.Imaginary);
            double imaginary = (left.Imaginary * right.Real) + (left.Real * right.Imaginary);
            return new complex(real, imaginary);
        }

        public static complex operator /(complex left, complex right)
        {
            double a = left.Real;
            double b = left.Imaginary;
            double c = right.Real;
            double d = right.Imaginary;

            if (Math.Abs(d) < Math.Abs(c))
            {
                double doc = d / c;
                return new complex((a + b * doc) / (c + d * doc), (b - a * doc) / (c + d * doc));
            }
            else
            {
                double cod = c / d;
                return new complex((b + a * cod) / (d + c * cod), (-a + b * cod) / (d + c * cod));
            }
        }

        public static complex Conjugate(complex value)
        {
            return new complex(value.Real, -value.Imaginary);
        }

        public static complex Reciprocal(complex value)
        {
            if (value.Real == 0 && value.Imaginary == 0)
            {
                return Zero;
            }
            return One / value;
        }

        public static bool operator ==(complex left, complex right)
        {
            return left.Real == right.Real && left.Imaginary == right.Imaginary;
        }

        public static bool operator !=(complex left, complex right)
        {
            return left.Real != right.Real || left.Imaginary != right.Imaginary;
        }

        public override bool Equals(object obj)
        {
            return obj is complex ? Equals((complex)obj) : false;
        }

        public bool Equals(complex value)
        {
            return Real.Equals(value.Real) && Imaginary.Equals(value.Imaginary);
        }

        public override int GetHashCode()
        {
            int n1 = 99999997;
            int realHash = Real.GetHashCode() % n1;
            int imaginaryHash = Imaginary.GetHashCode();
            int finalHash = realHash ^ imaginaryHash;
            return finalHash;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, $"({Real}, {Imaginary})");
        }

        public string ToString(string format)
        {
            var culture = CultureInfo.CurrentCulture;
            return string.Format(
                culture,
                $"({Real.ToString(format, culture)}, {Imaginary.ToString(format, culture)})");
        }

        public string ToString(IFormatProvider provider)
        {
            return string.Format(provider, $"({Real}, {Imaginary})");
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return string.Format(
                provider,
                $"({Real.ToString(format, provider)}, {Imaginary.ToString(format, provider)})");
        }

        private static complex Scale(complex value, float factor)
        {
            double realResult = factor * value.Real;
            double imaginaryResuilt = factor * value.Imaginary;
            return new complex(realResult, imaginaryResuilt);
        }

        public static implicit operator complex(short value)
        {
            return new complex(value, 0);
        }

        public static implicit operator complex(int value)
        {
            return new complex(value, 0);
        }

        public static implicit operator complex(long value)
        {
            return new complex(value, 0);
        }

        [CLSCompliant(false)]
        public static implicit operator complex(ushort value)
        {
            return new complex(value, 0);
        }

        [CLSCompliant(false)]
        public static implicit operator complex(uint value)
        {
            return new complex(value, 0);
        }

        [CLSCompliant(false)]
        public static implicit operator complex(ulong value)
        {
            return new complex(value, 0);
        }

        [CLSCompliant(false)]
        public static implicit operator complex(sbyte value)
        {
            return new complex(value, 0);
        }

        public static implicit operator complex(byte value)
        {
            return new complex(value, 0);
        }

        public static implicit operator complex(float value)
        {
            return new complex(value, 0);
        }

        public static implicit operator complex(double value)
        {
            return new complex(value, 0);
        }

        public static implicit operator complex(complexf value)
        {
            return new complex(value.Real, value.Imaginary);
        }

        public static explicit operator complex(BigInteger value)
        {
            return new complex((double)value, 0);
        }

        public static explicit operator complex(decimal value)
        {
            return new complex((double)value, 0);
        }
    }
}
