using System.Collections.Generic;
using System.IO;

namespace Agdur
{
    /// <summary>
    /// Provides functionality for outputting the results.
    /// </summary>
    public interface IOutputStrategy
    {
        /// <summary>
        /// Outputs the results of the metrics to the writer.
        /// </summary>
        /// <param name="writer">The writer that the output should be written to.</param>
        /// <param name="metrics">The metrics.</param>
        void Execute(TextWriter writer, IList<IMetric> metrics);
    }
}