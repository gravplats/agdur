using System;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    /// <summary>
    /// The measurement builder.
    /// </summary>
    public class BenchmarkMeasurementBuilder<TOutput> : IBenchmarkBuilderInSyntax<TOutput>
    {
        private readonly IMetric metric;
        private readonly TOutput builder;

        /// <summary>
        /// Creates a new instance of the <see cref="BenchmarkMeasurementBuilder{TOutput}"/> class.
        /// </summary>
        /// <param name="metric">The metric.</param>
        /// <param name="builder">The benchmark configuration builder.</param>
        public BenchmarkMeasurementBuilder(IMetric metric, TOutput builder)
        {
            Ensure.ArgumentNotNull(metric, "result");
            Ensure.ArgumentNotNull(builder, "builder");

            this.metric = metric;
            this.builder = builder;
        }

        /// <inheritdoc/>
        public TOutput InMilliseconds()
        {
            return InCustom(span => span.Milliseconds, "ms");
        }

        /// <inheritdoc/>
        public TOutput InTicks()
        {
            return InCustom(span => span.Ticks, "ticks");
        }

        /// <inheritdoc/>
        public TOutput InCustom(Func<TimeSpan, IConvertible> provider, string unitOfMeasurement)
        {
            Ensure.ArgumentNotNull(provider, "provider");

            metric.DataProvider = provider;
            metric.UnitOfMeasurement = unitOfMeasurement;

            return builder;
        }
    }
}