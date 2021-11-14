namespace PickingNumbers
{
    using System;
    using System.Linq;

    class Solution
    {
        public static void MainRun()
        {
            Console.ReadLine();
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), i => int.Parse(i));
            var r = a.GroupBy(i => i).ToDictionary(i => i.Key, i => i.Count());
            Console.WriteLine(r.Select(i => i.Value + (r.ContainsKey(i.Key + 1) ? r[i.Key + 1] : 0)).Max());
        }
    }
}