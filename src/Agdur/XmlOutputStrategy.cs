using System.Collections.Generic;
using System.IO;
using System.Xml;
using Agdur.Abstractions;

namespace Agdur
{
    public class XmlOutputStrategy : IOutputStrategy
    {
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