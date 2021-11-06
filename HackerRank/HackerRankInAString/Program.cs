namespace HackerRankInAString
{
    using System;

    class Solution
    {
        public static void MainRun()
        {
            const string target = "hackerrank";
            for (int i = int.Parse(Console.ReadLine()) - 1; i >= 0; i--)
            {
                var j = 0;
                foreach (var c in Console.ReadLine())
                {
                    if (c == target[j] && ++j == target.Length)
                    {
                        break;
                    }
                }

                Console.WriteLine(j == target.Length ? "YES" : "NO");
            }
        }
    }
}