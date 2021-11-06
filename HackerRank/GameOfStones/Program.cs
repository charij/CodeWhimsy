namespace GameOfStones
{
    using System;

    class Solution
    {
        public static void MainRun()
        {
            int t = int.Parse(Console.ReadLine());
            for (int tItr = 0; tItr < t; tItr++)
            {
                var n = int.Parse(Console.ReadLine());
                Console.WriteLine(n % 7 > 1
                    ? "First"
                    : "Second"
                );
            }
        }
    }
}