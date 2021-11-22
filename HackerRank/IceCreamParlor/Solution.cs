namespace IceCreamParlor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Solution
    {
        public static void MainRun()
        {
            int t = int.Parse(Console.ReadLine());
            for (int tItr = 0; tItr < t; tItr++)
            {
                int m = int.Parse(Console.ReadLine());
                int n = int.Parse(Console.ReadLine());
                var a = Console.ReadLine().Split(' ').Select((i, index) => new { index, value = int.Parse(i) }).ToArray();

                if (m % 2 == 0 && Array.FindAll(a, i => i == m / 2).Length > 1)
                { 
                    Console.WriteLine($"{m / 2} {m / 2}");
                }
                else 
                {
                    for (int i = 0; a[i] < a.Length; i++)
                    {
                        if (d.Contains(m - a[i]))
                        {
                            Console.WriteLine($"{i + 1} {m - a[i]}");
                            break;
                        }
                    }                    
                }
            }
        }
    }
}