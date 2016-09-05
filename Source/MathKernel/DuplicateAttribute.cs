using System;

namespace MathKernel
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    internal sealed class DuplicateAttribute
        : Attribute
    {
        public Type DataType { get; }

        public DuplicateAttribute(Type dataType)
        {
            DataType = dataType;
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    internal sealed class RealTypeDuplicateAttribute
        : Attribute
    {
        public Type DataType { get; }

        public RealTypeDuplicateAttribute(Type dataType)
        {
            DataType = dataType;
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    internal sealed class ComplexTypeDuplicateAttribute
        : Attribute
    {
        public Type DataType { get; }

        public ComplexTypeDuplicateAttribute(Type dataType)
        {
            DataType = dataType;
        }
    }
}
