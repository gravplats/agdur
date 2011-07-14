using System;
using System.IO;
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

        public static IBenchmarkBuilderAsSyntax ToPath(this IBenchmarkBuilderContinutation builder, string pathOrFilename)
        {
            Ensure.NotNullOrEmpty(pathOrFilename, "path", "Please specify a valid path or filename");
                
            string path = pathOrFilename;
            if (!Path.IsPathRooted(pathOrFilename))
            {
                string filename = pathOrFilename;
                string directory = AppDomain.CurrentDomain.BaseDirectory;
                path = Path.Combine(directory, filename);
            }

            var generator = new TextGenerator(builder);
            return new PathBenchmarkBuilderAsSyntax(generator, path);
        }
    }
}