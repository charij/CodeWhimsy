namespace BeautifulDaysAtTheMovies
{
    using System;

    class Solution
    {
        public static void MainRun()
        {
            var firstMultipleInput = Console.ReadLine().Split(' ');

            int i = int.Parse(firstMultipleInput[0]);
            int j = int.Parse(firstMultipleInput[1]);
            int k = int.Parse(firstMultipleInput[2]);
            int c = 0;

            for (; i <= j; i++)
            {
                if (Math.Abs(i - Reverse(i)) % k == 0)
                {
                    c++;
                }
            }

            Console.WriteLine(c);
        }

        private static int Reverse(int i)
        {
            var output = 0;
            do output = (10 * output) + (i % 10);
            while ((i /= 10) > 0);
            return output;
        }
    }
}