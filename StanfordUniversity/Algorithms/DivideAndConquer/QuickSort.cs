namespace Algorithms.DivideAndConquer
{
    public enum Option { FIRST, FINAL, MEDIAN }

    public static class QuickSort {
        public static long Sort(ref int[] data, Option mode) {
            return Sort(ref data, 0, data.Length, mode);
        }

        public static long Sort(ref int[] data, int min, int lim, Option mode) {
            if (lim - min == 1)
                return 0;

            // Pivot
            int i, j, max = lim - 1,
                      mid = min + (max - min >> 1),
                      p = mode == Option.FIRST ? min
                        : mode == Option.FINAL ? max
                        : data[min] < data[mid]
                            ? data[mid] < data[max] ? mid : data[min] < data[max] ? max : min
                            : data[min] < data[max] ? min : data[mid] < data[max] ? max : mid;

            // Partition            
            Swap(ref data, min, p);
            for (i = j = min + 1; j < lim; j++)
                if (data[j] < data[min])
                    Swap(ref data, j, i++);
            Swap(ref data, min, i - 1);

            // Recursion
            long n = (lim - min - 1);
            if (i > min + 2) n += Sort(ref data, min, i - 1, mode);
            if (lim > i + 1) n += Sort(ref data, i, lim, mode);
            return n;
        }

        private static void Swap(ref int[] data, int a, int b) {
            if (a == b) return;
            var tmp = data[a];
            data[a] = data[b];
            data[b] = tmp;
        }
    }
}