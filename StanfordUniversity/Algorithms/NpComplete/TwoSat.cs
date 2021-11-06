using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms.NpComplete
{
    public static class TwoSat
    {
        private class Clause
        {
            public int  cA;
            public int  cB;
            public bool sA;
            public bool sB;
        }

        public static bool Compute(string file)
        {
            var _conditions = new HashSet<int>();
            var _clauses = new HashSet<Clause>();

            foreach (var line in File.ReadAllLines(file).Skip(1))
            {
                var d = Array.ConvertAll(line.Split(), int.Parse);

                _clauses.Add(new Clause { cA = Math.Abs(d[0]), cB = Math.Abs(d[1]), sA = (d[0] >= 0), sB = (d[1] >= 0) });
                _conditions.Add(Math.Abs(d[0]));
                _conditions.Add(Math.Abs(d[1]));
            }

            var R = new Random();
            var i_limit = (int) Math.Log(_conditions.Count, 2) + 1;
            var j_limit = 2 * _conditions.Count * _conditions.Count;
            for (var i = 0; i < i_limit; i++)
            {
                var solution = _conditions.ToDictionary(k => k, v => R.Next(0, 1) == 1);
                for (var j = 0; j < j_limit; j++)
                {
                    var unsatisified = _clauses.FirstOrDefault(o => (o.sA != solution[o.cA] && (o.sB != solution[o.cB])));
                    if (unsatisified == null)
                        return true;

                    var clause = unsatisified.sA != solution[unsatisified.cA] ? unsatisified.cA : unsatisified.cB;
                    solution[clause] = !solution[clause];
                }
            }
            return false;
        }

        private class Node
        {
            public int Id;
            public bool Flag { get; set; }
        }
        private class Edge
        {
            public int In;
            public int Out;
        }

        public static bool FastCompute(string file)
        {
            var edges = new HashSet<Edge>();
            foreach (var line in File.ReadAllLines(file).Skip(1))
            {
                var d = Array.ConvertAll(line.Split(), int.Parse);
                edges.Add(new Edge { Out = -d[0], In = d[1] });
                edges.Add(new Edge { Out = -d[1], In = d[0] });
            }

            var nodes = new HashSet<int>(edges.SelectMany(i => new[] { i.In, i.Out }));
            var progress = nodes.ToDictionary(i => i, j => false);
            var graph = nodes.ToDictionary(i => i, j => new Tuple<List<int>, List<int>>(new List<int>(), new List<int>()));
            foreach (var edge in edges)
            {
                graph[edge.In].Item1.Add(edge.Out);
                graph[edge.Out].Item2.Add(edge.In);
            }
            
            var times = new Stack<int>();
            foreach (var node in nodes)
            {
                var stack = new Stack<int>(new[] { node });
                while (stack.Count > 0)
                {
                    var c = stack.Pop();
                    if (progress[c])
                        continue;

                    progress[c] = true;
                    times.Push(c);
                    var t = graph[c].Item2;
                    foreach (var neighbour in t)
                        if (!progress[neighbour])
                            stack.Push(neighbour);
                }
            }
            
            var leaders = nodes.ToDictionary(i => i, j => 0);
            foreach (var node in times)
            {
                var stack = new Stack<int>(new[] { node });
                while (stack.Count > 0)
                {
                    var c = stack.Pop();
                    if (!progress[c])
                        continue;
                    
                    if (leaders[-c] == node)
                        return false;
                    
                    progress[c] = false;
                    leaders[c] = node;
                    var t = graph[c].Item1;
                    foreach (var neighbour in t)
                        if (progress[neighbour])
                            stack.Push(neighbour);
                }
            }

            return true;
        }
    }
}