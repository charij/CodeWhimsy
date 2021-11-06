using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Algorithms.GraphSearch
{
    public class TwoSum {

        private long[] Xs;

        public TwoSum(string data) {
            Xs = Array.ConvertAll(File.ReadAllLines(data), long.Parse);
        }

        public int Compute(long min, long max) {
            var h = new HashSet<long>(Xs);
            var tally = 0;

            for (var t = min; t <= max; t++)
                for (var i = 0; i < Xs.Length; i++)
                    if (t != Xs[i] << 1 && h.Contains(t - Xs[i]))
                    {
                        tally++;
                        break;
                    }

            return tally;
        }

        public int Compute2(long min, long max) {
            var ts = new HashSet<long>();

            Xs = Xs.Distinct().OrderBy(i => i).ToArray();

            foreach (var x in Xs) {
                int lo = Array.BinarySearch(Xs, min - x),                   // find the first index that is greater or equal to loLimit
                    hi = Array.BinarySearch(Xs, max - x);                   // find the last index that is less than or equal to hiLimit

                if (lo < 0) lo = ~lo;                                       // Fix result if exact limit not found
                if (hi < 0) hi = ~hi;                                       // Fix result if exact limit not found

                ts.UnionWith(Xs.Skip(lo).Take(hi-lo).Select(j => j + x));   // Store distinct results that lie in range min -> max
            }            
            return ts.Count();
        }
    }
}
