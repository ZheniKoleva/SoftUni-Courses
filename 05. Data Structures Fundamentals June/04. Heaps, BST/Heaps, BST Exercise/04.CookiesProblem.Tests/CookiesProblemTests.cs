using NUnit.Framework;
using _04.CookiesProblem;

namespace _04.CookiesProblem.Tests
{
    public class CookiesProblemTests
    {
        [Test]
        public void TestSolveHasSolution()
        {
            int result = new CookiesProblem().Solve(7, new int[] { 1, 2, 3, 9, 10, 12 });
            Assert.AreEqual(2, result);
        }

        [Test]
        public void TestSolveHasNoSolution()
        {
            int result = new CookiesProblem().Solve(10, new int[] { 1, 1, 1, 1 });
            Assert.AreEqual(-1, result);
        }
    }
}