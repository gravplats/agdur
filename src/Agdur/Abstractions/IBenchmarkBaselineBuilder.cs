using System.IO;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Provides functionality for creating baseline based on the resuls of a benchmark.
    /// </summary>
    public interface IBenchmarkBaselineBuilder
    {
        /// <summary>
        /// Writes the output the specified path.
        /// </summary>
        /// <param name="path">The path that the output should be written to.</param>
        void ToBaseline(string path);

        /// <summary>
        /// Writes the output to the specified writer.
        /// </summary>
        /// <param name="writer">The writer that the output should be written to.</param>
        void ToBaseline(TextWriter writer);
    }
}