using System.IO;

namespace Agdur.Abstractions
{
    public interface ICompareBuilder
    {
        void ToBaseline<TProfile>(string path)
            where TProfile : IBenchmarkProfile, new();

        void ToBaseline<TProfile>(TextReader reader)
            where TProfile : IBenchmarkProfile, new();
    }
}