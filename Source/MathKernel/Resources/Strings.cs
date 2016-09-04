using Core.Resources;

namespace MathKernel.Resources
{
    internal class Strings : StringResource<Strings>
    {
        public static string InsufficientStorageLength =>
            GetString(nameof(InsufficientStorageLength));

        public static string VectorSizesAreNotEqual =>
            GetString(nameof(VectorSizesAreNotEqual));
    }
}
