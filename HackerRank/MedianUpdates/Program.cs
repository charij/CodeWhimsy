namespace MedianUpdates
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MedianTracker
    {
        private readonly LinkedList<decimal> values = new LinkedList<decimal>();
        private readonly Dictionary<decimal, LinkedListNode<decimal>> headNodeLookup = new Dictionary<decimal, LinkedListNode<decimal>>();
        private LinkedListNode<decimal> middleNode, headNode, newNode;

        public string Median => middleNode == null
            ? "Wrong!"
            : (values.Count % 2 > 0 ? middleNode.Value : (middleNode.Value + middleNode.Next.Value) / 2).ToString();

        public void Add(decimal value)
        {
            newNode = new LinkedListNode<decimal>(value);
            if (values.Count == 0)
            {
                values.AddFirst(headNodeLookup[value] = middleNode = newNode);
            }
            else 
            {
                if (headNodeLookup.TryGetValue(value, out headNode))
                {
                    values.AddBefore(headNode, newNode);
                    headNodeLookup[value] = newNode;
                }
                else
                {
                    if (value >= middleNode.Value)
                    { 
                        for (headNode = values.Last; headNode != middleNode && headNode.Value > value; headNode = headNode.Previous);                    
                    }
                    else
                    {
                        for (headNode = values.First; headNode.Next != middleNode && headNode.Value < value; headNode = headNode.Next) ;
                    }

                    if (value < headNode.Value)
                    {
                        values.AddBefore(headNode, headNodeLookup[value] = newNode);
                    }
                    else
                    {
                        values.AddAfter(headNode, headNodeLookup[value] = newNode);
                    }
                }
                if (values.Count % 2 == 0)
                {
                    if (value <= middleNode.Value)
                    {
                        middleNode = middleNode.Previous;
                    }
                }
                else
                {
                    if (value > middleNode.Value)
                    {
                        middleNode = middleNode.Next;
                    }
                }
            }
        }

        public bool Remove(decimal value)
        {
            if (!headNodeLookup.TryGetValue(value, out headNode))
            {
                return false;
            }

            if (values.Count == 1)
            {
                middleNode = null;
            }
            else
            if (values.Count % 2 == 0)
            {
                if (value <= middleNode.Value)
                {
                    middleNode = middleNode.Next;
                }
            }
            else
            {
                if (value > middleNode.Value || headNode == middleNode)
                {
                    middleNode = middleNode.Previous;
                }
            }
            if (headNode.Next != null && headNode.Next.Value == value)
            {
                headNodeLookup[value] = headNode.Next;
            }
            else
            {
                headNodeLookup.Remove(value);
            }

            values.Remove(headNode);
            return true;
        }
    }

    public class Solution
    {
        public static void Run()
        {
            var output = new StringBuilder();
            var values = new MedianTracker();
            var n = int.Parse(Console.ReadLine());
            string line;

            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine();
                if (line[0] == 'r')
                {
                    if (!values.Remove(decimal.Parse(line.Substring(2))))
                    {
                        output.AppendLine("Wrong!");
                        continue;
                    }
                }
                else
                {
                    values.Add(decimal.Parse(line.Substring(2)));
                }

                output.AppendLine(values.Median);
            }

            Console.Write(output);
        }
    }
}