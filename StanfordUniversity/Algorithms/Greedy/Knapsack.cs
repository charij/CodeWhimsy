using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms.Greedy
{
    public class Knapsack
    {
        private readonly int maxSize;
        private readonly int maxItems;
        private readonly int[] W;
        private readonly int[] V;

        public Knapsack(string file)
        {
            var raw = File.ReadAllLines(file);
            var info = Array.ConvertAll(raw[0].Split(null), int.Parse);
            var items = new List<int[]>(raw.Skip(1).Select(i => Array.ConvertAll(i.Split(null), int.Parse)));

            maxSize = info[0];
            maxItems = info[1];
            W = items.Select(i => i[1]).ToArray();
            V = items.Select(i => i[0]).ToArray();
        }

        public int OptimalValue()
        {
            var A = new int[2, maxSize];
            for (int i = 1; i < maxItems; i++)
                for (var j = 0; j < maxSize; j++)
                    A[i % 2, j] = W[i] > j
                            ? A[(i - 1) % 2, j]
                            : Math.Max(A[(i - 1) % 2, j], A[(i - 1) % 2, j - W[i]] + V[i]);

            return A[(maxItems - 1) % 2, maxSize - 1];
        }

        public int[] Compute()
        {
            var A = new int[maxItems, maxSize];
            for (var i = 1; i < maxItems; i++)
                for (var j = 0; j < maxSize; j++)
                    A[i, j] = W[i] > j
                            ? A[i - 1, j]
                            : Math.Max(A[i - 1, j], A[i - 1, j - W[i]] + V[i]);
            
            var S = new List<int>();
            //for (var i = maxItems - 1; i > 0; i--)
            //    for (var j = maxSize - 1; j > 0; j--)
            //        if ()
            //            S.Add(j);

            return S.ToArray();
        }
    }
}
