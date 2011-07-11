using System;
using System.IO;
using Agdur.Abstractions;

namespace Agdur
{
    public class ConsoleBenchmarkBuilderAsSyntax : IBenchmarkBuilderAsSyntax
    {
        private readonly IBenchmarkBuilderContinutation builder;

        public ConsoleBenchmarkBuilderAsSyntax(IBenchmarkBuilderContinutation builder)
        {
            this.builder = builder;
        }

        public void AsCustom(OutputStrategyBase outputStrategy)
        {
            using (var writer = new StringWriter())
            {
                builder.ToCustom(writer).AsCustom(outputStrategy);

                string result = writer.ToString();
                Console.WriteLine(result);
            }
        }
    }
}