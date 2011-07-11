using System;
using Agdur.Abstractions;

namespace Agdur
{
    /// <summary>
    /// The measurement builder.
    /// </summary>
    public class BenchmarkBuilderInSyntax<TOutput> : IBenchmarkBuilderInSyntax<TOutput>
    {
        private readonly IMetric metric;
        private readonly TOutput builder;

        /// <summary>
        /// Creates a new instance of the <see cref="BenchmarkBuilderInSyntax{TOutput}"/> class.
        /// </summary>
        /// <param name="metric">The metric.</param>
        /// <param name="builder">The benchmark configuration builder.</param>
        public BenchmarkBuilderInSyntax(IMetric metric, TOutput builder)
        {
            Ensure.ArgumentNotNull(metric, "result");
            Ensure.ArgumentNotNull(builder, "builder");

            this.metric = metric;
            this.builder = builder;
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