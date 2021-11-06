using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms.Common
{
    public interface IEdge<T, U>
        : IComparable
    {
        T From   { get; }
        T To     { get; }
        U Weight { get; }
    }

    public class Graph<T, U>
        where T : IComparable
        where U : IEdge<T, U>
    {
        private class Vertex
        {
            public Heap<U> In  = new Heap<U>(-1);
            public Heap<U> Out = new Heap<U>(-1);
        }

        private readonly IDictionary<T, Vertex> Vertices = new Dictionary<T, Vertex>();
        private readonly HashSet<U> Edges = new HashSet<U>();

        public int VertexCount { get { return Vertices.Keys.Count; } }
        public int EdgeCount   { get; private set; }

        public Graph()
        {

        }

        public void AddEdge(params T[] edges)
        {
            EdgeCount++;
        }

        public Graph<T, U> GetSCC()
        {
            return null;
        }

        public Graph<T, U> GetMST()
        {
            return null;
        }

        public U[] GetShortestPath(T a, T b, params T[] c)
        {
            var buckets = new Dictionary<T, List<T>>(2 + c.Length); // todo add the node buckets
            var unvisitedNodes = new HashSet<T>(Vertices.Keys.Where(i => i.CompareTo(a) != 0)
                                                             .Where(i => i.CompareTo(b) != 0)
                                                             .Where(i => !c.Contains(i)));
            var potentialEdges = new HashSet<U>(Edges.Where(i => buckets.ContainsKey(i.From))
                                                     .Where(i => buckets.ContainsKey(i.To)));
            while (unvisitedNodes.Count > 0)
            {
                var minEdge = potentialEdges.Min(i => i.Weight);                        // find the smallest possible weighted edge

                if (buckets.ContainsKey(minEdge.From))
                {//todo: fix for tree structure of path
                    buckets[minEdge.From].Add(minEdge.To);                              // add minEdge vertex to the appropriate bucket
                }
                else
                {//todo
                    buckets[minEdge.To].Add(minEdge.From);                              // add minEdge vertex to the appropriate bucket
                }
                
                if (unvisitedNodes.Contains(minEdge.From))                              // If edge connects to an unvisited node
                    unvisitedNodes.Remove(minEdge.From);                                //  remove node from the unvisited list
                else
                if (unvisitedNodes.Contains(minEdge.To))
                    unvisitedNodes.Remove(minEdge.To);                                  //  remove node from the unvisited list
                else
                {                                                                       // Else edge must connect two buckets
                    buckets[minEdge.To].AddRange(buckets[minEdge.From]);                //  Merge buckets
                    buckets.Remove(minEdge.From);                                       //  Remove redundant bucket

                    if (buckets.Count == 1)                                             //  If only 1 bucket remaining
                        return null;                                                    //  TODO: return the complete path                    
                }
                
                potentialEdges.Remove(minEdge);                                         // remove minEdge from the potential list
                potentialEdges.RemoveWhere(i => i == null);                             // TODO: remove all edges that hyperconnect a single bucket
                potentialEdges.Union(Edges.Where(i => unvisitedNodes.Contains(i.From)   // Add new potential edges
                                                   != unvisitedNodes.Contains(i.To)));
            }
            return null; // Path not found
        }
    }
}
