using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.DivideAndConquer {
    public static class Krager {

        public static Random Rand { get; set; }

        public static int Compute(ref List<List<int>> data) {
            data.ForEach(n => n.RemoveAt(0));

            for (var i = 0; i < data.Count; i++)
                for (var j = 0; j < data[i].Count; j++)
                    data[i][j] -= 1;

            Rand = new Random(DateTime.Now.Millisecond);

            int loop = 1;
            var min = int.MaxValue;
            while (loop++ > 0) {
                var matrix = new List<List<int>>();
                for (var j = 0; j < data.Count; j++)
                    matrix.Add(new List<int>(data[j]));
                min = Math.Min(min, Count(matrix));
                Console.WriteLine(loop + "\t\t : " + min);
            }
            return min;
        }

        public static int Count(List<List<int>> data) {
            while (data.Count(n => n.Count > 0) > 2) {
                var r = Rand.Next(0, data.Sum(n => n.Count) - 1);
                var target = data.SelectMany(n => n).ToArray()[r];
                var origin = data.FindIndex(n => { if (r <= n.Count) return true; r -= n.Count; return false; });

                data[origin].AddRange(data[target]);
                data[target].Clear();
                
                for (var i = 0; i < data.Count; i++)
                    for (var j = 0; j < data[i].Count; j++)
                        if (data[i][j] == target)
                            data[i][j] = origin;

                data[origin].RemoveAll(n => n == origin);
            }
            return data.Sum(n => n.Count);
        }
    }
}