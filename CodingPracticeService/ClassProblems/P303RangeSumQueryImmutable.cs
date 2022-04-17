using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPracticeService.ClassProblems
{
    class P303RangeSumQueryImmutable
    {
        /// 303. Range Sum Query - Immutable
        /// time O(n) space O(1)
        public P303RangeSumQueryImmutable(int[] nums)
        {
            Nums = nums;
        }
        public int[] Nums;
        public int SumRange(int left, int right)
        {
            int sum = 0;
            for (int i = left; i <= right; i++)
            {
                sum += Nums[i];
            }
            return sum;
        }
    }
}
