using System.IO;
using Agdur.Abstractions;

namespace Agdur.IO
{
    public class PathBenchmarkBuilderAsSyntax : IBenchmarkBuilderAsSyntax
    {
        private readonly TextGenerator generator;
        private readonly string path;

        public PathBenchmarkBuilderAsSyntax(TextGenerator generator, string path)
        {
            this.generator = generator;
            this.path = path;
        }

        public void AsCustom(IOutputStrategy outputStrategy)
        {
            using (var stream = File.Open(path, FileMode.CreateNew))
            using (var writer = new StreamWriter(stream))
            {
                string result = generator.Generate(writer, outputStrategy);
                writer.WriteLine(result);
            }
        }
    }
}