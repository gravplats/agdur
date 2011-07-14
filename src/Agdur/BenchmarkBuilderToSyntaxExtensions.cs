using Agdur.Abstractions;
using Agdur.Introspection;
using Agdur.IO;

namespace Agdur
{
    public static class BenchmarkBuilderToSyntaxExtensions
    {
        public static IBenchmarkBuilderAsSyntax ToConsole(this IBenchmarkBuilderContinutation builder)
        {
            var generator = new TextGenerator(builder);
            return new ConsoleBenchmarkBuilderAsSyntax(generator);
        }

        public static IBenchmarkBuilderAsSyntax ToPath(this IBenchmarkBuilderContinutation builder, string filenameOrPath)
        {
            Ensure.NotNullOrEmpty(filenameOrPath, "filenameOrPath", "Please specify a valid path or filename");

            var generator = new TextGenerator(builder);
            string path = PathGenerator.Generate(filenameOrPath);
            
            return new PathBenchmarkBuilderAsSyntax(generator, path);
        }
    }
}