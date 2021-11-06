using System.Collections.Generic;

namespace Algorithms.Common
{
    public class LinkedList<T>
    {
        public LinkedList<T> Prev { get; set; }
        public T Value { get; set; }

        public IEnumerable<T> Compile()
        {
            var output = new List<T> { Value };
            var node = this;
            while ((node = node.Prev) != null)
                output.Add(node.Value);
            return output;
        }
    }
}
