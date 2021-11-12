namespace ConstructingANumber
{
    using System;
    using System.Linq;

    class Solution
    {
        public static void MainRun()
        {
            int t = int.Parse(Console.ReadLine());
            for (int tItr = 0; tItr < t; tItr++)
            {
                var n = int.Parse(Console.ReadLine());
                var s = Console.ReadLine().Sum(i => char.IsDigit(i) ? i - '0' : 0);

                Console.WriteLine(s % 3 == 0
                    ? "Yes"
                    : "No");
            }
        }
    }
}