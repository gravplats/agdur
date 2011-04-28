using System;
using System.Linq;
using Agdur.Abstractions;
using Agdur.Internals;

namespace Agdur
{
    /// <summary>
    /// Provides functionality for performing a rough estimate of the cost of running a specific action.
    /// </summary>
    public class Benchmark : IBenchmarkBuilder
    {
        private readonly IBenchmarkAlgorithm benchmark;

        /// <summary>
        /// Intializes a new instance of the <see cref="Benchmark" /> class.
        /// </summary>
        /// <param name="benchmark"></param>
        public Benchmark(IBenchmarkAlgorithm benchmark)
        {
            Ensure.ArgumentNotNull(benchmark, "benchmark");
            this.benchmark = benchmark;
        }

        /// <inheritdoc/>
        public static IBenchmarkBuilder This(Action action)
        {
            var benchmark = new DefaultBenchmarkAlgorithm(action);
            return new Benchmark(benchmark);
        }

        /// <inheritdoc/>
        public IBenchmarkMetricBuilder Times(int numberOfTimes)
        {
            Ensure.GreaterThanZero(numberOfTimes, "numberOfTimes");

            var samples = benchmark.Run(numberOfTimes).ToList();
            return new BenchmarkBuilder(samples);
        }

        /// <inheritdoc/>
        public void With<TProfile>() where TProfile : IBenchmarkProfile, new()
        {
            var profile = new TProfile();
            profile.Define(this);
        }
    }
}