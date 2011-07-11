using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Agdur.Abstractions;
using Agdur.Internals;

namespace Agdur
{
    /// <summary>
    /// Provides a root for the fluent syntax associated with benchmarking.
    /// </summary>
    public class BenchmarkBuilderContinuation : IBenchmarkBuilderContinutation, ISingleBenchmarkBuilderContinuation
    {
        private readonly IEnumerable<TimeSpan> samples;
        private readonly IList<IMetric> metrics = new List<IMetric>();

        /// <summary>
        /// Creates a new instance of the <see cref="BenchmarkBuilderContinuation"/> class.
        /// </summary>
        /// <param name="samples">The samples.</param>
        public BenchmarkBuilderContinuation(IEnumerable<TimeSpan> samples)
        {
            Ensure.ArgumentNotNull(samples, "samples");
            this.samples = samples;
        }

        /// <inheritdoc/>
        public IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> Custom(string name, Func<IEnumerable<double>, double> func)
        {
            return Custom(new SingleValueMetric(name, func));
        }

        /// <inheritdoc/>
        public IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> Custom(string name, Func<IEnumerable<double>, IEnumerable<double>> func)
        {
            return Custom(new MultipleValueMetric(name, func));
        }

        /// <inheritdoc/>
        public IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> Custom(IMetric metric)
        {
            metric.Samples = samples;
            metrics.Add(metric);

            return new BenchmarkMeasurementBuilder<IBenchmarkBuilderContinutation>(metric, this);
        }

        /// <inheritdoc/>
        public IBenchmarkBuilderInSyntax<ISingleBenchmarkBuilderContinuation> Value()
        {
            var metric = new SingleValueMetric("single", data => data.Single()) { Samples = samples };
            metrics.Add(metric);

            return new BenchmarkMeasurementBuilder<ISingleBenchmarkBuilderContinuation>(metric, this);
        }

        /// <inheritdoc/>
        public IBenchmarkBuilderAsSyntax ToCustom(TextWriter writer)
        {
            return new BenchmarkBuilderAsSyntax(writer, metrics);
        }
    }
}