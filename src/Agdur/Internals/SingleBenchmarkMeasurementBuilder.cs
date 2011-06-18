using System;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    /// <summary>
    /// The single measurement builder.
    /// </summary>
    public class SingleBenchmarkMeasurementBuilder : ISingleBenchmarkMeasurementBuilder
    {
        private readonly Metric result;
        private readonly ISingleBenchmarkOutputBuilder builder;

        /// <summary>
        /// Creates a new instance of the <see cref="SingleBenchmarkMeasurementBuilder"/> class.
        /// </summary>
        /// <param name="result">The metric result.</param>
        /// <param name="builder">The benchmark configuration builder.</param>
        public SingleBenchmarkMeasurementBuilder(Metric result, ISingleBenchmarkOutputBuilder builder)
        {
            Ensure.ArgumentNotNull(result, "result");
            Ensure.ArgumentNotNull(builder, "builder");

            this.result = result;
            this.builder = builder;
        }

        /// <inheritdoc/>
        public ISingleBenchmarkOutputBuilder InMilliseconds()
        {
            result.DataSelectorProvider = new MillisecondsDataSelectorProvider();
            return builder;
        }

        /// <inheritdoc/>
        public ISingleBenchmarkOutputBuilder InTicks()
        {
            result.DataSelectorProvider = new TicksDataSelectorProvider();
            return builder;
        }

        /// <inheritdoc/>
        public ISingleBenchmarkOutputBuilder InCustomUnitOfTime(IDataSelectorProvider provider)
        {
            result.DataSelectorProvider = provider;
            return builder;
        }

        /// <inheritdoc/>
        public ISingleBenchmarkOutputBuilder InCustomUnitOfTime(Func<Sample, long> selector, string unitOfMeasurement)
        {
            result.DataSelectorProvider = new InlineDataSelectorProvider(selector, unitOfMeasurement);
            return builder;
        }
    }
}