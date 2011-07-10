using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    /// <summary>
    /// Provides a root for the fluent syntax associated with benchmarking.
    /// </summary>
    public class BenchmarkBuilder : IBenchmarkOutputBuilder, ISingleBenchmarkOutputBuilder
    {
        private readonly IEnumerable<TimeSpan> samples;
        private readonly List<IMetric> metrics = new List<IMetric>();

        /// <summary>
        /// Creates a new instance of the <see cref="BenchmarkBuilder"/> class.
        /// </summary>
        /// <param name="samples">The samples.</param>
        public BenchmarkBuilder(IEnumerable<TimeSpan> samples)
        {
            Ensure.ArgumentNotNull(samples, "samples");
            this.samples = samples;
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Custom(string name, Func<IEnumerable<double>, double> func)
        {
            return Custom(new SingleValueMetric(name, func));
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Custom(string name, Func<IEnumerable<double>, IEnumerable<double>> func)
        {
            return Custom(new MultipleValueMetric(name, func));
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Custom(IMetric metric)
        {
            metric.Samples = samples;
            metrics.Add(metric);

            return new BenchmarkMeasurementBuilder<IBenchmarkOutputBuilder>(metric, this);
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder<ISingleBenchmarkOutputBuilder> Value()
        {
            var metric = new SingleValueMetric("single", data => data.Single()) { Samples = samples };
            metrics.Add(metric);

            return new BenchmarkMeasurementBuilder<ISingleBenchmarkOutputBuilder>(metric, this);
        }

        /// <inheritdoc/>
        public void ToConsole()
        {
            Write(Console.WriteLine);
        }

        /// <inheritdoc/>
        public void ToWriter(TextWriter writer)
        {
            Ensure.ArgumentNotNull(writer, "writer");
            Write(writer.WriteLine);
        }

        private void Write(Action<string> write)
        {
            Ensure.ArgumentNotNull(write, "write");

            var visitor = new FormattedOutputMetricVisitor(write);
            foreach (var metric in metrics)
            {
                metric.Accept(visitor);
            }
        }

        public void ToVisitor(IMetricVisitor visitor)
        {
            Ensure.ArgumentNotNull(visitor, "visitor");
            foreach (var metric in metrics)
            {
                metric.Accept(visitor);
            }
        }
    }
}