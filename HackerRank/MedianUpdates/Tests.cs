namespace MedianUpdates
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using NUnit.Framework;

    public class Tests
    {
        private static IEnumerable<TestCaseData> TestDataLoader()
        {
            var inputFiles = Directory.GetFiles(@"..\..\..\Data\", "input*.txt", SearchOption.TopDirectoryOnly);
            foreach (var inputFile in inputFiles)
            {
                var outputFile = Regex.Replace(inputFile, @"input(?=.*\.txt)", "output");
                if (File.Exists(outputFile))
                {
                    yield return new TestCaseData(inputFile, outputFile);
                }
            }
        }

        [Test, TestCaseSource(nameof(TestDataLoader))]
        public void RunTests(string inputFile, string outputFile)
        {
            var expectedLines = File.ReadAllLines(outputFile);
            var stringWriter = new StringWriter();

            Console.SetIn(File.OpenText(inputFile));
            Console.SetOut(stringWriter);

            Solution.Run();

            var outputLines = stringWriter.ToString().Trim().Split(Environment.NewLine);
            for (var i = 0; i < outputLines.Length; i++)
            { 
                Assert.AreEqual(outputLines[i], expectedLines[i], $"line {i}: {outputLines[i]} != {expectedLines[i]}");
            }
        }
    }
}