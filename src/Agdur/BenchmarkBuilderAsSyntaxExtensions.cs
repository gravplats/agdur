using Agdur.Abstractions;
using Agdur.IO;

namespace Agdur
{
    public static class BenchmarkBuilderAsSyntaxExtensions
    {
        public static void AsXml(this IBenchmarkBuilderAsSyntax builder)
        {
            builder.AsCustom(new XmlOutputStrategy());
        }

        public static void AsFormattedString(this IBenchmarkBuilderAsSyntax builder)
        {
            builder.AsCustom(new FormattedOutputStrategy());
        }
    }
}