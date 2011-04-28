using System.Collections.Generic;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Provides functionality for implementing a benchmark algorithm.
    /// </summary>
    public interface IBenchmarkAlgorithm
    {
        /// <summary>
        /// Runs the benchmark the specified number of times.
        /// </summary>
        /// <param name="numberOfTimes">The number of times the benchmark should be run.</param>
        /// <returns>The result of the benchmark.</returns>
        IEnumerable<Sample> Run(int numberOfTimes);
    }
}