using System.IO;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define how the output should be presented.
    /// </summary>
    public interface ISingleBenchmarkOutputBuilder : ISingleBenchmarkMetricBuilder<ISingleBenchmarkOutputBuilder>
    {
        /// <summary>
        /// Writes the output to the console.
        /// </summary>
        void ToConsole();

        /// <summary>
        /// Writes the output ot the writer.
        /// </summary>
        /// <param name="writer">The writer that the output should be written to.</param>
        void ToWriter(TextWriter writer);
    }
}