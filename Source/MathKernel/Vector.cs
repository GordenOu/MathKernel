using System;
using Core.Diagnostics;
using MathKernel.Resources;

namespace MathKernel
{
    /// <summary>
    /// Column vector.
    /// </summary>
    public class Vector<T>
        where T : struct
    {
        public T[] Storage { get; }

        public VectorDescriptor Descriptor { get; }

        internal Vector(T[] storage, VectorDescriptor descriptor)
        {
            Requires.NotNull(storage, nameof(storage));
            if (descriptor.Offset + (descriptor.Size - 1) * descriptor.Stride >= storage.Length)
            {
                throw new ArgumentException(Strings.InsufficientStorageLength);
            }

            Storage = storage;
            Descriptor = descriptor;
        }

        internal Vector(T[] storage, int size, int offset, int stride)
            : this(storage, new VectorDescriptor(size, offset, stride))
        { }
    }

    [Duplicate(typeof(float))]
    public static partial class Vector
    {
        public static Vector<float> Create(float[] storage, VectorDescriptor descriptor)
        {
            return new Vector<float>(storage, descriptor);
        }

        public static Vector<float> Create(float[] storage, int size, int offset, int stride)
        {
            return new Vector<float>(storage, size, offset, stride);
        }

        public static Vector<float> Create(float[] storage, int size, int offset)
        {
            return new Vector<float>(storage, size, offset, 1);
        }

        public static Vector<float> Create(float[] storage)
        {
            Requires.NotNull(storage, nameof(storage));

            return new Vector<float>(storage, storage.Length, 0, 1);
        }
    }

    [Duplicate(typeof(complexf))]
    public static partial class Vector
    {
        public static Vector<complexf> Create(complexf[] storage, VectorDescriptor descriptor)
        {
            return new Vector<complexf>(storage, descriptor);
        }

        public static Vector<complexf> Create(complexf[] storage, int size, int offset, int stride)
        {
            return new Vector<complexf>(storage, size, offset, stride);
        }

        public static Vector<complexf> Create(complexf[] storage, int size, int offset)
        {
            return new Vector<complexf>(storage, size, offset, 1);
        }

        public static Vector<complexf> Create(complexf[] storage)
        {
            Requires.NotNull(storage, nameof(storage));

            return new Vector<complexf>(storage, storage.Length, 0, 1);
        }
    }

    [Duplicate(typeof(double))]
    public static partial class Vector
    {
        public static Vector<double> Create(double[] storage, VectorDescriptor descriptor)
        {
            return new Vector<double>(storage, descriptor);
        }

        public static Vector<double> Create(double[] storage, int size, int offset, int stride)
        {
            return new Vector<double>(storage, size, offset, stride);
        }

        public static Vector<double> Create(double[] storage, int size, int offset)
        {
            return new Vector<double>(storage, size, offset, 1);
        }

        public static Vector<double> Create(double[] storage)
        {
            Requires.NotNull(storage, nameof(storage));

            return new Vector<double>(storage, storage.Length, 0, 1);
        }
    }

    [Duplicate(typeof(complex))]
    public static partial class Vector
    {
        public static Vector<complex> Create(complex[] storage, VectorDescriptor descriptor)
        {
            return new Vector<complex>(storage, descriptor);
        }

        public static Vector<complex> Create(complex[] storage, int size, int offset, int stride)
        {
            return new Vector<complex>(storage, size, offset, stride);
        }

        public static Vector<complex> Create(complex[] storage, int size, int offset)
        {
            return new Vector<complex>(storage, size, offset, 1);
        }

        public static Vector<complex> Create(complex[] storage)
        {
            Requires.NotNull(storage, nameof(storage));

            return new Vector<complex>(storage, storage.Length, 0, 1);
        }
    }
}
