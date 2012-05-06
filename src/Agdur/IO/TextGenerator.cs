using System.IO;
using Agdur.Abstractions;
using Agdur.Introspection;

namespace Agdur.IO
{
    /// <summary>
    /// Provides functionality for generating output of a benchmark.
    /// </summary>
    public class TextGenerator
    {
        private readonly IBenchmarkBuilderToSyntax builder;

        /// <summary>
        /// Creates a new instance of the <see cref="TextGenerator"/> class.
        /// </summary>
        /// <param name="builder"></param>
        public TextGenerator(IBenchmarkBuilderToSyntax builder)
        {
            Ensure.NotNull(builder, "builder");
            this.builder = builder;
        }

        /// <summary>
        /// Generates output using the specified writer and output strategy.
        /// </summary>
        /// <param name="writer">The writer that should be used to generate the output.</param>
        /// <param name="outputStrategy">The output strategy that should be used to generate the output.</param>
        /// <returns>The output of a benchmark.</returns>
        public string Generate(TextWriter writer, IOutputStrategy outputStrategy)
        {
            Ensure.NotNull(writer, "writer");
            Ensure.NotNull(outputStrategy, "outputStrategy");

            builder.ToCustom(writer).AsCustom(outputStrategy);
            return writer.ToString();
        }
    }
}