using System.IO;
using Agdur.Abstractions;

namespace Agdur
{
    public class PathBenchmarkBuilderAsSyntax : IBenchmarkBuilderAsSyntax
    {
        private readonly IBenchmarkBuilderContinutation builder;
        private readonly string path;

        public PathBenchmarkBuilderAsSyntax(IBenchmarkBuilderContinutation builder, string path)
        {
            this.builder = builder;
            this.path = path;
        }

        public void AsCustom(OutputStrategyBase outputStrategy)
        {
            using (var stream = File.Open(path, FileMode.CreateNew))
            using (var writer = new StreamWriter(stream))
            {
                builder.ToCustom(writer).AsCustom(outputStrategy);

                string result = writer.ToString();
                writer.WriteLine(result);
            }
        }
    }
}