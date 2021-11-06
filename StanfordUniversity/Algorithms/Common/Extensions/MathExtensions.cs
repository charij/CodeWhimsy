using System.Linq;

namespace Algorithms.Common.Extensions
{
    public static class MathExtensions
    {
        public static int Min(params int[] values)
        {
            return values.Aggregate((min, next) => min < next ? min : next);
        }

        public static int Max(params int[] values)
        {
            return values.Aggregate((max, next) => max > next ? max : next);
        }
    }
}
