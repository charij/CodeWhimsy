namespace BirthdayCakeCandles
{
    using System;
    using System.Linq;

    class Solution
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();

            var result = Console.ReadLine()
                .Split(' ')
                .Select(candlesTemp => int.Parse(candlesTemp))
                .GroupBy(i => i)
                .Max(i => i.Count());

            Console.WriteLine(result);
        }
    }
}