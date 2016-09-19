using Core.Diagnostics;

namespace MathKernel.LinearAlgebra
{
    public class VectorDescriptor
    {
        public int Size { get; }

        public int Offset { get; }

        public int Stride { get; }

        public VectorDescriptor(int size, int offset, int stride)
        {
            Requires.Positive(size, nameof(size));
            Requires.NonNegative(offset, nameof(offset));
            Requires.Positive(stride, nameof(stride));

            Size = size;
            Offset = offset;
            Stride = stride;
        }

        public VectorDescriptor(int size, int offset)
            : this(size, offset, 1)
        { }

        public VectorDescriptor(int size)
            : this(size, 0, 1)
        { }
    }
}
