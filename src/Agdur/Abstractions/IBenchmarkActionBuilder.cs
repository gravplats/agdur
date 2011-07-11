using System;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define the action that should be benchmarked.
    /// </summary>
    public interface IBenchmarkActionBuilder
    {
        /// <summary>
        /// Benchmarks the specified action.
        /// </summary>
        /// <param name="action">The action to be benchmarked.</param>
        IBenchmarkBuilder This(Action action);
    }
}