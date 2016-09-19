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
            Requires.NotNull(descriptor, nameof(descriptor));
            if (storage.Length <= descriptor.Offset + (descriptor.Size - 1) * descriptor.Stride)
            {
                throw new ArgumentException(Strings.InsufficientStorageLength);
            }

            Storage = storage;
            Descriptor = descriptor;
        }
    }

    [Duplicate(typeof(float))]
    public static partial class Vector
    {
        public static Vector<float> Create(float[] storage, VectorDescriptor descriptor)
        {
            return new Vector<float>(storage, descriptor);
        }

        public static Vector<float> Create(float[] storage)
        {
            Requires.NotNull(storage, nameof(storage));

            return new Vector<float>(storage, new VectorDescriptor(storage.Length));
        }
    }

    [Duplicate(typeof(double))]
    public static partial class Vector
    {
        public static Vector<double> Create(double[] storage, VectorDescriptor descriptor)
        {
            return new Vector<double>(storage, descriptor);
        }

        public static Vector<double> Create(double[] storage)
        {
            Requires.NotNull(storage, nameof(storage));

            return new Vector<double>(storage, new VectorDescriptor(storage.Length));
        }
    }

    [Duplicate(typeof(complexf))]
    public static partial class Vector
    {
        public static Vector<complexf> Create(complexf[] storage, VectorDescriptor descriptor)
        {
            return new Vector<complexf>(storage, descriptor);
        }

        public static Vector<complexf> Create(complexf[] storage)
        {
            Requires.NotNull(storage, nameof(storage));

            return new Vector<complexf>(storage, new VectorDescriptor(storage.Length));
        }
    }

    [Duplicate(typeof(complex))]
    public static partial class Vector
    {
        public static Vector<complex> Create(complex[] storage, VectorDescriptor descriptor)
        {
            return new Vector<complex>(storage, descriptor);
        }

        public static Vector<complex> Create(complex[] storage)
        {
            Requires.NotNull(storage, nameof(storage));

            return new Vector<complex>(storage, new VectorDescriptor(storage.Length));
        }
    }
}
