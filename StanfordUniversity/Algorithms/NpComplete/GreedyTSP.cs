using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms.NpComplete
{
    public class GreedyTSP
    {
        private readonly int[] _cities;
        private readonly double[][] _sites;

        public GreedyTSP(string file)
        {
            _sites = File.ReadAllLines(file).Skip(1).Select(line => Array.ConvertAll(line.Split(null), double.Parse)).ToArray();
            _cities = Enumerable.Range(0, _sites.Length).ToArray();

            for (var i = 0; i < _sites.Length; i++)
                _sites[i][0] -= 1;
        }

        public double Compute()
        {
            var distance = 0.0;
            var tour = new List<int> { _cities.First() };
            var unvisited = new HashSet<int>(_cities.Skip(1));
            while (tour.Count < _cities.Length)
            {
                var nCity = unvisited.First();
                var nDist = double.MaxValue;
                foreach (var city in unvisited)
                {
                    var dist = Distance(tour.Last(), city);
                    if (nDist > dist)
                    {
                        nDist = dist;
                        nCity = city;
                    }
                }
                distance += Math.Sqrt(nDist);
                tour.Add(nCity);
                unvisited.Remove(nCity);
            }
            return distance + Math.Sqrt(Distance(tour.First(), tour.Last()));
        }

        private double Distance(int a, int b)
        {
            var x = _sites[a][1] - _sites[b][1];
            var y = _sites[a][2] - _sites[b][2];
            return (x * x) + (y * y);
        }
    }
}