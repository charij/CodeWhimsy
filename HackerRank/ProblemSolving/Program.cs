namespace ProblemSolving
{
    using System.Collections.Generic;
    using System.Linq;

    class Solution
    {
        public static string DecryptPassword(string s)
        {
            var stack = new Stack<char>();
            for (int i = s.Length - 1, j = 0; i >= j; i--)
            {
                if (s[i] == '0')
                {
                    stack.Push(s[j++]);
                }
                else
                if (s[i] == '*')
                {
                    stack.Push(s[i - 2]);
                    stack.Push(s[i - 1]);
                    i -= 2;
                }
                else
                {
                    stack.Push(s[i]);
                }
            }
            return string.Join(string.Empty, stack);
        }

        public static List<int> StringAnagram(List<string> dictionary, List<string> query)
        {
            var lookUp = dictionary
                .GroupBy(i => string.Join(string.Empty, i.OrderBy(i => i)))
                .ToDictionary(i => i.Key, i => i.Count());

            return query
                .Select(i => string.Join(string.Empty, i.OrderBy(i => i)))
                .Select(i => lookUp.ContainsKey(i) ? lookUp[i] : 0)
                .ToList();
        }

        public static int numberOfWays(List<List<int>> roads)
        {
            var cities = roads.Count + 1;
            var distances = new int[cities * (cities - 1) / 2];

            for (var i = 0; i < roads.Count; i++)
            {
                distances[roads[i][0] * cities + roads[i][1]] = 1;
            }


            for (var i = 0; i < cities - 1; i++)
            for (var j = i + 1; j < cities; j++)
            {
                distances[(i * cities), j] = 1;
            }

            return distances
                .GroupBy(i => i)
                .Sum(i => i.Count() > 2 ? Factorial(i.Count()) / (6 * Factorial(i.Count() - 3)) : 0);
        }

        private int Factorial(int x)
        {
            return x > 1 ? x * Factorial(x - 1) : 1;
        }

        public static int SortedSum(List<int> a)
        {
            var c = 0;
            for (var i = 1; i <= a.Count; i++)
            {
                var s = a.Take(i).OrderBy(i => i).ToArray();
                for (var j = 0; j < i; j++)
                {
                    c += s[j] * (j + 1);
                    c %= 1000000007;
                }
            }
            return c;
        }
    }
}