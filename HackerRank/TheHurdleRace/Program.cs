namespace TheHurdleRace
{
    using System;
    using System.Linq;

    class Solution
    {
        public static void MainRun()
        {
            var k = int.Parse(Console.ReadLine().Split(' ')[1]);
            var h = Array.ConvertAll(Console.ReadLine().Split(' '), i => int.Parse(i));

            Console.WriteLine(Math.Max(0, h.Max() - k));
        }
    }
}