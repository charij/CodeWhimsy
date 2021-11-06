namespace NimbleGame
{
    using System;

    class Solution
    {
        public static void MainRun()
        {
            var t = int.Parse(Console.ReadLine());
            for (var tItr = 0; tItr < t; tItr++)
            {
                Console.ReadLine();

                var s = Array.ConvertAll(Console.ReadLine().Split(' '), i => int.Parse(i));
                var r = 0;

                for (var i = 0; i < s.Length; i++)
                {
                    r ^= s[i] % 2 == 0 ? 0 : i;
                }

                Console.WriteLine(r > 0
                    ? "First"
                    : "Second");
            }
        }
    }
}