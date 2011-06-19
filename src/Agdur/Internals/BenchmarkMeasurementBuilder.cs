using System;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    /// <summary>
    /// The measurement builder.
    /// </summary>
    public class BenchmarkMeasurementBuilder<TOutput> : IBenchmarkMeasurementBuilder<TOutput>
    {
        private readonly Metric result;
        private readonly TOutput builder;

        /// <summary>
        /// Creates a new instance of the <see cref="BenchmarkMeasurementBuilder{TOutput}"/> class.
        /// </summary>
        /// <param name="result">The metric result.</param>
        /// <param name="builder">The benchmark configuration builder.</param>
        public BenchmarkMeasurementBuilder(Metric result, TOutput builder)
        {
            Ensure.ArgumentNotNull(result, "result");
            Ensure.ArgumentNotNull(builder, "builder");

            this.result = result;
            this.builder = builder;
        }

        /// <inheritdoc/>
        public TOutput InMilliseconds()
        {
            result.DataProvider = span => span.Milliseconds;
            result.UnitOfMeasurement = "ms";

            return builder;
        }

        /// <inheritdoc/>
        public TOutput InTicks()
        {
            result.DataProvider = span => span.Ticks;
            result.UnitOfMeasurement = "ticks";

            return builder;
        }

        /// <inheritdoc/>
        public TOutput InCustomUnitOfTime(Func<TimeSpan, IConvertible> provider, string unitOfMeasurement)
        {
            Ensure.ArgumentNotNull(provider, "provider");

            result.DataProvider = provider;
            result.UnitOfMeasurement = unitOfMeasurement;

            return builder;
        }
    }
}