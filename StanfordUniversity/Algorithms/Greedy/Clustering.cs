using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms.Greedy
{
    public class UnionFind
    {
        public int Count { get; set; }

        public int[] Friends(int a)
        {
            var rootA = Find(a);
            var friends = new List<int>();

            for (var i = 0; i < Node.Length; i++)
                if (Find(Node[i]) != rootA)
                    friends.Add(i);

            return friends.ToArray();
        }

        public readonly int[] Node;
        public readonly int[] Root;
        public readonly int[] Rank;
        public readonly int[] Size;

        public UnionFind(params int[] nodes)
        {
            Rank = new int[nodes.Length];
            Size = new int[nodes.Length];
            Node = new int[nodes.Length];
            Root = Enumerable.Range(0, nodes.Length).ToArray();

            nodes.CopyTo(Node, 0);

            Count = nodes.Length;
        }

        public void Union(int a, int b)
        {
            var aRoot = Find(a);
            var bRoot = Find(b);

            if (aRoot == bRoot)
                return;

            if (Rank[aRoot] < Rank[bRoot])
            {
                var t = aRoot;
                aRoot = bRoot;
                bRoot = t;
            }

            Root[bRoot] = aRoot;
            Size[bRoot] = Size[aRoot] + Size[bRoot];

            if (Rank[aRoot] == Rank[bRoot])
                Rank[bRoot]++;

            Count -= 1;
        }

        public int Find(int a)
        {
            if (Root[a] != a)
                Root[a] = Find(Root[a]);
            return Root[a];
        }
    }

    public class MaxSpacing
    {
        private List<int[]> Edges = new List<int[]>();

        public MaxSpacing(string file)
        {
            var data = File.ReadAllLines(file);
            foreach (var line in data.Skip(1))
                Edges.Add(Array.ConvertAll(line.Split(null), int.Parse).ToArray());

            for (var i = 0; i < Edges.Count; i++)
            {
                Edges[i][0] -= 1;
                Edges[i][1] -= 1;
            }
        }

        public int Compute(int clusters)
        {
            var unionFind = new UnionFind(Edges.Select(i => i[0]).Concat(Edges.Select(i => i[1])).Distinct().OrderBy(i => i).ToArray());
            var nodeQueue = new Queue<int[]>(Edges.OrderBy(i => i[2]));
            
            while (nodeQueue.Count > 0)
            {
                var edge = nodeQueue.Dequeue();
                if (unionFind.Count > clusters)
                    unionFind.Union(edge[0], edge[1]);
                else
                if (unionFind.Find(edge[0]) != unionFind.Find(edge[1]))
                    return edge[2];
            }

            return -1;
        }
    }

    public class MaxClusters
    {
        private List<int> Edges = new List<int>();

        public MaxClusters(string file)
        {
            var data = File.ReadAllLines(file);
            foreach (var line in data.Skip(1))
                Edges.Add(Convert.ToInt32(line.Replace(" ",""), 2));
        }

        public int Compute(int maxDistance)
        {
            var nodes = new LinkedList<int>(Enumerable.Range(0, Edges.Count));
            var queue = new Queue<int>();
            var count = 0;

            while (nodes.Count > 0)
            {
                queue.Enqueue(nodes.First());
                nodes.RemoveFirst();
                while (queue.Count > 0)
                {
                    var a = queue.Dequeue();
                    foreach (var b in new List<int>(nodes))
                        if (HammingDistance(Edges[a], Edges[b]) < maxDistance)
                        {
                            queue.Enqueue(b);
                            nodes.Remove(b);
                        }
                }
                count++;
            } 

            return count;
        }

        private static int HammingDistance(int a, int b)
        {
            const int mask_1 = 0x55555555;
            const int mask_2 = 0x33333333;
            const int mask_3 = 0x0f0f0f0f;
            const int mask_4 = 0x0000003f;

            int i = a ^ b;

            i = (i - ((i >> 1) & mask_1));
            i = (i & mask_2) + ((i >> 2) & mask_2);
            i = (i + (i >> 4)) & mask_3;
            i = (i + (i >> 8));
            i = (i + (i >> 16));

            return i & mask_4;
        }
    }
}
