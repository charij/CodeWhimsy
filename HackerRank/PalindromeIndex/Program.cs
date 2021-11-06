namespace PalindromeIndex
{
    using System;

    class Solution
    {
        public static bool IsPalindrome(string s, int i, int j)
        {
            while (i < j) if (s[i++] != s[j--]) return false;
            return true;
        }

        public static void MainRun()
        {
            for (var l = int.Parse(Console.ReadLine()) - 1; l >= 0; l--)
            {
                var s = Console.ReadLine();
                if (IsPalindrome(s, 0, s.Length - 1))
                {
                    Console.WriteLine(-1);
                }
                else
                for (var i = 0; i < s.Length / 2; i++)
                {
                    if (IsPalindrome(s, i + 1, s.Length - 1 - i))
                    {
                        Console.WriteLine(i);
                        break;
                    }
                    else
                    if (IsPalindrome(s, i, s.Length - 2 - i))
                    {
                        Console.WriteLine(s.Length - 1 - i);
                        break;
                    }
                }
            }
        }
    }
}