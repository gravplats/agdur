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
        /// Writes the XML output the specified path.
        /// </summary>
        /// <param name="path">The path that the XML output should be written to.</param>
        void ToXml(string path);

        /// <summary>
        /// Writes the XML output to the specified writer.
        /// </summary>
        /// <param name="writer">The writer that the XML output should be written to.</param>
        void ToXml(TextWriter writer);
    }
}