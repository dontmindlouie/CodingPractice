using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodingPracticeService.Problems
{
    class LC66PlusOne
    {
        [Fact]
        public void Test()
        {
            var digits = new int[] { 1, 2, 3 };
            var result = PlusOne(digits);
        }
        public int[] PlusOne(int[] digits)
        {
            // You are given a large integer represented as an integer array digits,
            // where each digits[i] is the ith digit of the integer. The digits are
            // ordered from most significant to least significant in left-to-right
            // order. The large integer does not contain any leading 0's.

            // Increment the large integer by one and return the resulting array of digits.


            var largestNum = 0;

            for (int i = digits.Length; i < 0; i--)
            {
                largestNum = largestNum + (digits[i] * 10 * digits.Length-i);
            }


            return digits;
        }
    }
}
