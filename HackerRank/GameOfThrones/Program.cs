namespace GameOfThrones
{
    using System;
    using System.Linq;

    class Solution
    {
        public static void MainRun()
        {
            var s = Console.ReadLine();
            var r = s.GroupBy(i => i).Count(i => i.Count() % 2 > 0);

            Console.WriteLine(r == 1 || (r == 0 && s.Length % 2 == 0)
                ? "YES"
                : "NO");
        }
    }
}