using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
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
            return Custom("average", data => data.Average());
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
        public IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> First(int numberOfSamples)
        {
            Ensure.GreaterThanZero(numberOfSamples, "numberOfSamples");
            return Custom("first", data => data.Take(numberOfSamples));
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Max()
        {
            return Custom("maximum", data => data.Max());
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Min()
        {
            return Custom("minimum", data => data.Min());
        }

        /// <inheritdoc/>
        public IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Total()
        {
            return Custom("total", data => data.Sum());
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
            ToBaseline(() => XmlWriter.Create(path));
        }

        /// <inheritdoc/>
        public void ToBaseline(TextWriter writer)
        {
            Ensure.ArgumentNotNull(writer, "writer");
            ToBaseline(() => XmlWriter.Create(writer));
        }

        private void ToBaseline(Func<XmlWriter> xmlWriterProvider)
        {
            using (var xmlWriter = xmlWriterProvider())
            {
                var visitor = new XmlOutputMetricVisitor(xmlWriter);
                xmlWriter.WriteStartElement("benchmark");

                foreach (var metric in metrics)
                {
                    metric.Accept(visitor);
                }

                xmlWriter.WriteEndElement();
            }
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
    }
}