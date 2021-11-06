using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Algorithms.NpComplete
{
    public class TravellingSalesman
    {
        private class Node
        {
            public int Value { get; set; }
            public Node[] ChildNodes { get; set; }
            public bool Selected { get; set; }
        }

        private readonly int[]     _cities;
        private readonly double[,] _matrix;
        private int _rootCity;
        
        public double Compute()
        {
            int[]  A = Enumerable.Range(00, 13).ToArray(),
                   B = Enumerable.Range(13, 12).ToArray(), 
                   C = Enumerable.Range(11, 4).ToArray();
            int[]  aPath, // 0, 1, 5, 9, 10, 11, 12, 8, 6, 2, 3, 7, 4
                   bPath, // 13, 14, 18, 17, 21, 22, 20, 16, 19, 24, 23, 15
                   cPath; // 11, 12, 13, 14
                // fPath = new[] { 0, 1, 5, 9, 10, 11, 14, 18, 17, 21, 22, 20, 16, 19, 24, 23, 15, 13, 12, 8, 6, 2, 3, 7, 4 };
            double a = 14662.0046407879,
                   b = 11873.114044942213,
                   c = 7236.4078544812328;
            {
                var cRoot = new Node();
                _rootCity = C.First();
                c = GetMinCostRoute(_rootCity, new List<int>(C.Skip(1)), cRoot);
                //cPath = TraverseTree(cRoot, C.First()).ToArray();
            }
            {
                var bRoot = new Node();
                _rootCity = B.First();
                b = GetMinCostRoute(B.First(), new List<int>(B.Skip(1)), bRoot);
                //bPath = TraverseTree(bRoot, B.First()).ToArray();
            }
            {
                var aRoot = new Node();
                _rootCity = A.First();
                a = GetMinCostRoute(A.First(), new List<int>(A.Skip(1)), aRoot);
                //aPath = TraverseTree(aRoot, A.First()).ToArray();
            }

            return (a + b + c) - (2 * _matrix[11,12]) + (2 * _matrix[13,14]);
        }

        private double GetMinCostRoute(int startVertex, List<int> set, Node root = null)
        {
            if (!set.Any())
            {
                //root.ChildNodes = new Node[1] { new Node { Value = _rootCity, Selected = true } };
                return _matrix[startVertex, _rootCity];
            }

            //root.ChildNodes = new Node[set.Count()];
            var totalCost = double.MaxValue;
            int i = 0, j = 0;
            foreach (var destination in set)
            {
                //root.ChildNodes[i] = new Node { Value = destination };

                var currentCost = _matrix[startVertex, destination] + GetMinCostRoute(destination, new List<int>(set.Where(o => o != destination)));// root.ChildNodes[i]);
                if (totalCost > currentCost)
                {
                    totalCost = currentCost;
                    j = i;
                }
                i++;
            }

            //root.ChildNodes[j].Selected = true;
            return totalCost;
        }

        private IEnumerable<int> TraverseTree(Node root, int startint)
        {
            var q = new Queue<int>(new[] { startint });
            TraverseTreeUtil(root, q);
            return q;
        }

        private void TraverseTreeUtil(Node root, Queue<int> vertices)
        {
            if (root.ChildNodes == null)
                return;

            foreach (var child in root.ChildNodes)
                if (child.Selected)
                {
                    vertices.Enqueue(child.Value);
                    TraverseTreeUtil(child, vertices);
                }
        }

        public TravellingSalesman(string file)
        {
            var sites = File.ReadAllLines(file).Skip(1).Select(line => Array.ConvertAll(line.Split(null), double.Parse)).ToArray();

            _cities = Enumerable.Range(0, sites.Length).ToArray();
            _matrix = new double[sites.Length, sites.Length];

            for (var i = 0; i < sites.Length; i++)
                for (var j = 0; j < sites.Length; j++)
                {
                    var x = (sites[i][0] - sites[j][0]);
                    var y = (sites[i][1] - sites[j][1]);
                    _matrix[i, j] = Math.Sqrt((x * x) + (y * y));
                }
        }
    }
}