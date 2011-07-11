using Agdur.Abstractions;

namespace Agdur
{
    public static class BenchmarkBuilderToSyntaxExtensions
    {
        public static IBenchmarkBuilderAsSyntax ToConsole(this IBenchmarkBuilderContinutation builder)
        {
            return new ConsoleBenchmarkBuilderAsSyntax(builder);
        }

        public static IBenchmarkBuilderAsSyntax ToPath(this IBenchmarkBuilderContinutation builder, string path)
        {
            return new PathBenchmarkBuilderAsSyntax(builder, path);
        }
    }
}