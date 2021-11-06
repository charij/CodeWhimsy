using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Algorithms.Greedy
{
    public class MinSpanningTree
    {
        private List<int[]> Edges = new List<int[]>();

        public MinSpanningTree(string file)
        {
            var data = File.ReadAllLines(file);            
            foreach (var line in data.Skip(1))
                Edges.Add(Array.ConvertAll(line.Split(null), int.Parse));
        }

        public int PrimsAlgorithm()
        {
            var nodes = new HashSet<int>(Edges.Select(i => i[0]).Concat(Edges.Select(i => i[1])));
            var mst = new List<int[]>();

            while (nodes.Count > 0)
            {
                var edge = Edges.Where(i => (nodes.Contains(i[0]) != nodes.Contains(i[1]) || mst.Count == 0))
                                .Aggregate((i,j) => i = i[2] < j[2] ? i : j);
                
                mst.Add(edge);
                
                nodes.Remove(edge[0]);
                nodes.Remove(edge[1]);
            }

            return mst.Select(i => i[2]).Sum();
        }
    }
}
