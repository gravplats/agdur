using System;
using System.Collections.Generic;
using System.Linq;

namespace Agdur
{
    public static class SamplesExtensions
    {
        public static IEnumerable<double> GetData(this IEnumerable<TimeSpan> samples, Func<TimeSpan, IConvertible> dataProvider)
        {
            return samples.Select(dataProvider).Select(convertible => convertible.ToDouble(null));
        }
    }
}