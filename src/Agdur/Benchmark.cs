using System;
using System.Linq;
using Agdur.Abstractions;
using Agdur.Introspection;

namespace Agdur
{
    /// <summary>
    /// Provides functionality for performing a rough estimate of the cost of running a specific action.
    /// </summary>
    public class Benchmark : IBenchmarkBuilder
    {
        private readonly IBenchmarkStrategy benchmark;

        /// <summary>
        /// Intializes a new instance of the <see cref="Benchmark" /> class.
        /// </summary>
        /// <param name="benchmark">The action to be benchmarked.</param>
        public Benchmark(IBenchmarkStrategy benchmark)
        {
            Ensure.ArgumentNotNull(benchmark, "benchmark");
            this.benchmark = benchmark;
        }

        /// <inheritdoc/>
        public ISingleBenchmarkBuilderWithSyntax<ISingleBenchmarkBuilderContinuation> Once()
        {
            return CreateBuilder(1);
        }

        /// <inheritdoc/>
        public IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> Times(int numberOfTimes)
        {
            return CreateBuilder(numberOfTimes);
        }

        private BenchmarkBuilderContinuation CreateBuilder(int numberOfTimes)
        {
            Ensure.GreaterThanZero(numberOfTimes, "numberOfTimes");

            var samples = benchmark.Run(numberOfTimes).ToList();
            return new BenchmarkBuilderContinuation(samples);
        }

        private static readonly Func<Action, IBenchmarkStrategy> DefaultBenchmarkStrategyProvider = action => new DefaultBenchmarkStrategy(action);
        private static Func<Action, IBenchmarkStrategy> BenchmarkStrategyProvider = DefaultBenchmarkStrategyProvider;

        /// <summary>
        /// Benchmarks the specified action.
        /// </summary>
        /// <param name="action">The action to be benchmarked.</param>
        public static IBenchmarkBuilder This(Action action)
        {
            var benchmark = BenchmarkStrategyProvider(action);
            return new Benchmark(benchmark);
        }

        /// <summary>
        /// Sets the provider that should be used to create a benchmark strategy.
        /// </summary>
        /// <param name="provider">The benchmark strategy provider.</param>
        public static void SetBenchmarkStrategyProvider(Func<Action, IBenchmarkStrategy> provider)
        {
            BenchmarkStrategyProvider = provider ?? DefaultBenchmarkStrategyProvider;
        }
    }
}