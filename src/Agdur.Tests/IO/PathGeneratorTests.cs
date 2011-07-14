using System;
using System.IO;
using Agdur.Tests.Utilities;
using Xunit;

namespace Agdur.Tests.IO
{
    public class PathGeneratorTests
    {
        [Fact]
        public void Should_echo_absolute_path()
        {
            string path = "c:\\absolute\\filename";
            string result = PathGenerator.Generate(path);

            result.ShouldBe(path);
        }

        [Fact]
        public void Should_add_current_path_if_filename()
        {
            string filename = "filename";
            string result = PathGenerator.Generate(filename);

            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string expected = Path.Combine(directory, filename);

            result.ShouldBe(expected);
        }
    }
}