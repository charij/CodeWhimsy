using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.GraphSearch {
    public class Graph {
        private class Vertex {
            public List<int> Next;
            public List<int> Prev;
            public bool Flag { get; set; }
        }

        private Dictionary<int, Vertex> G = new Dictionary<int, Vertex>();

        public Graph(string data) {
            using (var file = new StreamReader(new FileStream(data, FileMode.Open, FileAccess.Read, FileShare.Read), System.Text.Encoding.UTF8, true, 128)) {
                while ((data = file.ReadLine()) != null) {
                    var arc = Array.ConvertAll(data.Split(new char[0], StringSplitOptions.RemoveEmptyEntries), int.Parse);
                    
                    if (!G.TryGetValue(arc[0], out var vertex))
                        G[arc[0]] = vertex = new Vertex { Next = new List<int>(), Prev = new List<int>(), Flag = false };
                    vertex.Next.Add(arc[1]);
                    
                    if (!G.TryGetValue(arc[1], out vertex))
                        G[arc[1]] = vertex = new Vertex { Next = new List<int>(), Prev = new List<int>(), Flag = false };
                    vertex.Prev.Add(arc[0]);
                }
            }
        }

        public int[] ComputeSCCs(int n) {
            // First Pass - Find finishing times
            var finishtimes = new List<int>();
            foreach (var pair in G) {
                var times = new Stack<int>();
                var stack = new Stack<int>(new[] { pair.Key });
                while (stack.Count > 0) {
                    var key = stack.Pop();
                    if (G[key].Flag)
                        continue;

                    G[key].Flag = true;
                    times.Push(key);
                    for (var j = 0; j < G[key].Prev.Count; j++)
                        if (!G[G[key].Prev[j]].Flag)
                            stack.Push(G[key].Prev[j]);                    
                }
                while (times.Count > 0)
                    finishtimes.Add(times.Pop());
            }

            // Second Pass - Find leaders
            var leaders = new List<int>();
            for (var i = finishtimes.Count - 1; i >= 0; i--) {
                var stack = new Stack<int>(finishtimes[i]);
                while (stack.Count > 0) {
                    var key = stack.Pop();
                    if (!G[key].Flag)
                        continue;

                    G[key].Flag = false;
                    leaders.Add(finishtimes[i]);
                    for (var j = 0; j < G[key].Next.Count; j++)
                        if (G[G[key].Next[j]].Flag)
                            stack.Push(G[key].Next[j]);
                }
            }

            // Count largest n SCC sizes - (Nodes with the same leader)
            return leaders.GroupBy(_=>_).Select(_ =>_.Count()).OrderByDescending(i => i).Take(n).ToArray();
        }
    }
}