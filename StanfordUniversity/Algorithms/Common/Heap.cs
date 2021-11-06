using System;
using System.Collections.Generic;

namespace Algorithms.Common
{
    public class Heap<T> where T : IComparable
    {
        private readonly IList<T> data = new List<T>();
        private readonly int Mode;

        public Heap(int mode)
        {
            Mode = mode;
        }

        public int Count
        {
            get { return data.Count; }
        }

        public T Peek
        {
            get { return data[0]; }
        }

        public void Insert(T v)
        {
            int i = data.Count,
                j = ((i + 1) >> 1) - 1;

            data.Add(v);

            while (i > 0 && data[j].CompareTo(data[i]) == -Mode)
            {
                var tmp = data[i];
                data[i] = data[j];
                data[j] = tmp;

                i = j;
                j = ((i + 1) >> 1) - 1;
            }
        }

        public T Extract()
        {
            var root = data[0];
            data[0] = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            Heapify();
            return root;
        }

        private void Heapify(int i = 0)
        {
            int l = ((i + 1) << 1) - 1,
                r = ((i + 1) << 1),
                m = (l < data.Count && data[l].CompareTo(data[i]) == Mode) ? l : i;

            if (r < data.Count && data[r].CompareTo(data[m]) == Mode)
                m = r;

            if (m == i)
                return;

            var t = data[i];
            data[i] = data[m];
            data[m] = t;
            Heapify(m);
        }
    }
}
