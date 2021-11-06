using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms.Greedy
{
    public class Scheduling
    {
        private readonly List<decimal[]> Jobs = new List<decimal[]>();

        public Scheduling(string file)
        {
            foreach(var line in File.ReadAllLines(file).Skip(1))
                Jobs.Add(Array.ConvertAll(line.Split(null), decimal.Parse));
        }

        public decimal WeightSubLength()
        {
            decimal t = 0, n = 0;
            foreach (var i in Jobs.OrderByDescending(i => (i[0] - i[1])).ThenByDescending(i => i[0]))
            {
                n += i[1];
                t += n * i[0];                
            }
            return t;
        }

        public decimal WeightDivLength()
        {
            decimal t = 0, n = 0;
            foreach (var i in Jobs.OrderByDescending(i => (i[0] / i[1])))
            {
                n += i[1];
                t += n * i[0];
            }
            return t;
        }
    }
}