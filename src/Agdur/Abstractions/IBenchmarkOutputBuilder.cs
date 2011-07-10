using System.IO;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define how the output should be presented.
    /// </summary>
    public interface IBenchmarkOutputBuilder : IBenchmarkMetricBuilder<IBenchmarkOutputBuilder>
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

        /// <summary>
        /// Uses the specified visitor to display the results of the metrics.
        /// </summary>
        /// <param name="visitor">The visitor that should be used to display the results of the metrics.</param>
        void ToVisitor(IMetricVisitor visitor);
    }
}