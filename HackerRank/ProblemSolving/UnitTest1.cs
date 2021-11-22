namespace ProblemSolving
{
    using NUnit.Framework;
    using System.Linq;

    public class Tests
    {

        [Test]
        [TestCase(65, 4, 3, 2, 1)]
        [TestCase(80, 9, 5, 8)]
        [TestCase(364271696, 747402, 380408, 605449, 846906, 385224, 31431, 677517, 770001, 389085, 40373, 487560, 886252, 596334, 59083)]
        public void SortedSumTests(int expected, params int[] a)
        {            
            Assert.AreEqual(expected, Solution.SortedSum(a.ToList()));
        }
    }
}