using System.Resources;

namespace MathKernel.Analyzers.Resources
{
    internal class Strings
    {
        private static ResourceManager manager = new ResourceManager(typeof(Strings));

        public static string Title => manager.GetString(nameof(Title));

        public static string MessageFormat => manager.GetString(nameof(MessageFormat));

        public static string Description => manager.GetString(nameof(Description));
    }
}
