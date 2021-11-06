namespace SherlockAndAnagrams
{
    using System;
    using System.Collections.Generic;

    class Solution
    {
        private static bool IsAnagram(string s1, string s2)
        {
            if (s1 == s2) return true;
            var pool = new Dictionary<char, int>(s1.Length);
            foreach (var c in s1)
            {
                if (pool.ContainsKey(c))
                    pool[c]++;
                else
                    pool.Add(c, 1);
            }
            foreach (var c in s2)
            {
                if (!pool.ContainsKey(c))
                    return false;
                if (--pool[c] == 0)
                    pool.Remove(c);
            }
            return pool.Count == 0;
        }

        public static void MainRun()
        {
            int q = int.Parse(Console.ReadLine());
            for (int qItr = 0; qItr < q; qItr++)
            {
                var s = Console.ReadLine();
                var r = new HashSet<string>();

                for (int i = 0; i < s.Length - 1; i++)
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] != s[j]) continue;
                    for (var k = j - i; k > 0; k--)
                    { 
                        for (var l = 1 - k; l < 1; l++)
                        for (var m = 1 - k; m < 1; m++)
                        {
                            if (i + l >= 0 && i + l + k <= s.Length)
                            if (j + m >= 0 && j + m + k <= s.Length)
                            if (IsAnagram(s.Substring(i + l, k), s.Substring(j + m, k)))
                            {
                                r.Add($"[{i + l},{k}],[{j + m},{k}]");
                            }
                        }
                        // maybe build up sub strings and do comparisons after to speed up?
                    }
                }

                Console.WriteLine(r.Count);
            }
        }
    }
}