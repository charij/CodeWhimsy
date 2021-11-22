namespace MissingNumbers
{
    using System;
    using System.Linq;

    class Solution
    {
        public static void MainRun()
        {
            Console.ReadLine();
            var a = Console.ReadLine().Split(' ');

            Console.ReadLine();
            var b = Console.ReadLine().Split(' ')
                .GroupBy(i => i)
                .ToDictionary(i => i.Key, i => i.Count());

            foreach (var i in a)
                if (b.ContainsKey(i)) b[i]--;

            Console.WriteLine(String.Join(" ", b.Where(i => i.Value > 0).Select(i => i.Key).OrderBy(i => int.Parse(i))));
        }
    }
}