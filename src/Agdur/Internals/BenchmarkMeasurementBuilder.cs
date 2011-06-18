using System;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    /// <summary>
    /// The measurement builder.
    /// </summary>
    public class BenchmarkMeasurementBuilder : IBenchmarkMeasurementBuilder
    {
        private readonly Metric result;
        private readonly IBenchmarkOutputBuilder builder;

        /// <summary>
        /// Creates a new instance of the <see cref="BenchmarkMeasurementBuilder"/> class.
        /// </summary>
        /// <param name="result">The metric result.</param>
        /// <param name="builder">The benchmark configuration builder.</param>
        public BenchmarkMeasurementBuilder(Metric result, IBenchmarkOutputBuilder builder)
        {
            Ensure.ArgumentNotNull(result, "result");
            Ensure.ArgumentNotNull(builder, "builder");

            this.result = result;
            this.builder = builder;
        }

        /// <inheritdoc/>
        public IBenchmarkOutputBuilder InMilliseconds()
        {
            result.DataSelectorProvider = new MillisecondsDataSelectorProvider();
            return builder;
        }

        /// <inheritdoc/>
        public IBenchmarkOutputBuilder InTicks()
        {
            result.DataSelectorProvider = new TicksDataSelectorProvider();
            return builder;
        }

        /// <inheritdoc/>
        public IBenchmarkOutputBuilder InCustomUnitOfTime(IDataSelectorProvider provider)
        {
            result.DataSelectorProvider = provider;
            return builder;
        }

        /// <inheritdoc/>
        public IBenchmarkOutputBuilder InCustomUnitOfTime(Func<Sample, long> selector, string unitOfMeasurement)
        {
            result.DataSelectorProvider = new InlineDataSelectorProvider(selector, unitOfMeasurement);
            return builder;
        }
    }
}