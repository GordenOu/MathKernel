using System;
using System.Diagnostics;
using Core.Diagnostics;
using MathKernel.Resources;

namespace MathKernel.LinearAlgebra
{
    /// <summary>
    /// Column vector.
    /// </summary>
    public class Vector<T>
        where T : struct
    {
        public VectorDescriptor Descriptor { get; private set; }

        public T[] Storage { get; private set; }

        public int Offset { get; private set; }

        private Vector() { }

        internal Vector(VectorDescriptor descriptor, T[] storage, int offset)
        {
            Requires.NotNull(descriptor, nameof(descriptor));
            Requires.NotNull(storage, nameof(storage));
            Requires.NonNegative(offset, nameof(offset));
            if (storage.Length <= offset + (descriptor.Size - 1) * descriptor.Stride)
            {
                throw new ArgumentException(Strings.InsufficientStorageLength);
            }

            Descriptor = descriptor;
            Storage = storage;
            Offset = offset;
        }

        public ConjugatedVector<T> Conjugate()
        {
            return new ConjugatedVector<T>(this);
        }
    }

    public class ConjugatedVector<T>
        where T : struct
    {
        public ConjugatedVectorDescriptor Descriptor { get; }

        public T[] Storage { get; }

        public int Offset { get; }

        internal ConjugatedVector(Vector<T> vector)
        {
            Debug.Assert(vector != null);

            Descriptor = vector.Descriptor.Conjugate();
            Storage = vector.Storage;
            Offset = vector.Offset;
        }
    }

    [Duplicate(typeof(float))]
    public static partial class Vector
    {
        public static Vector<float> Create(
            VectorDescriptor descriptor,
            float[] storage,
            int offset)
        {
            return new Vector<float>(descriptor, storage, offset);
        }

        public static Vector<float> Create(VectorDescriptor descriptor, float[] storage)
        {
            return new Vector<float>(descriptor, storage, 0);
        }

        public static Vector<float> Create(float[] storage)
        {
            Requires.NotNull(storage, nameof(storage));

            return new Vector<float>(new VectorDescriptor(storage.Length), storage, 0);
        }
    }

    [Duplicate(typeof(double))]
    public static partial class Vector
    {
        public static Vector<double> Create(
            VectorDescriptor descriptor,
            double[] storage,
            int offset)
        {
            return new Vector<double>(descriptor, storage, offset);
        }

        public static Vector<double> Create(VectorDescriptor descriptor, double[] storage)
        {
            return new Vector<double>(descriptor, storage, 0);
        }

        public static Vector<double> Create(double[] storage)
        {
            Requires.NotNull(storage, nameof(storage));

            return new Vector<double>(new VectorDescriptor(storage.Length), storage, 0);
        }
    }

    [Duplicate(typeof(complexf))]
    public static partial class Vector
    {
        public static Vector<complexf> Create(
            VectorDescriptor descriptor,
            complexf[] storage,
            int offset)
        {
            return new Vector<complexf>(descriptor, storage, offset);
        }

        public static Vector<complexf> Create(VectorDescriptor descriptor, complexf[] storage)
        {
            return new Vector<complexf>(descriptor, storage, 0);
        }

        public static Vector<complexf> Create(complexf[] storage)
        {
            Requires.NotNull(storage, nameof(storage));

            return new Vector<complexf>(new VectorDescriptor(storage.Length), storage, 0);
        }
    }

    [Duplicate(typeof(complex))]
    public static partial class Vector
    {
        public static Vector<complex> Create(
            VectorDescriptor descriptor,
            complex[] storage,
            int offset)
        {
            return new Vector<complex>(descriptor, storage, offset);
        }

        public static Vector<complex> Create(VectorDescriptor descriptor, complex[] storage)
        {
            return new Vector<complex>(descriptor, storage, 0);
        }

        public static Vector<complex> Create(complex[] storage)
        {
            Requires.NotNull(storage, nameof(storage));

            return new Vector<complex>(new VectorDescriptor(storage.Length), storage, 0);
        }
    }
}
