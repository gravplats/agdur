using System.IO;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    public class CompareBuilder : ICompareBuilder
    {
        public void ToBaseline<TProfile>(string path)
            where TProfile : IBenchmarkBaselineProfile, new()
        {

        }

        public void ToBaseline<TProfile>(TextReader reader)
            where TProfile : IBenchmarkBaselineProfile, new()
        {

        }
    }
}