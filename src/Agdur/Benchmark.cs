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
        /// <param name="benchmark">The action to be benchmarked.</param>
        public Benchmark(IBenchmarkAlgorithm benchmark)
        {
            Ensure.ArgumentNotNull(benchmark, "benchmark");
            this.benchmark = benchmark;
        }

        /// <inheritdoc/>
        public ISingleBenchmarkMetricBuilder<ISingleBenchmarkOutputBuilder> Once()
        {
            return CreateBuilder(1);
        }

        /// <inheritdoc/>
        public IBenchmarkMetricBuilder<IBenchmarkOutputBuilder> Times(int numberOfTimes)
        {
            return CreateBuilder(numberOfTimes);
        }

        private BenchmarkBuilder CreateBuilder(int numberOfTimes)
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

        /// <inheritdoc/>
        public void With(Action<IBenchmarkRepetitionBuilder> profile)
        {
            profile(this);
        }

        private static readonly Func<Action, IBenchmarkAlgorithm> DefaultProvider = action => new DefaultBenchmarkAlgorithm(action);
        private static Func<Action, IBenchmarkAlgorithm> BenchmarkProvider = DefaultProvider;

        /// <summary>
        /// Benchmarks the specified action.
        /// </summary>
        /// <param name="action">The action to be benchmarked.</param>
        public static IBenchmarkBuilder This(Action action)
        {
            var benchmark = BenchmarkProvider(action);
            return new Benchmark(benchmark);
        }

        /// <summary>
        /// Sets the provider that should be used to create a benchmark algorithm.
        /// </summary>
        /// <param name="provider">The benchmark algorithm provider.</param>
        public static void SetBenchmarkAlgorithmProvider(Func<Action, IBenchmarkAlgorithm> provider)
        {
            BenchmarkProvider = provider ?? DefaultProvider;
        }
    }
}