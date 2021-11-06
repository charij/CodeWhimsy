namespace SeperateTheNumbers
{
    using System;

    class Solution
    {
        private static string Seperate(string s)
        {
            for (int i = 1; i <= s.Length / 2; i++)
            {
                var t = s.Substring(0, i);
                var j = long.Parse(t);
                if (j == 0)
                {
                    return "NO";
                }

                while (t.Length < s.Length && s.StartsWith(t))
                {
                    t += (j += 1).ToString();
                }

                if (s == t)
                {
                    return $"YES {t.Substring(0, i)}";
                }
            }

            return "NO";
        }

        public static void MainRun()
        {
            var q = int.Parse(Console.ReadLine());
            for (int l = 0; l < q; l++)
            {
                Console.WriteLine(Seperate(Console.ReadLine()));
            }
        }
    }
}