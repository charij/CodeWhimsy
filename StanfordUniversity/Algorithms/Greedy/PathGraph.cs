using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms.Greedy
{
    public class PathGraph
    {
        public readonly List<int> Weights;
        
        public PathGraph(string file)
        {
            Weights = new List<int>(Array.ConvertAll(File.ReadAllLines(file).Skip(1).ToArray(), int.Parse));
        }

        public int[] MaxWeightSet(params int[] ids)
        {
            var A = new List<int>{ 0, Weights[1] };
            var S = new List<int>();

            // Calc Max Weight
            for (var i = 1; i < Weights.Count; i++)
                A.Add(Math.Max(A[i], A[i - 1] + Weights[i]));
        
            // Reconstruct Members
            for (var i = A.Count - 1; i > 0; i--)
                if (A[i] != A[i - 1])
                    S.Add(i--);

            return ids.Select(i => S.Contains(i) ? 1 : 0).ToArray();
        }
    }
}