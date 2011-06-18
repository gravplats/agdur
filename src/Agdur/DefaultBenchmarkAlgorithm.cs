using System;
using System.Collections.Generic;
using System.Diagnostics;
using Agdur.Abstractions;

namespace Agdur
{
    /// <summary>
    /// The default benchmark.
    /// </summary>
    /// <remarks>
    /// Inspired by 
    ///     http://stackoverflow.com/questions/1507405/c-is-this-benchmarking-class-accurate
    ///     http://stackoverflow.com/questions/1047218/benchmarking-small-code-samples-in-c-can-this-implementation-be-improved
    /// </remarks>
    public class DefaultBenchmarkAlgorithm : IBenchmarkAlgorithm
    {
        private readonly Action action;

        /// <summary>
        /// Creates a new instance of the <see cref="DefaultBenchmarkAlgorithm"/> class.
        /// </summary>
        /// <param name="action">The action to be benchmarked.</param>
        public DefaultBenchmarkAlgorithm(Action action)
        {
            this.action = action;
        }

        /// <inheritdoc/>
        public IEnumerable<TimeSpan> Run(int numberOfTimes)
        {
            WarmUp();

            var watch = new Stopwatch();
            for (int index = 0; index < numberOfTimes; index++)
            {
                watch.Reset();
                
                watch.Start();
                action();
                watch.Stop();

                yield return watch.Elapsed;
            }
        }

        /// <summary>
        /// Give the test as good a change as possible of avoiding garbage collection.
        /// </summary>
        private void WarmUp()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            action();
        }
    }
}