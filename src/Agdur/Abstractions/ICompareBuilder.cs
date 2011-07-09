using System.IO;

namespace Agdur.Abstractions
{
    public interface ICompareBuilder
    {
        void ToBaseline<TProfile>(string path)
            where TProfile : IBenchmarkBaselineProfile, new();

        void ToBaseline<TProfile>(TextReader reader)
            where TProfile : IBenchmarkBaselineProfile, new();
    }
}