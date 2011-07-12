using Agdur.Abstractions;
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

        public static IBenchmarkBuilderAsSyntax ToPath(this IBenchmarkBuilderContinutation builder, string path)
        {
            var generator = new TextGenerator(builder);
            return new PathBenchmarkBuilderAsSyntax(generator, path);
        }
    }
}