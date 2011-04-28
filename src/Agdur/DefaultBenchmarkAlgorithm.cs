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
    /// Inspired by http://stackoverflow.com/questions/1507405/c-is-this-benchmarking-class-accurate.
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
        public IEnumerable<Sample> Run(int numberOfTimes)
        {
            WarmUp();

            var watch = new Stopwatch();
            for (int index = 0; index < numberOfTimes; index++)
            {
                watch.Reset();

                watch.Start();
                action();
                watch.Stop();

                yield return new Sample(watch.ElapsedMilliseconds, watch.ElapsedTicks);
            }
        }

        /// <summary>
        /// Give the test as good a change as possible of avoiding garbage collection.
        /// </summary>
        private void WarmUp()
        {
            action();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}