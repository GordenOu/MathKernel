using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices;

namespace MathKernel
{
    [StructLayout(LayoutKind.Sequential)]
    public struct complexf : IEquatable<complexf>, IFormattable
    {
        public static readonly complexf Zero = new complexf(0, 0);
        public static readonly complexf One = new complexf(1, 0);
        public static readonly complexf ImaginaryOne = new complexf(0, 1);

        public float Real { get; }

        public float Imaginary { get; }

        public complexf(float real, float imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static complexf Negate(complexf value)
        {
            return -value;
        }

        public static complexf Add(complexf left, complexf right)
        {
            return left + right;
        }

        public static complexf Subtract(complexf left, complexf right)
        {
            return left - right;
        }

        public static complexf Multiply(complexf left, complexf right)
        {
            return left * right;
        }

        public static complexf Divide(complexf dividend, complexf divisor)
        {
            return dividend / divisor;
        }

        public static complexf operator -(complexf value)
        {
            return new complexf(-value.Real, -value.Imaginary);
        }

        public static complexf operator +(complexf left, complexf right)
        {
            return new complexf(left.Real + right.Real, left.Imaginary + right.Imaginary);
        }

        public static complexf operator -(complexf left, complexf right)
        {
            return new complexf(left.Real - right.Real, left.Imaginary - right.Imaginary);
        }

        public static complexf operator *(complexf left, complexf right)
        {
            float real = (left.Real * right.Real) - (left.Imaginary * right.Imaginary);
            float imaginary = (left.Imaginary * right.Real) + (left.Real * right.Imaginary);
            return new complexf(real, imaginary);
        }

        public static complexf operator /(complexf left, complexf right)
        {
            float a = left.Real;
            float b = left.Imaginary;
            float c = right.Real;
            float d = right.Imaginary;

            if (Math.Abs(d) < Math.Abs(c))
            {
                float doc = d / c;
                return new complexf((a + b * doc) / (c + d * doc), (b - a * doc) / (c + d * doc));
            }
            else
            {
                float cod = c / d;
                return new complexf((b + a * cod) / (d + c * cod), (-a + b * cod) / (d + c * cod));
            }
        }

        public static complexf Conjugate(complexf value)
        {
            return new complexf(value.Real, -value.Imaginary);
        }

        public static complexf Reciprocal(complexf value)
        {
            if (value.Real == 0 && value.Imaginary == 0)
            {
                return Zero;
            }
            return One / value;
        }

        public static bool operator ==(complexf left, complexf right)
        {
            return left.Real == right.Real && left.Imaginary == right.Imaginary;
        }

        public static bool operator !=(complexf left, complexf right)
        {
            return left.Real != right.Real || left.Imaginary != right.Imaginary;
        }

        public override bool Equals(object obj)
        {
            return obj is complexf ? Equals((complexf)obj) : false;
        }

        public bool Equals(complexf value)
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

        private static complexf Scale(complexf value, float factor)
        {
            float realResult = factor * value.Real;
            float imaginaryResuilt = factor * value.Imaginary;
            return new complexf(realResult, imaginaryResuilt);
        }

        public static implicit operator complexf(short value)
        {
            return new complexf(value, 0);
        }

        public static implicit operator complexf(int value)
        {
            return new complexf(value, 0);
        }

        public static implicit operator complexf(long value)
        {
            return new complexf(value, 0);
        }

        [CLSCompliant(false)]
        public static implicit operator complexf(ushort value)
        {
            return new complexf(value, 0);
        }

        [CLSCompliant(false)]
        public static implicit operator complexf(uint value)
        {
            return new complexf(value, 0);
        }

        [CLSCompliant(false)]
        public static implicit operator complexf(ulong value)
        {
            return new complexf(value, 0);
        }

        [CLSCompliant(false)]
        public static implicit operator complexf(sbyte value)
        {
            return new complexf(value, 0);
        }

        public static implicit operator complexf(byte value)
        {
            return new complexf(value, 0);
        }

        public static implicit operator complexf(float value)
        {
            return new complexf(value, 0);
        }

        public static implicit operator complexf(double value)
        {
            return new complexf((float)value, 0);
        }

        public static explicit operator complexf(BigInteger value)
        {
            return new complexf((float)value, 0);
        }

        public static explicit operator complexf(decimal value)
        {
            return new complexf((float)value, 0);
        }
    }
}
