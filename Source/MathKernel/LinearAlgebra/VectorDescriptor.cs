using System.Diagnostics;
using Core.Diagnostics;

namespace MathKernel.LinearAlgebra
{
    public class VectorDescriptor
    {
        public int Size { get; private set; }

        public int Stride { get; private set; }

        private VectorDescriptor() { }

        public VectorDescriptor(int size, int stride)
        {
            Requires.Positive(size, nameof(size));
            Requires.Positive(stride, nameof(stride));

            Size = size;
            Stride = stride;
        }

        public VectorDescriptor(int size)
            : this(size, 1)
        { }

        public ConjugatedVectorDescriptor Conjugate()
        {
            return new ConjugatedVectorDescriptor(this);
        }
    }

    public class ConjugatedVectorDescriptor
    {
        public int Size { get; }

        public int Stride { get; }

        internal ConjugatedVectorDescriptor(VectorDescriptor descriptor)
        {
            Debug.Assert(descriptor != null);

            Size = descriptor.Size;
            Stride = descriptor.Stride;
        }
    }
}
