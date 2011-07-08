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
        public IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Average()
        {
            return Custom(new SingleValueMetric("average", data => data.Average()));
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Custom(IMetric metric)
        {
            metric.Samples = samples;
            metrics.Add(metric);

            return new BenchmarkMeasurementBuilder<IBenchmarkOutputBuilder>(metric, this);
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> First(int numberOfSamples)
        {
            Ensure.GreaterThanZero(numberOfSamples, "numberOfSamples");
            return Custom(new MultipleValueMetric("first", data => data.Take(numberOfSamples)));
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Max()
        {
            return Custom(new SingleValueMetric("maximum", data => data.Max()));
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Min()
        {
            return Custom(new SingleValueMetric("minimum", data => data.Min()));
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Total()
        {
            return Custom(new SingleValueMetric("total", data => data.Sum()));
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder<ISingleBenchmarkOutputBuilder> Value()
        {
            var metric = new SingleValueMetric("single", data => data.Single()) { Samples = samples };
            metrics.Add(metric);

            return new BenchmarkMeasurementBuilder<ISingleBenchmarkOutputBuilder>(metric, this);
        }

        /// <inheritdoc/>
        public void ToBaseline(string path)
        {

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

            var visitor = new StringMetricOutputVisitor(write);
            foreach (var metric in metrics)
            {
                metric.Accept(visitor);
            }
        }
    }
}