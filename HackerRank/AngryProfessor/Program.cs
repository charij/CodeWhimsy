namespace AngryProfessor
{
    using System;
    using System.Linq;

    class Solution
    {
        public static void MainRun()
        {
            var t = int.Parse(Console.ReadLine());
            for (var tItr = 0; tItr < t; tItr++)
            {
                var k = int.Parse(Console.ReadLine().Split(' ')[1]);
                var a = Array.ConvertAll(Console.ReadLine().Split(' '), i => int.Parse(i));

                Console.WriteLine(a.Count(i => i <= 0) < k
                    ? "YES"
                    : "NO");
            }
        }
    }
}