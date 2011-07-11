using System;
using System.IO;
using Agdur.Abstractions;

namespace Agdur
{
    public class ConsoleBenchmarkBuilderAsSyntax : IBenchmarkBuilderAsSyntax
    {
        private readonly TextGenerator generator;

        public ConsoleBenchmarkBuilderAsSyntax(TextGenerator generator)
        {
            this.generator = generator;
        }

        public void AsCustom(OutputStrategyBase outputStrategy)
        {
            using (var writer = new StringWriter())
            {
                string result = generator.Generate(writer, outputStrategy);
                Console.WriteLine(result);
            }
        }
    }
}