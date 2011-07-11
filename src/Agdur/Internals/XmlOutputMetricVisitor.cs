using System.Collections.Generic;
using System.Xml;

namespace Agdur.Internals
{
    /// <summary>
    /// Provides XML output of the results of a metric.
    /// </summary>
    public class XmlOutputMetricVisitor : MetricVisitorBase
    {
        private readonly XmlWriter writer;

        /// <summary>
        /// Creates a new instance of the <see cref="XmlOutputMetricVisitor"/> class.
        /// </summary>
        /// <param name="writer"></param>
        public XmlOutputMetricVisitor(XmlWriter writer)
        {
            this.writer = writer;
        }

        protected override void HandleSingleValueMetric(string name, string value, string unitOfMeasurement)
        {
            writer.WriteElementString(name, value);
        }

        protected override void HandleMultipleValueMetric(string name, IList<string> values, string unitOfMeasurement)
        {
            for (int index = 0; index < values.Count; index++)
            {
                writer.WriteStartElement(name);
                writer.WriteAttributeString("index", index.ToString());

                string value = values[index];
                writer.WriteString(value);

                writer.WriteEndElement();
            }
        }
    }
}