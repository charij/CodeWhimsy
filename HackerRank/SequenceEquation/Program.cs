namespace SequenceEquation
{
    using System;

    class Solution
    {
        public static void MainRun()
        {
            var n = int.Parse(Console.ReadLine());
            var p = Array.ConvertAll(Console.ReadLine().Split(' '), i => int.Parse(i));
            for (var i = 1; i <= n; i++)
            {
                Console.WriteLine(Array.IndexOf(p, Array.IndexOf(p, i) + 1) + 1);
            }
        }
    }
}