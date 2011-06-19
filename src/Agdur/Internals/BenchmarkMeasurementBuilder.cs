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
            result.DataSelectorProvider = new MillisecondsDataSelectorProvider();
            return builder;
        }

        /// <inheritdoc/>
        public TOutput InTicks()
        {
            result.DataSelectorProvider = new TicksDataSelectorProvider();
            return builder;
        }

        /// <inheritdoc/>
        public TOutput InCustomUnitOfTime(IDataSelectorProvider provider)
        {
            result.DataSelectorProvider = provider;
            return builder;
        }

        /// <inheritdoc/>
        public TOutput InCustomUnitOfTime(Func<TimeSpan, long> selector, string unitOfMeasurement)
        {
            result.DataSelectorProvider = new InlineDataSelectorProvider(selector, unitOfMeasurement);
            return builder;
        }
    }
}