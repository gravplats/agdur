using System;
using System.IO;
using System.Xml;
using Agdur.Abstractions;
using Agdur.Internals;

namespace Agdur
{
    public static class XmlBenchmarkOutputBuilderExtensions
    {
        /// <summary>
        /// Writes the XML output the specified path.
        /// </summary>
        /// <param name="path">The path that the XML output should be written to.</param>
        public static void ToXml(this IBenchmarkOutputBuilder builder, string path)
        {
            builder.ToXml(() => XmlWriter.Create(path));
        }

        /// <summary>
        /// Writes the XML output to the specified writer.
        /// </summary>
        /// <param name="writer">The writer that the XML output should be written to.</param>
        public static void ToXml(this IBenchmarkOutputBuilder builder, TextWriter writer)
        {
            Ensure.ArgumentNotNull(writer, "writer");
            builder.ToXml(() => XmlWriter.Create(writer));
        }

        private static void ToXml(this IBenchmarkOutputBuilder builder, Func<XmlWriter> xmlWriterProvider)
        {
            using (var xmlWriter = xmlWriterProvider())
            {
                var visitor = new XmlOutputMetricVisitor(xmlWriter);
                xmlWriter.WriteStartElement("benchmark");
                
                builder.ToVisitor(visitor);

                xmlWriter.WriteEndElement();
            }
        }
    }
}