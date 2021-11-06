namespace MakingAnagrams
{
    using System;
    using System.Linq;

    class Solution
    {
        public static void MainRun()
        {
            var s = Console.ReadLine()
                .GroupBy(i => i)
                .ToDictionary(i => i.Key, i => i.Count());

            foreach (var cg in Console.ReadLine().GroupBy(i => i))
            {
                s[cg.Key] = s.TryGetValue(cg.Key, out var c)
                    ? Math.Abs(c - cg.Count())
                    : cg.Count();
            }

            Console.WriteLine(s.Sum(i => i.Value));
        }
    }
}