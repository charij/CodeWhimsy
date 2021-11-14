namespace ClimbingTheLeaderboard
{
    using System;
    using System.Linq;

    class Solution
    {
        public static void MainRun()
        {
            Console.ReadLine();

            var ranked = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).Distinct().ToArray();
            var playerCount = int.Parse(Console.ReadLine());
            var player = Array.ConvertAll(Console.ReadLine().Split(' '), i => int.Parse(i));

            for (int i = 0, j = ranked.Length - 1; i < player.Length; i++)
            {
                while (j >= 0 && player[i] >= ranked[j]) j--;
                Console.WriteLine(j + 2);
            }
        }
    }
}