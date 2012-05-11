using System;

namespace Agdur
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
            generator.Generate(Console.Out, outputStrategy);
        }
    }
}