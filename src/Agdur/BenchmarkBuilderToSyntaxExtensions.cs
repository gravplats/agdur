using Agdur.Introspection;
using Agdur.IO;

namespace Agdur
{
    public static class BenchmarkBuilderToSyntaxExtensions
    {
        /// <summary>
        /// Writes the output to the console.
        /// </summary>
        public static IBenchmarkBuilderAsSyntax ToConsole(this IBenchmarkBuilderToSyntax builder)
        {
            var generator = new TextGenerator(builder);
            return new ConsoleBenchmarkBuilderAsSyntax(generator);
        }

        /// <summary>
        /// Writes the output to the specified path or filename. If a filename or relative path is specified it will be
        /// relative the current base directory of the executing app domain.
        /// </summary>
        /// <param name="filenameOrPath"></param>
        public static IBenchmarkBuilderAsSyntax ToPath(this IBenchmarkBuilderToSyntax builder, string filenameOrPath)
        {
            Ensure.NotNullOrEmpty(filenameOrPath, "filenameOrPath", "Please specify a valid path or filename");

            var generator = new TextGenerator(builder);
            string path = PathGenerator.Generate(filenameOrPath);
            
            return new PathBenchmarkBuilderAsSyntax(generator, path);
        }
    }
}