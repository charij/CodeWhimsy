namespace CaesarCipher
{
    using System;
    using System.Linq;

    class Solution
    {
        public static void MainRun()
        {
            Console.ReadLine();

            var s = Console.ReadLine();
            var k = int.Parse(Console.ReadLine()) % 26;
            var r = s.Select(i => char.IsLetter(i)
                ? char.IsUpper(i)
                    ? (char)('A' + ((i + k) % 'A' % 26))
                    : (char)('a' + ((i + k) % 'a' % 26))
                : i);

            Console.WriteLine(string.Concat(r));
        }
    }
}