using System;
using System.IO;
using System.Linq;
using Algorithms.GraphSearch;

namespace Algorithms.Greedy
{
    public class Node : IComparable
    {
        public Node A { get; set; }
        public Node B { get; set; }
        public long Weight { get; set; }

        public Node(long weight)
            : this (null, null, weight)
        { }

        public Node (Node a, Node b)
            : this(a, b, a.Weight + b.Weight)
        { }

        private Node(Node a, Node b, long weight)
        {
            A = a;
            B = b;
            Weight = weight;
        }

        public int CompareTo(object obj)
        {
            return Weight.CompareTo((obj as Node).Weight);
        }
    }

    public class Huffman
    {
        private readonly Node _codeTree;

        public Huffman(string file)
        {
            var nodes = new Heap<Node>(-1);
            foreach (var node in File.ReadAllLines(file).Skip(1))
                nodes.Insert(new Node(long.Parse(node)));            

            while (nodes.Count > 2)
                nodes.Insert(new Node(nodes.Extract(), nodes.Extract()));
            _codeTree = new Node(nodes.Extract(), nodes.Extract());
        }

        public int MaxCodeLength(Node node = null, int depth = 0)
        {
            if (node == null)
                node = _codeTree;
            if (node.A == node.B)
                return depth;

            return Math.Max( MaxCodeLength(node.A, depth + 1)
                           , MaxCodeLength(node.B, depth + 1));
        }

        public int MinCodeLength(Node node = null, int depth = 0)
        {
            if (node == null)
                node = _codeTree;
            if (node.A == node.B)
                return depth;

            return Math.Min( MinCodeLength(node.A, depth + 1)
                           , MinCodeLength(node.B, depth + 1));
        }
    }
}