using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CodingPracticeService;
using static CodingPracticeService.CompletedProblems;
using System.Collections;

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
        [MemberData(nameof(P108TestData))]
        public void P108SortedArrayToBstTest(int[] nums, TreeNode expected)
        {
            var cp = new CompletedProblems();
            var actual = cp.P108SortedArrayToBST(nums);
            AssertTreeEqual(actual, expected);
        }
        public static IEnumerable<object[]> P108TestData =>
            new List<object[]>
            {
                new object[]{new int[] {1,3}, new TreeNode(1, null, new TreeNode(3))},
                //[0,-10,5,null,-3,null,9]
                new object[]{new int[] {-10,-3,0,5,9}, new TreeNode(0, new TreeNode(-10, null, new TreeNode(-3)),
                    new TreeNode(5,null, new TreeNode(9)))},
                //new object[]{new int[] { -10, -6, -3, -1, 0, 2, 4, 6 },
                //    new TreeNode(0, new TreeNode(-10, null, new TreeNode(-3)),
                //    new TreeNode(5, null, new TreeNode(9)))}
            };

        public void AssertTreeEqual(TreeNode head1, TreeNode head2)
        {
            Assert.Equal(head1.val, head2.val);

            if (head1.left == null) Assert.Null(head2.left);
            if (head2.left == null) Assert.Null(head1.left);
            if (head1.left != null && head2.left != null)
                AssertTreeEqual(head1.left, head2.left);

            if (head1.right == null) Assert.Null(head2.right);
            if (head2.right == null) Assert.Null(head1.right);
            if (head1.right != null && head2.right != null)
                AssertTreeEqual(head1.right, head2.right);
        }

        [Theory]
        [MemberData(nameof(P83TestData))]
        public void P83DeleteDuplicatesTest(ListNode head, ListNode expected)
        {
            //var expected = "";
            var cp = new CompletedProblems();
            var actual = cp.P83DeleteDuplicates(head);
            AssertListNodeEqual(actual, expected);
        }
        public static IEnumerable<object[]> P83TestData =>
            new List<object[]>{
                new object[]{new ListNode(1, new ListNode(1, new ListNode(2))),
                    new ListNode(1, new ListNode(2))},
                new object[]{new ListNode(1, new ListNode(1, new ListNode(1))),
                    new ListNode(1)}
            };
        public void AssertListNodeEqual(ListNode actual, ListNode expected)
        {
            Assert.Equal(expected.val, actual.val);
            if (actual.next == null && expected.next == null) return;
            if (expected.next == null) Assert.Null(actual.next);
            if (expected.next != null) Assert.NotNull(actual.next);
            AssertListNodeEqual(actual.next, expected.next);
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
