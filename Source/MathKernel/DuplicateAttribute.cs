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
}
