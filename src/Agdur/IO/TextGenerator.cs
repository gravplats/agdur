using System.IO;
using Agdur.Abstractions;
using Agdur.Introspection;

namespace Agdur.IO
{
    public class TextGenerator
    {
        private readonly IBenchmarkBuilderContinutation builder;

        public TextGenerator(IBenchmarkBuilderContinutation builder)
        {
            Ensure.NotNull(builder, "builder");
            this.builder = builder;
        }

        public string Generate(TextWriter writer, IOutputStrategy outputStrategy)
        {
            Ensure.NotNull(writer, "writer");
            Ensure.NotNull(outputStrategy, "outputStrategy");

            builder.ToCustom(writer).AsCustom(outputStrategy);
            return writer.ToString();
        }
    }
}