using System;

class Solution
{
    public static void Main()
    {
        var time = DateTime.ParseExact("07:05:45PM", "hh:mm:sstt", System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine(time.ToString("HH:mm:ss"));
    }
}