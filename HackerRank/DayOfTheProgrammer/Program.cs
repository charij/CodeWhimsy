namespace DayOfTheProgrammer
{
    using System;

    class Solution
    {
        public static void MainRun()
        {
            var year = int.Parse(Console.ReadLine());
            if (year == 1918)
            {
                Console.WriteLine("26.09.1918");
            }
            else
            {
                Console.WriteLine(year % 4 == 0 && (year < 1918 || !(year % 100 == 0 && year % 400 > 0))
                    ? $"12.09.{year}"
                    : $"13.09.{year}");
            }
        }
    }
}