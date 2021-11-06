using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.GraphSearch {
    public class Dijkstra {
        public class Edge {
            public int From;
            public int To;
            public int Weight;
        }

        public Dictionary<int, List<Edge>> Graph = new Dictionary<int, List<Edge>>();

        public Dijkstra(string data) {
            using (var file = new StreamReader(new FileStream(data, FileMode.Open, FileAccess.Read, FileShare.Read), System.Text.Encoding.UTF8, true, 128)) {
                while ((data = file.ReadLine()) != null) {
                    var values = Array.ConvertAll(data.Split(new[] { '\t', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);       
                    
                    if (!Graph.TryGetValue(values[0], out var vertex))
                        Graph[values[0]] = vertex = new List<Edge>();

                    for (var i = 1; i < values.Length - 1; i += 2)
                        vertex.Add(new Edge { From = values[0], To = values[i], Weight = values[i+1] });
                }
            }
        }

        public int[] Compute(int source, params int[] targets) {
            return targets.Select(i => ShortestPath(source, i)).ToArray();
        }

        public int ShortestPath(int from, int to) {
            var d = new Dictionary<int, int> { [from] = 0 };
            while (!d.ContainsKey(to)) {
                var u = Graph.SelectMany(i => i.Value.FindAll(j => d.ContainsKey(j.From) && !d.ContainsKey(j.To)))              // all relevent edges
                             .Aggregate((min, next) => d[min.From] + min.Weight < d[next.From] + next.Weight ? min : next);     // find least weight edge that adds to path

                if (u.To == to)
                    return d[u.From] + u.Weight;                                                                                // if end of path return length                            
                
                d[u.To]  = d[u.From] + u.Weight;                                                                                // add to visited vertices & set path distance to this node
            }
            return 0;
        }
    }
}
