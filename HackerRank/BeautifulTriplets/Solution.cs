namespace BeautifulTriplets
{
    using System;
    using System.Linq;

    class Solution
    {
        public static void MainRun()
        {
            var d = int.Parse(Console.ReadLine().Split(' ')[1]);
            var a = Console.ReadLine().Split(' ').Select(i => int.Parse(i))
                .GroupBy(i => i)
                .ToDictionary(i => i.Key, i => i.Count());

            var r = a.Keys.Sum(i => (a.ContainsKey(i - d) ? a[i - d] : 0)
                                  * (a.ContainsKey(i + d) ? a[i + d] : 0));

            Console.WriteLine(r);
        }
    }
}