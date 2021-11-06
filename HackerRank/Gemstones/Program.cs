namespace Gemstones
{
    using System;
    using System.Linq;

    class Solution
    {
        public static void MainRun()
        {
            var n = int.Parse(Console.ReadLine());
            var s = Console.ReadLine().ToHashSet();

            for (int i = 1; i < n; i++)
            {
                s.IntersectWith(Console.ReadLine());
            }

            Console.WriteLine(s.Count);
        }
    }
}