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
        [Fact]
        public void RandomTestATest()
        {
            var input1a = new List<int>();
            var input1 = new List<int>() { 2, 1, 1, 3};
            var input1b = new List<int>() { 4, 6, 2, 5, 6, 2, 3 };
            var input2 = new List<int>() { 1, 2 };
            var input2a = new List<int>();
            var input2b = new List<int>() { 2, 3, 7, 1, 3, 7, 4, 6, 1 };
            var input3 = new List<int>() { 2, 0 };
            var input3a = new List<int>();
            var input3b = new List<int>() { 7, 0, 0, 2, 5, 2, 6, 1, 3 };
            var expected = 9;
            var cp = new CompletedProblems();
            var actual = cp.RandomTestA(input1b, input2b, input3b);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void RandomTestA2Test()
        {
            var input1 = new List<int>() { 2, 3, 7, 1, 3, 7, 4, 6, 1 };
            var input2 = 2;
            var expected = new List<int>();
            var cp = new CompletedProblems();
            var actual = cp.RandomTestA2(input1, input2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void P495TeetosRevengeTest()
        {
            var timeSeries = new int[] { 89, 91, 91, 93 };
            var duration = 5;
            var expected = 9;
            var cp = new CompletedProblems();
            var actual = cp.P495TeetosRevenge(timeSeries, duration);
            Assert.Equal( expected, actual);
        }
        [Fact]
        public void P401ReadBinaryWatchTest()
        {
            //var input = 808201;
            var input = 9;
            //var expected = true;
            var expected = new List<string>() ;
            var cp = new CompletedProblems();
            var actual = cp.P401ReadBinaryWatch(input);
            Assert.Equal(actual, (IList<string>)expected);
        }
        [Fact]
        public void P401FindMinuteHourTest()
        {
            var tempCombo = new int[] { 0, 0, 0, 1, 0, 1, 0, 0, 1, 0 };
            var turnedOn = 3;
            //var expected = true;
            var expected = "4:40";
            var cp = new CompletedProblems();
            var actual = cp.P401FindMinuteHour(tempCombo);
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void P367IsPerfectSquareTest()
        {
            //var input = 808201;
            var input = 5;
            //var expected = true;
            var expected = false;
            var cp = new CompletedProblems();
            var actual = cp.P367IsPerfectSquare(input);
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void P278FirstBadVersion()
        {
            var input = 2126753390;
            var expected = 1702766719;
            var cp = new CompletedProblems();
            var actual = cp.P278FirstBadVersion(input);
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void P234IsPalindromeTest()
        {
            var expected = false;
            var input = new ListNode(1, new ListNode(2, new ListNode(3)));
            var cp = new CompletedProblems();
            var actual = cp.P234IsPalindromeV2(input);
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void P219ContainsNearbyDuplicateTest()
        {
            var expected = true;
            var nums = new int[] { 1, 2, 3, 1 };
            var k = 3;
            var cp = new CompletedProblems();
            var actual = cp.P219ContainsNearbyDuplicate( nums, k);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void P206ReverseListTest()
        {
            var input = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode( 5)))));
            var expected = new ListNode(5, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1)))));
            var cp = new CompletedProblems();
            var actual = cp.P206ReverseList(input);
            AssertListNodeEqual(actual, expected);
        }

        [Fact]
        public void P190ReverseBits()
        {

            uint input = 43261596;
            uint expected = 964176192;
            uint input1 = 11;
            var cp = new CompletedProblems();
            var actual = cp.P190ReverseBits(input);
            Assert.Equal(actual, expected);
        }

        [Theory]
        //[InlineData("A", 1)]
        [InlineData("AB", 28)]
        public void P171TitleToNumber(string input, int expected)
        {
            //var expected = 1;
            var cp = new CompletedProblems();
            var actual = cp.P171TitleToNumber(input);
            Assert.Equal(actual, expected);
        }


        [Theory]
        [InlineData(701, "ZY")]
        //[InlineData(28, "AB")]
        public void P168ConvertToTitle(int input, string expected)
        {
            //var expected = "AB";
            var cp = new CompletedProblems();
            var actual = cp.P168ConvertToTitle(input);
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData()]
        public void P160GetIntersectionNodeTest()
        {
            var intersectNodes = new ListNode(2, new ListNode(4));
            var nodeA = new ListNode(1, new ListNode(9, new ListNode(1, intersectNodes)));
            var nodeB = new ListNode(3, intersectNodes);
            var expected = intersectNodes;
            var cp = new CompletedProblems();
            var actual = cp.P160GetIntersectionNode(nodeA, nodeB);
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData(3)]
        public void P119GetRowTest(int rowIndex)
        {
            var expected = new List<int>() { 1, 3, 3, 1 };
            var cp = new CompletedProblems();
            var actual = cp.P119GetRow(rowIndex);
            Assert.Equal(actual, expected);
        }

        [Theory]
        [MemberData(nameof(P110TestData))]
        public void P110IsBalancedTest(TreeNode root, bool expected)
        {
            //var expected = "";
            var cp = new CompletedProblems();
            var actual = cp.P110IsBalanced(root);
            Assert.Equal(actual, expected);
        }
        public static IEnumerable<object[]> P110TestData =>
        new List<object[]>
        {
            // [1,
            // null,2,
            // null,3]
            // false, wtf

            // [3,
            // 9,20,
            // null,null,15,7], true
            new object[]{new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15),new TreeNode(7))),
                true},
            //[1,
            //2,3,
            //4,5,6,null,
            //8] true
            new object[]{new TreeNode(1, new TreeNode(2, new TreeNode(4, new TreeNode(8)), new TreeNode(5)), 
                new TreeNode(3, new TreeNode(6))), true
                },
            new object[]{new TreeNode(1, new TreeNode(2, new TreeNode(3, new TreeNode(4), new TreeNode(4)),
                new TreeNode(3)), new TreeNode(2)), false}


        };

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
