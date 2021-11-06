using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.NpComplete
{
    public class HashMap<T>
    {
        private readonly IDictionary<T, int> _dict = new Dictionary<T, int>();
        private readonly IList<T>            _list = new List<T>();

        public void Add(T value)
        {
            if (_dict.ContainsKey(value))
                throw new Exception("Duplicate Key");

            _dict[value] = _list.Count;
            _list.Add(value);
        }

        public T this[int index]
        {
            get { return _list[index]; }
        }

        public int this[T value]
        {
            get { return _dict[value]; }
        }
    }

    /// <summary>
    /// Directed integer-weighted Graph with adjacency-list edge representation
    /// </summary>
    public class Graph
    {
        public class Edge
        {
            public int In { get; set; }
            public int Out { get; set; }
            public int Weight { get; set; }

            public Edge(int _out, int _in, int _weight)
            {
                Out = _out;
                In = _in;
                Weight = _weight;
            }
        }

        internal class EdgeSet
        {
            public IList<Edge> Ins  = new List<Edge>();
            public IList<Edge> Outs = new List<Edge>();
        }
        
        private readonly IList<int> _vertices;
        private readonly IList<Edge> _edges;
        private readonly IDictionary<int, EdgeSet> _graph;


        public Graph(IEnumerable<Edge> edges)
        {
            _edges    = new List<Edge>(edges);
            _vertices = new List<int>(edges.Select(i => i.In).Union(edges.Select(i => i.Out)));
            _graph    = new Dictionary<int, EdgeSet>();

            foreach (var vertex in _vertices)
                _graph[vertex] = new EdgeSet();

            foreach (var edge in _edges)
            {
                _graph[edge.In].Ins.Add(edge);
                _graph[edge.Out].Outs.Add(edge);
            }
        }

        public void Add(params int[] vertices)
        {
            foreach (var vertex in vertices)
            {
                _vertices.Add(vertex);
                _graph[vertex] = new EdgeSet();
            }
        }
        public void Add(params Edge[] edges)
        {
            foreach (var edge in edges)
            {
                _edges.Add(edge);
                _graph[edge.In].Ins.Add(edge);
                _graph[edge.Out].Outs.Add(edge);
            }
        }
        public void Remove(params int[] vertices)
        {
            foreach (var vertex in vertices)
            {
                _vertices.Remove(vertex);
                _graph.Remove(vertex);
            }
        }
        public void Remove(params Edge[] edges)
        {
            foreach (var edge in edges)
            {
                _edges.Remove(edge);
                _graph.Remove(edge.In);
                _graph.Remove(edge.Out);
            }
        }

        /// <summary>
        /// Calculates the optimal shortest path from source vertex to target vertex
        /// </summary>
        public IEnumerable<Edge> Dijkstra(int source, int target)
        {
            var unvisited = new HashSet<int>(_vertices.Where(i => i != source));
            var sourceMap = new Dictionary<int, Tuple<int, Common.LinkedList<Edge>>> { [source] = new Tuple<int, Common.LinkedList<Edge>> (0, null) };
            while (!sourceMap.ContainsKey(target))
            {
                var minEdge = _edges.Where(i => unvisited.Contains(i.In) != unvisited.Contains(i.Out))
                                    .Aggregate((m, n) => sourceMap[m.Out].Item1 + m.Weight < sourceMap[n.Out].Item1 + n.Weight ? m : n);
                var llNode = new Common.LinkedList<Edge>{ Value = minEdge, Prev = sourceMap[minEdge.Out].Item2 };

                sourceMap[minEdge.In] = new Tuple<int, Common.LinkedList<Edge>>(sourceMap[minEdge.Out].Item1 + minEdge.Weight, llNode);
                unvisited.Remove(minEdge.In);
                unvisited.Remove(minEdge.Out);
            }

            return sourceMap[target].Item2.Compile();
        }

        /// <summary>
        /// Calculates the optimal shortest paths from source vertex to every other vertex
        /// </summary>
        public IDictionary<int, IEnumerable<Edge>> BellmanFord(int source)
        {
            // Initialize 
            var n = _vertices.Count;
            var w = _edges.Count;
            var A = new int[n][];

            for (var i = 0; i < n; i++)
                A[i] = new int[w];

            for (var j = 0; j < w; j++)
                A[0][j] = j == source ? 0 : -1;

            // Dynamically run through sub-problems
            //for (var i = 1; i < n; i++)
            //for (var j = 0; j < w; j++)
            //    A[i - 1][j] = Math.Min(A[i - 1][j],
            //        Math.Min(A[i - 1][0] + W[j]));//todo
            
            // If new information after row n-1 then negative cycle
            var hasNegativeCycle = !A[n].SequenceEqual(A[n-1]);
            if (hasNegativeCycle)
                return null;
            
            // Reconstruct Optimal Solution
            var output = new Dictionary<int, IEnumerable<Edge>>();
                //todo
            
            return output;
        }

        /// <summary>
        /// Calculates the optimal shortest paths between every vertex pair
        /// </summary>
        public IDictionary<Tuple<int, int>, IEnumerable<Edge>> FloydWarshall()
        {
            // Set initial values
            var A = new int[_vertices.Count, _vertices.Count, _vertices.Count];
            for (var i = 0; i < _vertices.Count; i++)
            for (var j = 0; j < _vertices.Count; j++)
                if (i == j)
                {
                    A[i, j, 0] = 0;
                }
                else
                {
                    var connectingEdges = _graph[_vertices[i]].Outs.Union(_graph[_vertices[j]].Ins);
                    if (connectingEdges.Any())
                        A[i, j, 0] = connectingEdges.Min(k => k.Weight);
                    else
                        A[i, j, 0] = int.MaxValue;
                }

            // Dynamically process sub-problems
            for (var k = 1; k < _vertices.Count; k++)
            for (var i = 1; i < _vertices.Count; i++)
            for (var j = 1; j < _vertices.Count; j++)
                A[i, j, k] = Math.Min(A[i,j,k-1], A[i,k,k-1] + A[k,j,k-1]);

            // Check for negative cycles
            for (var ij = 0; ij < _vertices.Count; ij++)
            for (var k = 0; k < _vertices.Count; k++)
                if (A[ij, ij, k] < 0)
                    return null;

            // Reconstruct optimal solution
            var output = new Dictionary<Tuple<int,int>, IEnumerable<Edge>>();                
                //todo

            return output;
        }

        public int ShortestPath()
        {
            const int INFINITY = 0x0FFFFFFF;

            // Set initial values
            var A = new int[2, _vertices.Count, _vertices.Count];
            for (var i = 0; i < _vertices.Count; i++)
            for (var j = 0; j < _vertices.Count; j++)
                if (i == j)
                    A[0, i, j] = 0;
                else
                {
                    var connectingEdges = _graph[_vertices[i]].Outs.Intersect(_graph[_vertices[j]].Ins);
                    if (connectingEdges.Any())
                        A[0, i, j] = connectingEdges.Min(k => k.Weight);
                    else
                        A[0, i, j] = INFINITY;
                }

            // Dynamically process sub-problems
            for (var k = 1; k < _vertices.Count; k++)
            for (var i = 1; i < _vertices.Count; i++)
            for (var j = 1; j < _vertices.Count; j++)
                A[k % 2, i, j] = Math.Min(A[(k - 1) % 2, i, j], A[(k - 1) % 2, i, k] + A[(k - 1) % 2, k, j]);

            // Check for negative cycles
            for (var ij = 0; ij < _vertices.Count; ij++)
                if (A[(_vertices.Count - 1) % 2, ij, ij] < 0)
                    return INFINITY;

            var output = INFINITY;
            for (var i = 0; i < _vertices.Count; i++)
            for (var j = 1; j < _vertices.Count; j++)
                output = Math.Min(output, A[(_vertices.Count - 2) % 2, i, j]);
            return output;
        }


        /// <summary>
        /// Calculates the optimal shortest paths between every vertex pair
        /// </summary>
        public IDictionary<Tuple<int, int>, IEnumerable<Edge>> Johnsons()
        {
            var hasNegativeWeights = _edges.Any(i => i.Weight < 0);
            if (!hasNegativeWeights)
                return DijkstraAllPairs();
                        
            // Add source vertex and edges
            var sourceVertex = -1;
            var sourceEdges = _vertices.Select(i => new Edge(sourceVertex, i, 0)).ToArray();
            Add(sourceVertex);
            Add(sourceEdges);

            // Calculate Shortest Path from source to other vertices
            var r = BellmanFord(sourceVertex);

            // Return if negative cycle present
            if (r == null)
                return null;

            // Adjust edge lengths (remove negatives)
            for (var i = 0; i < _edges.Count; i++)
            {
                var u = r[_edges[i].Out].Sum(j => j.Weight);
                var v = r[_edges[i].In].Sum(j => j.Weight);
                _edges[i].Weight += u - v;
            }

            // Remove source vertex and edges
            Remove(sourceVertex);
            Remove(sourceEdges);

            // Calculate shortest paths with Dijkstra
            var output = DijkstraAllPairs();
            
            // Repair edge lengths
            for (var i = 0; i < _edges.Count; i++)
            {
                var u = r[_edges[i].Out].Sum(j => j.Weight);
                var v = r[_edges[i].In].Sum(j => j.Weight);
                _edges[i].Weight -= u + v;
            }

            return output;
        }

        /// <summary>
        /// Performs Dijkstra shortest path between every vertex pair
        /// </summary>
        private IDictionary<Tuple<int, int>, IEnumerable<Edge>> DijkstraAllPairs()
        {
            var output = new Dictionary<Tuple<int, int>, IEnumerable<Edge>>();
            for (var i = 0; i < _vertices.Count; i++)
            for (var j = 0; j < _vertices.Count; j++)
                if (i != j)
                    output[new Tuple<int, int>(i, j)] = Dijkstra(_vertices[i], _vertices[j]);
            return output;
        }
    }

    public class ShortestPath
    {
        public static Graph Load(string file)
        {
            var data = File.ReadAllLines(file).Skip(1).Select(i => Array.ConvertAll(i.Split(null), int.Parse));
            return new Graph(data.Select(i => new Graph.Edge(i[0], i[1], i[2])));
        }
    }
}