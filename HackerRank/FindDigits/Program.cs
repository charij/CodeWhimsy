using System;
using System.Linq;

class Solution
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int tItr = 0; tItr < t; tItr++)
        {
            var s = Console.ReadLine();
            var n = int.Parse(s);

            Console.WriteLine(s.Count(i => i != 48 && n % (i - 48) == 0));
        }
    }
}