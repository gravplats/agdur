using System.IO;

namespace Agdur
{
    /// <summary>
    /// Provides functionality for outputting the results to a path.
    /// </summary>
    public class PathBenchmarkBuilderAsSyntax : IBenchmarkBuilderAsSyntax
    {
        private readonly IBenchmarkBuilderToSyntax builder;
        private readonly string path;

        /// <summary>
        /// Creates a new instance of the <see cref="PathBenchmarkBuilderAsSyntax"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="path">The path that the output should be written to.</param>
        public PathBenchmarkBuilderAsSyntax(IBenchmarkBuilderToSyntax builder, string path)
        {
            Ensure.ArgumentNotNull(builder, "builder");
            Ensure.NotNullOrEmpty(path, "path");

            this.builder = builder;
            this.path = path;            
        }

        /// <inheritdoc/>
        public void AsCustom(IOutputStrategy outputStrategy)
        {
            Ensure.ArgumentNotNull(outputStrategy, "outputStrategy");
            
            using (var stream = File.Open(path, FileMode.Create))
            using (var writer = new StreamWriter(stream))
            {
                builder.ToCustom(writer).AsCustom(outputStrategy);
            }
        }
    }
}