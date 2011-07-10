using System.IO;
using Agdur.Abstractions;
using Agdur.Internals;

namespace Agdur
{
    public class CompareBuilder : ICompareBuilder
    {
        private readonly IBenchmarkBuilder builder;

        public CompareBuilder(IBenchmarkBuilder builder)
        {
            this.builder = builder;
        }

        public void ToBaseline<TProfile>(string path) where TProfile : IBenchmarkBaselineProfile, new()
        {
            using (var stream = File.Open(path, FileMode.Open))
            using (var reader = new StreamReader(stream))
            {
                ToBaseline<TProfile>(reader);
            }
        }

        public void ToBaseline<TProfile>(TextReader reader) where TProfile : IBenchmarkBaselineProfile, new()
        {
            Ensure.ArgumentNotNull(reader, "reader");

            using (var writer = new StringWriter())
            {
                var profile = new TProfile();
                profile.Define(builder).ToXml(writer);

                string xml = writer.ToString();
                string baseline = reader.ReadToEnd();
            }
        }
    }
}