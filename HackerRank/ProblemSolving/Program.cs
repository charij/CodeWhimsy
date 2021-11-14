namespace ProblemSolving
{
    using System.Collections.Generic;
    using System.Linq;

    class Program
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
    }
}