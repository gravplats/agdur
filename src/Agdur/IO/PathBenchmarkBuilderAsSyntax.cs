using System.IO;
using Agdur.Abstractions;
using Agdur.Introspection;

namespace Agdur.IO
{
    /// <summary>
    /// Provides functionality for outputting the results to a path.
    /// </summary>
    public class PathBenchmarkBuilderAsSyntax : IBenchmarkBuilderAsSyntax
    {
        private readonly TextGenerator generator;
        private readonly string path;

        /// <summary>
        /// Creates a new instance of the <see cref="PathBenchmarkBuilderAsSyntax"/> class.
        /// </summary>
        /// <param name="generator">The text generator.</param>
        /// <param name="path">The path that the output should be written to.</param>
        public PathBenchmarkBuilderAsSyntax(TextGenerator generator, string path)
        {
            Ensure.ArgumentNotNull(generator, "generator");
            Ensure.NotNullOrEmpty(path, "path");
            
            this.generator = generator;
            this.path = path;
        }

        /// <inheritdoc/>
        public void AsCustom(IOutputStrategy outputStrategy)
        {
            Ensure.ArgumentNotNull(outputStrategy, "outputStrategy");
            using (var stream = File.Open(path, FileMode.CreateNew))
            using (var writer = new StreamWriter(stream))
            {
                string result = generator.Generate(writer, outputStrategy);
                writer.WriteLine(result);
            }
        }
    }
}