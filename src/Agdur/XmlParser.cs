using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Agdur
{
    public static class XmlParser
    {
        public static IDictionary<string, double> Parse(string xml)
        {
            var root = XElement.Parse(xml);

            var collection = new Dictionary<string, double>();
            foreach (var element in root.Descendants())
            {
                string name = GetName(element);
                if (collection.ContainsKey(name))
                {
                    // TODO: format...
                    throw new InvalidOperationException();
                }
                
                double value = Convert.ToDouble(element.Value);
                collection.Add(name, value);
            }

            return collection;
        }

        private static string GetName(XElement element)
        {
            string name = element.Name.ToString();
            if (element.HasAttributes)
            {
                var attribute = element.Attribute("index");
                if (attribute != null)
                {
                    return name + "-" + attribute.Value;
                }
            }

            return name;
        }
    }
}