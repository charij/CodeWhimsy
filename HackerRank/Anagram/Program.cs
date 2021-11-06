namespace Anagram
{
    using System.Linq;
    using System;

    class Solution
    {
        public static void MainRun()
        {
            for (int l = int.Parse(Console.ReadLine()) - 1; l >= 0; l--)
            {
                var s = Console.ReadLine();
                if (s.Length % 2 == 1)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    var s1 = s.Take(s.Length / 2).ToLookup(i => i);
                    var s2 = s.Skip(s.Length / 2).Take(s.Length / 2);

                    Console.WriteLine(s2
                        .GroupBy(i => i)
                        .Sum(i => Math.Max(0, i.Count() - s1[i.Key].Count())));
                }
            }
        }
    }
}