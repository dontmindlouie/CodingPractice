﻿using System;
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
        [Theory]
        [InlineData("11", "1")]
        public void P67AddBinary(string a, string b)
        {
            var cp = new CompletedProblems();
            var actual = cp.P67AddBinary(a, b);
            Assert.Equal(actual,
                "100");
        }

            [Theory]
        [InlineData(new int[] { 1, 9, 9 },
        new int[] { 9, 9, 9 })]
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