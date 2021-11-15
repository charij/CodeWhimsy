namespace StringFunctionCalculation
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Node
    {
        public string Value { get; set; }
        public int Count { get; set; } = 1;
        public int Length { get; set; }
        public List<int> Children { get; } = new List<int>();

        public Node(params int[] children)
        {
            Children.AddRange(children);
        }

        private static readonly List<Node> nodes = new List<Node> { new Node() };

        private static void AddSuffix(string suf)
        {
            for (int n = 0, i = 0, j, x2, n2; i < suf.Length; i += j, n = n2)
            {
                char b = suf[i];
                for (x2 = 0; ; x2++)
                {
                    var children = nodes[n].Children;
                    if (x2 == children.Count)
                    {
                        n2 = nodes.Count;
                        nodes.Add(new Node { Value = suf.Substring(i) });
                        nodes[n].Children.Add(n2);
                        return;
                    }

                    n2 = children[x2];
                    if (nodes[n2].Value[0] == b)
                    {
                        break;
                    }
                }

                var sub2 = nodes[n2].Value;
                for (j = 0;  j < sub2.Length; j++)
                {
                    if (suf[i + j] != sub2[j])
                    {
                        var n3 = n2;
                        n2 = nodes.Count;
                        nodes.Add(new Node(n3) { Value = sub2.Substring(0, j) });
                        nodes[n3].Value = sub2.Substring(j);
                        nodes[n].Children[x2] = n2;
                        break;
                    }
                }
            }
        }

        public static void MainRun()
        {
            var str = Console.ReadLine() + "$";
            for (int i = 0; i < str.Length; i++)
            {
                AddSuffix(str.Substring(i));
            }

            // todo: AddSuffix method needs to increment the count and set length
            Console.WriteLine(nodes.GroupBy(i => i.Value).Max(i => i.Sum(j => j.Count) * i.Key.Length));
        }
    }
}