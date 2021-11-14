namespace PokerNim
{
    using System;

    class Solution
    {
        public static void MainRun()
        {
            int t = int.Parse(Console.ReadLine());
            for (int tItr = 0; tItr < t; tItr++)
            {
                var firstMultipleInput = Console.ReadLine().Split(' ');
                var n = int.Parse(firstMultipleInput[0]);
                var k = int.Parse(firstMultipleInput[1]);
                var c = Array.ConvertAll(Console.ReadLine().Split(' '), i => int.Parse(i));

                Console.WriteLine("");
            }
        }
    }
}