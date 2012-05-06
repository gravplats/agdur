using System;
using System.IO;
using Agdur.Introspection;

namespace Agdur.IO
{
    /// <summary>
    /// Provides functionality for outputting the results to the console.
    /// </summary>
    public class ConsoleBenchmarkBuilderAsSyntax : IBenchmarkBuilderAsSyntax
    {
        private readonly TextGenerator generator;

        /// <summary>
        /// Creates a new instance of the <see cref="ConsoleBenchmarkBuilderAsSyntax"/> class.
        /// </summary>
        /// <param name="generator">The text generator.</param>
        public ConsoleBenchmarkBuilderAsSyntax(TextGenerator generator)
        {
            Ensure.ArgumentNotNull(generator, "generator");
            this.generator = generator;
        }

        /// <inheritdoc/>
        public void AsCustom(IOutputStrategy outputStrategy)
        {
            Ensure.ArgumentNotNull(outputStrategy, "outputStrategy");
            using (var writer = new StringWriter())
            {
                string result = generator.Generate(writer, outputStrategy);
                Console.WriteLine(result);
            }
        }
    }
}