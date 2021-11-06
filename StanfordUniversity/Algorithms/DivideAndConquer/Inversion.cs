using System.Collections.Generic;

namespace Algorithms.DivideAndConquer {
    public static class Inversion {
        public static long Count(params int[] data) {
            return Count(new List<int>(data));
        }

        public static long Count(List<int> data) {
            if (data == null || data.Count <= 1)
                return 0;

            // Divide - split and iterate
            var n = data.Count >> 1;
            var a = data.GetRange(0, n);
            var b = data.GetRange(n, data.Count - n);
            var r = Count(a) + Count(b);
            
            // Conquer - sort and merge
            int  i = 0, j = 0, k = 0;
            while (j < a.Count && k < b.Count)
                if (a[j] < b[k])
                    data[i++] = a[j++];
                else {
                    data[i++] = b[k++];
                    r += a.Count - j;
                }
            if (j < a.Count)
                while (i < data.Count)
                    data[i++] = a[j++];
            else
                while (i < data.Count)
                    data[i++] = b[k++];

            return r;
        }
    }
}