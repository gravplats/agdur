using System.Linq;
using System.Xml;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    public class XmlMetricOutputVisitor : IMetricOutputVisitor
    {
        private readonly XmlWriter writer;

        public XmlMetricOutputVisitor(XmlWriter writer)
        {
            this.writer = writer;
        }

        public void Visit(SingleValueMetric metric)
        {
            var value = metric.GetValues().Single().ToString();
            writer.WriteElementString(metric.Name, value);
        }

        public void Visit(MultipleValueMetric metric)
        {
            var values = metric.GetValues().ToList();
            for (int index = 0; index < values.Count; index++)
            {
                writer.WriteStartElement(metric.Name);
                writer.WriteAttributeString("index", index.ToString());
                
                string value = values[index].ToString();
                writer.WriteString(value);
                
                writer.WriteEndElement();
            }
        }
    }
}