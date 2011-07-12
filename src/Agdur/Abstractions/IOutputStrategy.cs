using System.Collections.Generic;
using System.IO;

namespace Agdur.Abstractions
{
    public interface IOutputStrategy
    {
        void Execute(TextWriter writer, IList<IMetric> metrics);
    }
}