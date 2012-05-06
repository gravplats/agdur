namespace Agdur
{
    public static class BenchmarkBuilderAsSyntaxExtensions
    {
        /// <summary>
        /// Specifies that the output should be in XML.
        /// </summary>
        public static void AsXml(this IBenchmarkBuilderAsSyntax builder)
        {
            builder.AsCustom(new XmlOutputStrategy());
        }

        /// <summary>
        /// Specifies that the output should be formatted.
        /// </summary>
        public static void AsFormattedString(this IBenchmarkBuilderAsSyntax builder)
        {
            builder.AsCustom(new FormattedOutputStrategy());
        }
    }
}