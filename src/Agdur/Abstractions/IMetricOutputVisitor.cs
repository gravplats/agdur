using Agdur.Internals;

namespace Agdur.Abstractions
{
    public interface IMetricOutputVisitor
    {
        void Visit(SingleValueMetric metric);

        void Visit(MultipleValueMetric metric);
    }
}