using System.IO;

namespace Agdur.Abstractions
{
    public interface IBenchmarkBuilderToSyntax
    {
        IBenchmarkBuilderAsSyntax ToCustom(TextWriter writer);
    }
}