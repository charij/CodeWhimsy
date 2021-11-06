using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms {
    public class Program {
        static void Main(string[] args)
        {
            Course1();
            Course2();
            Course3();
            Course4();
        }

        public static void Course1() {
            {   // Week 1
                var a = new DivideAndConquer.Karatsuba("3141592653589793238462643383279502884197169399375105820974944592");
                var b = new DivideAndConquer.Karatsuba("2718281828459045235360287471352662497757247093699959574966967627");
                var ab = String.Join("", (a * b));                
                // 8539734222673567065463550869546574495034888535765114961879601127067743044893204848617875072216249073013374895871952806582723184
            }
            {   // Week 2
                var data = Array.ConvertAll(File.ReadAllLines(@"..\..\IntegerArray.txt"), int.Parse);
                var inversions = DivideAndConquer.Inversion.Count(data);
                // 2407905288
            }
            {   // Week 3 
                var data = Array.ConvertAll(File.ReadAllLines(@"..\..\QuickSort.txt"), int.Parse);
                var d1 = (int[])data.Clone();
                var d2 = (int[])data.Clone();
                var d3 = (int[])data.Clone();
                var firstCMP  = DivideAndConquer.QuickSort.Sort(ref d1, DivideAndConquer.Option.FIRST);
                var finalCMP  = DivideAndConquer.QuickSort.Sort(ref d2, DivideAndConquer.Option.FINAL);
                var medianCMP = DivideAndConquer.QuickSort.Sort(ref d3, DivideAndConquer.Option.MEDIAN);
                // 162085
                // 164123
                // 138382
            }
            {   // Week 4
                var data = File.ReadAllLines(@"..\..\kargerMinCut.txt").Select(n => new List<int>(Array.ConvertAll(n.Split(new char[0], StringSplitOptions.RemoveEmptyEntries), int.Parse))).ToList();
                var result = DivideAndConquer.Krager.Compute(ref data);
                // 17
            }
        }

        public static void Course2() {
            { // Week 1 
                var scc = String.Join(",", new GraphSearch.Graph(@"..\..\SCC.txt").ComputeSCCs(5));
              //    434821,968,459,313,211
            }
            { // Week 2
                var ans = String.Join(",", new GraphSearch.Dijkstra(@"..\..\dijkstraData.txt").Compute(1, 7, 37, 59, 82, 99, 115, 133, 165, 188, 197));
              //    2599,2610,2947,2052,2367,2399,2029,2442,2505,3068
            }
            { // Week 3
                var ans = GraphSearch.MedianMaintenance.Compute(@"..\..\Median.txt");
              //    1213
            }
            { // Week 4
                var ans = new GraphSearch.TwoSum(@"..\..\algo1-programming_prob-2sum.txt").Compute2(-10000, 10000);
              //    427
            }
        }

        public static void Course3() {
            { // Week 1
                var scheduler = new Greedy.Scheduling(@"..\..\jobs.txt");
                var minSpanningTree = new Greedy.MinSpanningTree(@"..\..\edges.txt");

                var ans1 = scheduler.WeightSubLength();
                var ans2 = scheduler.WeightDivLength();
                var ans3 = minSpanningTree.PrimsAlgorithm();

                // 69119377652
                // 67311454237
                // -3612829
            }
            { // Week 2
                var ans1 = new Greedy.MaxSpacing(@"..\..\clustering1.txt").Compute(4);
                var ans2 = new Greedy.MaxClusters(@"..\..\clustering_big.txt").Compute(3);

                // 106
                // 6118
            }
            { // Week 3
                var tree = new Greedy.Huffman(@"..\..\huffman.txt");
                var ans1 = tree.MaxCodeLength();
                var ans2 = tree.MinCodeLength();

                var path = new Greedy.PathGraph(@"..\..\mwis.txt");
                var ans3 = String.Concat(path.MaxWeightSet(1, 2, 3, 4, 17, 117, 517, 997));

                // 19
                // 9
                // 10100110
            }
            { // Week 4
                var ans1 = new Greedy.Knapsack(@"..\..\knapsack1.txt").OptimalValue();
                var ans2 = new Greedy.Knapsack(@"..\..\knapsack_big.txt").OptimalValue();

                // 2493893
                // 4243395
            }
        }

        public static void Course4() {
            { // Week 1
                var ans = new []
                {
                    NpComplete.ShortestPath.Load(@"..\..\g1.txt").ShortestPath(),
                    NpComplete.ShortestPath.Load(@"..\..\g2.txt").ShortestPath(),
                    NpComplete.ShortestPath.Load(@"..\..\g3.txt").ShortestPath()
                }.Min(i => i);
                // -19
            }
            { // Week 2
                var ans = new NpComplete.TravellingSalesman(@"..\..\tsp.txt").Compute();
                // 26442
            }
            { // Week 3
                var ans = new NpComplete.GreedyTSP(@"..\..\..\nn.txt").Compute();//input_simple_29_100.txtinput_simple_10_8.txt
                // 1203406
            }
            { // Week 4                
                var ans = String.Join("", new[] 
                {
                    NpComplete.TwoSat.FastCompute(@"..\..\..\2sat1.txt"),
                    NpComplete.TwoSat.FastCompute(@"..\..\..\2sat2.txt"),
                    NpComplete.TwoSat.FastCompute(@"..\..\..\2sat3.txt"),
                    NpComplete.TwoSat.FastCompute(@"..\..\..\2sat4.txt"),
                    NpComplete.TwoSat.FastCompute(@"..\..\..\2sat5.txt"),
                    NpComplete.TwoSat.FastCompute(@"..\..\..\2sat6.txt")
                }.Select(i => i ? "1" : "0"));
                // 101100
            }
        }
    }
}