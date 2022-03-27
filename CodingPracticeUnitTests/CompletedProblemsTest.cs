using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CodingPracticeService;

namespace CodingPracticeUnitTests
{
    public class CompletedProblemsTest
    {
        // Template
        [Theory]
        [InlineData()]
        public void ProblemTemplate()
        {
            var expected = "";
            var cp = new CompletedProblems();
            var actual = ""; //cp.ProblemTemplate();
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 5)]
        [InlineData(5, 8)]
        public void P70ClimbStairs(int x, int expected)
        {
            var cp = new CompletedProblems();
            var actual = cp.P70ClimbStairs(x);
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("11", "1", "100")]
        [InlineData("1010", "1011", "10101")]
        [InlineData("111", "111", "1110")]
        public void P67AddBinary(string a, string b, string expected)
        {
            var cp = new CompletedProblems();
            var actual = cp.P67AddBinary(a, b);
            Assert.Equal(actual,
                expected);
        }

        [Theory]
        [InlineData(new int[] { 1, 9, 9 }, new int[] { 9, 9, 9 })]
        public void LC66PlusOne(int[] digitsA, int[] digitsB)
        {
            var digits2 = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            var cp = new CompletedProblems();
            Assert.Equal(cp.LC66PlusOne(digitsA),
                new int[] { 2, 0, 0 });
            Assert.Equal(cp.LC66PlusOne(digitsB),
                new int[] { 1, 0, 0, 0 });
        }
    }
}
