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
        private readonly List<Metric> metrics = new List<Metric>();

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
        public IBenchmarkMeasurementBuilder Average()
        {
            return Custom("average", data => new SingleValueFormatter(data.Average()));
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder Custom(string nameOfMetric, Func<IEnumerable<long>, IMetricFormatter> metricFunc)
        {
            Ensure.ArgumentNotNull(metricFunc, "metric");

            var metric = new Metric(nameOfMetric, metricFunc, samples);
            metrics.Add(metric);
            
            return new BenchmarkMeasurementBuilder(metric, this);
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder First(int numberOfSamples)
        {
            Ensure.GreaterThanZero(numberOfSamples, "numberOfSamples");
            return Custom("first", data => new MultipleValueFormatter(numberOfSamples, data.Take(numberOfSamples)));
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder Max()
        {
            return Custom("maximum", data => new SingleValueFormatter(data.Max()));
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder Min()
        {
            return Custom("minimum", data => new SingleValueFormatter(data.Min()));
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder Total()
        {
            return Custom("total", data => new SingleValueFormatter(data.Sum()));
        }

        /// <inheritdoc/>
        public ISingleBenchmarkMeasurementBuilder Value()
        {
            var metric = new Metric("single", data => new SingleValueFormatter(data.Single()), samples);
            metrics.Add(metric);

            return new SingleBenchmarkMeasurementBuilder(metric, this);
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
            foreach (var metric in metrics)
            {
                string output = metric.GetResult();
                write(output);
            }
        }
    }
}