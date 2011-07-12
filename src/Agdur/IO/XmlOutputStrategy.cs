using System.Collections.Generic;
using System.IO;
using System.Xml;
using Agdur.Abstractions;

namespace Agdur.IO
{
    /// <summary>
    /// Provides functionality for outputting the results as XML.
    /// </summary>
    public class XmlOutputStrategy : IOutputStrategy
    {
        /// <inheritdoc/>
        public void Execute(TextWriter writer, IList<IMetric> metrics)
        {
            using (var xmlWriter = XmlWriter.Create(writer))
            {
                xmlWriter.WriteStartElement("benchmark");

                var visitor = new XmlOutputMetricVisitor(xmlWriter);
                metrics.Accept(visitor);

                xmlWriter.WriteEndElement();
            }
        }
    }
}