namespace WeightedUniformStrings
{
    using System;
    using System.Collections.Generic;

    class Solution
    {
        public static void MainRun()
        {
            var values = Array.ConvertAll(Console.ReadLine().ToCharArray(), i => i - 96);
            var queriesCount = int.Parse(Console.ReadLine());
            var queries = new HashSet<int>();

            for (int i = 0, s = 0, p = 0; i < values.Length; i++)
            {
                s = values[i] == p ? s + values[i] : p = values[i];
                queries.Add(s);
            }

            for (int i = 0; i < queriesCount; i++)
            {
                int v = int.Parse(Console.ReadLine());
                Console.WriteLine(queries.Contains(v) ? "Yes" : "No");
            }
        }
    }
}