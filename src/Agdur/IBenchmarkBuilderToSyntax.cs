using System.IO;

namespace Agdur
{
    public interface IBenchmarkBuilderToSyntax
    {
        /// <summary>
        /// Writes output to the specified writer.
        /// </summary>
        /// <param name="writer">The writer that the output should be written to.</param>
        IBenchmarkBuilderAsSyntax ToCustom(TextWriter writer);
    }
}