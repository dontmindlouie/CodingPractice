using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodingPracticeService
{
    public class CompletedProblems
    {
        public bool P219ContainsNearbyDuplicate(int[] nums, int k)
        {
            // 219. Contains Duplicate II
            // time O(n2) space O(1)
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j] && (Math.Abs(i - j) <= k)) return true;
                    if ((Math.Abs(i - j) > k)) break;
                }
            }
            return false;
        }
        public ListNode P206ReverseList(ListNode head)
        {
            // 206. Reverse Linked List
            // time O(head) space O(1)
            // Runtime: 109 ms, faster than 56.09% of C# online submissions for Reverse Linked List.
            // Memory Usage: 37.5 MB, less than 97.54 % of C# online submissions for Reverse Linked List.
            if (head == null) return null;
            if (head.next == null) return head;
            var newNode = head;
            var pivot = head.next;
            var oldNode = head.next.next;
            newNode.next = null;
            while (oldNode != null)
            {
                pivot.next = newNode;
                newNode = pivot;
                pivot = oldNode;
                oldNode = oldNode.next;
            }
            pivot.next = newNode;
            return pivot;
        }
        public ListNode P203RemoveElements(ListNode head, int val)
        {
            // 203. Remove Linked List Elements
            // time O(n) space O(1)
            // Runtime: 108 ms, faster than 68.61% of C# online submissions for Remove Linked List Elements.
            // Memory Usage: 40.3 MB, less than 70.11% of C# online submissions for Remove Linked List Elements.

            if (head == null) return null;
            while (head.val == val)
                if (head.next != null) head = head.next;
                else return null;
            var node = head;
            while (node.next != null)
                if (node.next.val == val)
                    if (node.next.next == null) node.next = null;
                    else node.next = node.next.next;
                else node = node.next;
            return head;
        }
        public bool P202IsHappy(int n)
        {
            Console.WriteLine();
            // 202. Happy Number
            // time complexity ???? space O(1)
            // Write an algorithm to determine if a number n is happy.

            // A happy number is a number defined by the following process:

            // Starting with any positive integer, replace the number by the sum of the squares of its digits.
            // Repeat the process until the number equals 1(where it will stay), or it loops endlessly in a cycle which does not include 1.
            // Those numbers for which this process ends in 1 are happy.
            // Return true if n is a happy number, and false if not.

            // Runtime: 46 ms, faster than 51.57% of C# online submissions for Happy Number.
            // Memory Usage: 28.3 MB, less than 27.80% of C# online submissions for Happy Number.

            var slown = n;
            var fastn = n;
            do
            {
                slown = P202SumOfSquares(slown);
                fastn = P202SumOfSquares(fastn);
                fastn = P202SumOfSquares(fastn);
                if (slown == 1 || fastn == 1) return true;
            } while (slown != fastn);
            return false;
        }
        public int P202SumOfSquares(int n)
        {
            var numAsString = n.ToString();
            var sum = 0;
            foreach (char num in numAsString)
            {
                var indInt = int.Parse(new char[] { num });
                sum += (int)Math.Pow(indInt, 2);
            }
            return sum;
        }

        public int P191HammingWeight(uint n)
        {
            // 191. Number of 1 Bits
            // time O(1) space O(1)
            int result = 0;
            uint val;
            int bitCount = 0;
            for (int i = 0; i < 32; i++)
            {
                val = n & 1; // 1011 & 1 = 1 // 101 & 1 = 1
                if (val == 1)
                {
                    bitCount++;
                }
                n >>= 1; // 101
            }
            return bitCount;
        }

        public uint P190ReverseBits(uint n)
        {
            // 190. Reverse Bits
            // time O(32) or O(1) space O(1)
            // Runtime: 46 ms, faster than 12.92% of C# online submissions for Reverse Bits.
            // Memory Usage: 22.7 MB, less than 80.20% of C# online submissions for Reverse Bits.
            uint temp;
            uint result = 0;
            uint shift;
            for (int i = 0; i < 32; i++)
            {
                temp = n;
                shift = temp & 1;
                result <<= 1;
                result = result | shift;
                n >>= 1;
            }
            return result;
        }

        public int P171TitleToNumber(string columnTitle)
        {
            // 171. Excel Sheet Column Number
            // time O(n) space O(1)
            // base 26 to base 10
            // Runtime: 113 ms, faster than 15.11% of C# online submissions for Excel Sheet Column Number.
            // Memory Usage: 37 MB, less than 30.86 % of C# online submissions for Excel Sheet Column Number.
            
            var abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            double result = 0;

            for (int i = 0; i < columnTitle.Length; i++)
            {
                var remain = (abc.IndexOf(columnTitle[i]) + 1)
                    * Math.Pow(26, columnTitle.Length - 1 - i);
                result += remain;
            }

            return (Int32)result;
        }
        public int P169MajorityElement(int[] nums)
        {
            // 169. Majority Element
            // time O(n) space O(n) / O(n/2)
            // Runtime: 143 ms, faster than 50.07% of C# online submissions for Majority Element.
            //Memory Usage: 41 MB, less than 49.13% of C# online submissions for Majority Element.
            var majority = (nums.Length) / 2;

            // numMap num, count of num
            var numMap = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (numMap.TryAdd(num, 1))
                {
                }
                else
                {
                    numMap[num]++;
                }
                if (numMap[num] > majority) return num;
            }
            return 0;
        }

        public string P168ConvertToTitle(int columnNumber)
        {
            // 168. Excel Sheet Column Title
            // time O(1) space O(1)
            // Runtime: 64 ms, faster than 93.10% of C# online submissions for Excel Sheet Column Title.
            // Memory Usage: 37.1 MB, less than 6.27 % of C# online submissions for Excel Sheet Column Title.
            string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            
            while (columnNumber > 0)
            {
                var remain = columnNumber % 26;
                if (remain == 0)
                {
                    result = abc[25] + result;
                    columnNumber--;
                }
                else result = abc[remain - 1] + result;
                columnNumber /= 26;
            }

            return result;
        }

            //  A   A
            // AA   AA
            // AB   BA
            // AZ   ZA
            // BA   AB
            // BB
            // ZZ
            //AAA
            //AAB


        public ListNode P160GetIntersectionNode(ListNode headA, ListNode headB)
        {
            // 160.Intersection of Two Linked Lists
            // time O(A*B) space O(A+B)
            // TODO: remove the lists and iterate from the head;
            // Runtime: 669 ms, faster than 11.20 % of C# online submissions for Intersection of Two Linked Lists.
            // Memory Usage: 47 MB, less than 16.15 % of C# online submissions for Intersection of Two Linked Lists.

            var currNodeA = headA;
            var currNodeB = headB;
            var nodeListA = new List<ListNode>();
            var nodeListB = new List<ListNode>();
            // [1,9,1,2,4]
            // [3,2,4]
            while (currNodeA != null || currNodeB != null)
            {
                if (currNodeA != null)
                {
                    nodeListA.Add(currNodeA);
                    foreach (var node in nodeListB)
                    {
                        if (node == currNodeA) return currNodeA;
                    }
                    currNodeA = currNodeA.next;
                }
                if (currNodeB != null)
                {
                    nodeListB.Add(currNodeB);
                    foreach (var node in nodeListA)
                    {
                        if (node == currNodeB) return currNodeB;
                    }
                    currNodeB = currNodeB.next;
                }
            }
            return null;
        }

        public IList<int> P145PostorderTraversal(TreeNode root)
        {
            // 145. Binary Tree Postorder Traversal
            // time O(root) space O(root)

            // Runtime: 207 ms, faster than 35.21% of C# online submissions for Binary Tree Postorder Traversal.
            // Memory Usage: 40.5 MB, less than 94.56% of C# online submissions for Binary Tree Postorder Traversal.

            var valList = new List<int>();
            P145Traverse(root, valList);
            return valList;
        }

        public void P145Traverse(TreeNode node, IList<int> valList)
        {
            if (node == null) return;
            P145Traverse(node.left, valList);
            P145Traverse(node.right, valList);
            valList.Add(node.val);
            return;
        }
        public IList<int> P144PreorderTraversal(TreeNode root)
        {
            //LeetCode 144. Binary Tree Preorder Traversal

            // time O(root) space O(root)
            // Runtime: 246 ms, faster than 13.07% of C# online submissions for Binary Tree Preorder Traversal.
            // Memory Usage: 40.9 MB, less than 49.04 % of C# online submissions for Binary Tree Preorder Traversal.
            var valList = new List<int>();
            if (root == null) return valList;
            P144Traverse(root, valList);
            return valList;
        }
        public void P144Traverse(TreeNode node, IList<int> valList)
        {
            if (node == null) return;
            valList.Add(node.val);
            P144Traverse(node.left, valList);
            P144Traverse(node.right, valList);
            return;
        }
        public IList<int> P119GetRow(int rowIndex)
        {
            // LeetCode 119 Pascal Triangle II
            // time O(rowIndex2) space O(rowIndex)
            // Runtime: 121 ms, faster than 54.05% of C# online submissions for Pascal's Triangle II.
            // Memory Usage: 34.3 MB, less than 98.05 % of C# online submissions for Pascal's Triangle II.

            var tri = new List<int>() { 1 };

            // 1
            // 11
            // 121
            // 1331
            for (int i = 0; i < rowIndex; i++)
            {
                tri.Add(tri[tri.Count - 1]);
                for (int j = tri.Count - 2; j > 0; j--)
                {
                    tri[j] = tri[j - 1] + tri[j];
                }
            }
            return tri;
        }

        public bool P141HasCycle(ListNode head)
        {
            // 141. Linked List Cycle
            // time O(n) space O(1)
            // Runtime: 113 ms, faster than 78.26% of C# online submissions for Linked List Cycle.
            // Memory Usage: 42 MB, less than 39.84 % of C# online submissions for Linked List Cycle.
            if (head == null) return false;
            var slow = head;
            if (head.next == null) return false;
            var fast = head.next;
            return P141Traverse(slow, fast);
            var tri = new List<int>() { 1 };
        }
        public bool P141Traverse(ListNode slow, ListNode fast)
        {
            if (fast == null) return false;
            if (fast.next == null) return false;
            if (fast.next.next == null) return false;
            if (slow == fast) return true;
            return P141Traverse(slow.next, fast.next.next);
        }

        public int P136SingleNumber(int[] nums)
        {
            // 136. Single Number
            // time O(n) space O(1)
            // Runtime: 110 ms, faster than 80.45% of C# online submissions for Single Number.
            // Memory Usage: 40 MB, less than 70.49 % of C# online submissions for Single Number.

            int paired = 0;
            foreach (var num in nums)
            {
                paired ^= num;
            }
            return paired;
        }
        public bool P112HasPathSum(TreeNode root, int targetSum)
        {
            // 112.Path Sum
            // time O(n) space O(1)
            // Runtime: 88 ms, faster than 97.47% of C# online submissions for Path Sum.
            // Memory Usage: 42.5 MB, less than 7.27 % of C# online submissions for Path Sum.

            if (root == null) return false;
            int prevSum = 0;
            return P112Traverse(root, targetSum, prevSum);
        }
        public bool P112Traverse(TreeNode node, int targetSum, int prevSum)
        {
            if (node == null) return false;
            var currSum = prevSum += node.val;
            if (currSum == targetSum && node.left == null && node.right == null) return true;
            if (P112Traverse(node.left, targetSum, currSum) == true) return true;
            if (P112Traverse(node.right, targetSum, currSum) == true) return true;
            return false;
        }

        public int P111MinDepth(TreeNode root)
        {
            // 111.Minimum Depth of Binary Tree
            // time O(n) space O(1)
            // Runtime: 389 ms, faster than 41.09% of C# online submissions for Minimum Depth of Binary Tree.
            // Memory Usage: 55.7 MB, less than 82.30 % of C# online submissions for Minimum Depth of Binary Tree.

            if (root == null) return 0;
            min = -1;
            P111Traverse(root, 0);
            return min;
        }
        public static int min;
        public void P111Traverse(TreeNode node, int height)
        {
            if (node == null) return;
            height++;
            if (node.left == null && node.right == null)
            {
                if (min > height || min == -1) min = height;
            }
            P111Traverse(node.left, height);
            P111Traverse(node.right, height);
            return;
        }

        public bool P110IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            var heightSet = new HashSet<int>();
            var result = P110Traverse(root, heightSet, 0);

            return result;

        }

        public bool P110Traverse(TreeNode node, HashSet<int> heightSet, int currHeight)
        {
            currHeight++;
            if (node.left == null && node.right == null)
            {
                foreach (var height in heightSet)
                {
                    if (height - 1 > currHeight || currHeight > height + 1)
                    {
                        return false;
                    }
                }
                heightSet.Add(currHeight);
            }
            if (node.left != null)
                if (P110Traverse(node.left, heightSet, currHeight) == false)
                    return false;

            if (node.right != null)
                if (P110Traverse(node.right, heightSet, currHeight) == false)
                    return false;
            return true;

        }
        public TreeNode P108SortedArrayToBST(int[] nums)
        {
            // 108. Convert Sorted Array to Binary Search Tree
            // Breadth first traversal
            // time O(n) space O(n)
            // Runtime: 104 ms, faster than 70.39% of C# online submissions for Convert Sorted Array to Binary Search Tree.
            // Memory Usage: 37.9 MB, less than 40.03 % of C# online submissions for Convert Sorted Array to Binary Search Tree.

            if (nums.Length == 0 || nums == null) return null;
            int min = 0;
            int max = nums.Length - 1;
            int mid = (min + max) / 2;

            var head = new TreeNode(nums[mid]);
            var nodeQ = new Queue<(TreeNode, int, int)>();
            nodeQ.Enqueue((head, min, max));
            (TreeNode, int, int) tempNode;
            //-10,-3,0,5,9
            while (nodeQ.Count > 0)
            {
                tempNode = nodeQ.Dequeue();
                min = tempNode.Item2;
                max = tempNode.Item3;
                mid = (max + min) / 2;

                if (min <= mid - 1)
                {
                    var leftMid = (mid - 1 + min) / 2;
                    tempNode.Item1.left = new TreeNode(nums[leftMid]);
                    nodeQ.Enqueue((tempNode.Item1.left, min, mid - 1));
                }

                if (max >= mid + 1)
                {
                    var rightMid = (mid + 1 + max) / 2;
                    tempNode.Item1.right = new TreeNode(nums[rightMid]);
                    nodeQ.Enqueue((tempNode.Item1.right, mid + 1, max));
                }
            }

            return head;
        }

        public int P104MaxDepth(TreeNode root)
        {
            // 104.Maximum Depth of Binary Tree
            // time O(n) space O(1)
            // Runtime: 109 ms, faster than 64.85% of C# online submissions for Maximum Depth of Binary Tree.
            // Memory Usage: 37.9 MB, less than 75.73% of C# online submissions for Maximum Depth of Binary Tree.
            P104maxDepth = 0;
            if (root == null) return 0;
            P104CalcDepth(root, P104maxDepth);
            return P104maxDepth;
        }
        public static int P104maxDepth;
        public void P104CalcDepth(TreeNode node, int tempDepth)
        {
            tempDepth++;
            if (P104maxDepth < tempDepth) P104maxDepth = tempDepth;
            if (node.left != null)
                P104CalcDepth(node.left, tempDepth);
            if (node.right != null)
                P104CalcDepth(node.right, tempDepth);
        }

        public bool P101IsSymmetric(TreeNode root)
        {
            // LeetCode 101. Symmetric Tree
            // time O(n) space O(1)

            // slower, but use less memory. maybe use DP?
            // Runtime: 156 ms, faster than 26.78% of C# online submissions for Symmetric Tree.
            // Memory Usage: 38.9 MB, less than 92.54 % of C# online submissions for Symmetric Tree.

            if (root == null) return true;
            var head = root;
            if (head.left == null && head.right == null) return true;
            if (head.left == null ^ head.right == null) return false;
            return P101Traverse(head.left, head.right, true);
        }
        public bool P101Traverse(TreeNode leftNode, TreeNode rightNode, bool isSym)
        {
            if (leftNode.val != rightNode.val) return false;
            if (leftNode.left == null ^ rightNode.right == null) return false;
            if (leftNode.right == null ^ rightNode.left == null) return false;

            if (leftNode.left != null && rightNode.right != null)
                isSym = P101Traverse(leftNode.left, rightNode.right, isSym);

            if (leftNode.right != null && rightNode.left != null)
                isSym = P101Traverse(leftNode.right, rightNode.left, isSym);

            return isSym;

        }

        public bool P100IsSameTree(TreeNode p, TreeNode q)
        {
            // 100. Same Tree

            // time O(p+q) space O(p+q)
            // Runtime: 133 ms, faster than 47.51% of C# online submissions for Same Tree.
            // Memory Usage: 38.6 MB, less than 60.77 % of C# online submissions for Same Tree.

            var result = true;
            if (p == null && q == null) return true;
            if (p == null ^ q == null) return false;
            result = P100Traverse(p, q, result);
            return result;
        }
        public bool P100Traverse(TreeNode p, TreeNode q, bool result)
        {
            if (p.val != q.val) return false;
            if (p.left == null ^ q.left == null) return false;
            if (p.left != null && q.left != null)
                result = P100Traverse(p.left, q.left, result);
            if (p.right == null ^ q.right == null) return false;
            if (p.right != null && q.right != null)
                result = P100Traverse(p.right, q.right, result);
            return result;
        }

        public IList<int> P94InorderTraversal(TreeNode root)
        {
            // 94. Binary Tree Inorder Traversal
            // time O(n) space O(n)
            // Runtime: 240 ms, faster than 14.31% of C# online submissions for Binary Tree Inorder Traversal.
            // Memory Usage: 40.7 MB, less than 87.80 % of C# online submissions for Binary Tree Inorder Traversal.
            var order = new List<int>();
            if (root != null)
                P94Traverse(root, order);
            return order;
        }

        public IList<int> P94Traverse(TreeNode node, IList<int> order)
        {
            if (node.left != null) P94Traverse(node.left, order);
            order.Add(node.val);
            if (node.right != null) P94Traverse(node.right, order);
            return order;
        }

        public ListNode P83DeleteDuplicates(ListNode head)
        {
            // 83. Remove Duplicates from Sorted List
            // TODO: leverage that the list is sorted...

            // with List
            // time O(n) space O(n)
            // Runtime: 88 ms, faster than 83.35% of C# online submissions for Remove Duplicates from Sorted List.
            // Memory Usage: 40.4 MB, less than 5.48 % of C# online submissions for Remove Duplicates from Sorted List.

            // with Hashset
            // Runtime: 88 ms, faster than 83.35% of C# online submissions for Remove Duplicates from Sorted List.
            // Memory Usage: 40.2 MB, less than 8.33 % of C# online submissions for Remove Duplicates from Sorted List.

            //var dupList = new List<int>();
            var dupList = new HashSet<int>();
            if (head == null) return head;
            dupList.Add(head.val);
            var node = head;
            while (node.next != null)
            {
                if (dupList.Contains(node.next.val))
                {
                    // duplicate, remove node
                    if (node.next.next == null)
                    {
                        if (dupList.Contains(node.next.val))
                        {
                            node.next = null;
                            break;
                        }
                    }
                    node.next = node.next.next;
                }
                else
                {
                    dupList.Add(node.next.val);
                    node = node.next;
                }
            }
            return head;
        }

        public int P70ClimbStairs(int n)
        {
            // 70. Climbing Stairs
            // time = O(n), space = O(1)
            // Runtime: 24 ms, faster than 81.10% of C# online submissions for Climbing Stairs.
            // Memory Usage: 26.6 MB, less than 13.05 % of C# online submissions for Climbing Stairs.
            var prev = 0;
            var prev2 = 0;
            var current = 1;

            for (int i = 1; i <= n; i++)
            {
                prev2 = prev;
                prev = current;
                current = prev + prev2;
            }

            return current;
        }

        public string P67AddBinary(string a, string b)
        {
            // LeetCode 67. Add Binary
            // time O(n) space O(n)

            // With result = StringBuilder();
            // Runtime: 139 ms, faster than 14.42% of C# online submissions for Add Binary.
            // Memory Usage: 37 MB, less than 71.47 % of C# online submissions for Add Binary.

            // With string result prepend
            // Runtime: 116 ms, faster than 40.87% of C# online submissions for Add Binary.
            // Memory Usage: 37.5 MB, less than 46.78 % of C# online submissions for Add Binary.

            // With string result append then reverse
            // Runtime: 102 ms, faster than 59.54% of C# online submissions for Add Binary.
            // Memory Usage: 37.7 MB, less than 32.05 % of C# online submissions for Add Binary.

            // var result = new StringBuilder();
            var result = "";
            var ai = a.Length - 1;
            var bi = b.Length - 1;
            var carryover = 0;

            while ((ai >= 0 || bi >= 0) || carryover >= 1)
            {
                var sum = carryover;

                if (ai >= 0)
                {
                    sum += a[ai] - '0';
                }
                if (bi >= 0)
                {
                    sum += b[bi] - '0';
                }
                //result = result.Append((sum % 2).ToString()[0]).ToString();
                result = result.Insert(result.Length, (sum % 2).ToString());
                //result = result.Insert(0, (sum % 2).ToString());
                if (sum >= 2) carryover = 1;
                else carryover = 0;

                ai--;
                bi--;
            }

            result = new string(result.Reverse().ToArray());

            return result.ToString();
        }

        public int[] LC66PlusOne(int[] digits)
        {
            // LeetCode 66.Plus One
            // space O(1) time O(digits)
            // You are given a large integer represented as an integer array digits,
            // where each digits[i] is the ith digit of the integer. The digits are
            // ordered from most significant to least significant in left-to-right
            // order. The large integer does not contain any leading 0's.
            // Increment the large integer by one and return the resulting array of digits.
            bool flag = true;
            int i = digits.Length - 1;
            while (flag)
            {
                if (digits[i] != 9)
                {
                    digits[i]++;
                    flag = false;
                }
                else if (i == 0 && digits[i] == 9)
                {
                    digits[i] = 0;
                    digits = digits.Prepend(1).ToArray();
                    flag = false;
                }
                else
                {
                    digits[i] = 0;
                }
                i--;
            }

            return digits;
        }

        private ListNode LCP21MergeTwoLists(ListNode list1, ListNode list2)
        {
            var sortedList = new ListNode();
            ListNode iteratedList;

            iteratedList = sortedList;

            if (list1 == null && list2 == null) return null;

            if (list1 == null) return list2;

            if (list2 == null) return list1;

            if (list1.val > list2.val)
            {
                Console.WriteLine($"add list2 val {list2.val}");
                iteratedList.val = list2.val;
                if (list2.next == null)
                {
                    iteratedList.next = list1;
                    return sortedList;
                }
                list2 = list2.next;
            }
            else
            {
                Console.WriteLine($"add list1 val {list1.val}");
                iteratedList.val = list1.val;
                if (list1.next == null)
                {
                    iteratedList.next = list2;
                    return sortedList;
                }
                list1 = list1.next;
            }

            while (true) //list1.next != null && list2.next != null)
            {
                if (list1.val > list2.val)
                {
                    Console.WriteLine($"add list2 value {list2.val}");
                    iteratedList.next = new ListNode(list2.val);
                    iteratedList = iteratedList.next;
                    if (list2.next == null)
                    {
                        iteratedList.next = list1;
                        return sortedList;
                    }
                    else list2 = list2.next;
                }
                else
                {
                    Console.WriteLine($"add list1 value {list1.val}");
                    iteratedList.next = new ListNode(list1.val);
                    iteratedList = iteratedList.next;
                    if (list1.next == null)
                    {
                        iteratedList.next = list2;
                        return sortedList;
                    }
                    else list1 = list1.next;
                }
            }
        }

        private ListNode LCP21MergeTwoListv2(ListNode list1, ListNode list2)
        {
            var sortedList = new ListNode();
            ListNode iteratedList;

            iteratedList = sortedList;

            if (list1 == null && list2 == null) return null;

            if (list1 == null) return list2;

            if (list2 == null) return list1;

            while (list1 != null && list2 != null)
            {
                if (list1.val > list2.val)
                {
                    Console.WriteLine($"add list2 value {list2.val}");
                    iteratedList.val = list2.val; //new ListNode(list2.val);
                    if (list2.next == null)
                    {
                        iteratedList.next = list1;
                        return sortedList;
                    }
                    else list2 = list2.next;
                }
                else
                {
                    Console.WriteLine($"add list1 value {list1.val}");
                    iteratedList.val = list1.val; // new ListNode(list1.val);
                    if (list1.next == null)
                    {
                        iteratedList.next = list2;
                        return sortedList;
                    }
                    else list1 = list1.next;
                }
                iteratedList.next = new ListNode();
                iteratedList = iteratedList.next;
            }

            return sortedList;
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        private int P26RemoveDuplicateFromArray(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int dupPosition = 0;
            int i = 0;
            for (; i < nums.Length - 1; i++)
            {
                // find next non dup position
                // i 0 1, d 0 1
                // i 0 1, d 1 2
                for (; nums[dupPosition] <= nums[i]; dupPosition++)
                {
                    // d 0, l 1
                    if (dupPosition >= nums.Length - 1) return i + 1;
                }
                // i 1 2, d 1 2
                nums[i + 1] = nums[dupPosition];
            }
            return i + 1;
        }

        private int P27RemoveElement(int[] nums, int val)
        {
            int validi = 0;
            int i = 0;
            // [1], 1
            // i 0 1, 1
            // [3,3], 5
            // i 0 3, 1
            for (; i < nums.Length; i++)
            {
                // vi 0 1, val 1

                // vi 0 3, val 5
                for (; nums[validi] == val; validi++)
                {
                    if (validi >= nums.Length - 1)
                    {
                        return i;
                    }
                }
                // i 0 2, vi 0 2

                // i 0 3, vi 0 3
                nums[i] = nums[validi];
                validi++;
                // vi 1, 1
                if (validi > nums.Length - 1)
                {
                    return i + 1;
                }
            }
            return i;
        }

        private bool P217ContainsDuplicate(int[] nums)
        {
            if (nums.Length == 0) return false;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j]) return true;
                }
            }
            return false;
        }

        private int P53MaxSubArray(int[] nums)
        {
            // brute force
            // O(n3)
            int largestSum = nums[0];
            // [1,-3,5,2,4]
            // exp 11
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j + i < nums.Length; j++)
                {
                    int sum = P53SumSubArray(nums, i, j);
                    if (sum > largestSum) largestSum = sum;
                }
            }
            return largestSum;
        }
        private int P53SumSubArray(int[] nums, int i, int j)
        {
            int localSum = 0;
            for (int k = i; k <= (i + j); k++)
            {
                localSum = localSum + nums[k];
            }
            return localSum;
        }

        private int P53MaxSubArrayV2(int[] nums)
        {
            // O(n)
            int largestSum = nums[0];
            int interval = 0;

            for (int i = 0; i < nums.Length; i++)
            {

                interval += nums[i];
                if (nums[i] > interval) interval = nums[i];
                if (interval > largestSum) largestSum = interval;
            }
            return largestSum;
        }
        private int P28StrStr(string haystack, string needle)
        {
            // this doesn't work if there's multiple needles
            if (needle.Length == 0) return 0;
            if (haystack.Length == 0) return -1;
            int needleI = needle.Length - 1;

            for (int i = haystack.Length - 1; i >= 0; i--)
            {
                if (haystack[i] == needle[needleI])
                    needleI--;
                else
                {
                    needleI = needle.Length - 1;
                }
                if (needleI < 0) return i;
            }
            return -1; //needle not found

        }
        private int P28StrStr2(string haystack, string needle)
        {
            if (needle.Length == 0) return 0;

            // hay aaaaa n bba
            // i 0, hl 5
            // i 1, hl 5
            for (int i = 0; i < haystack.Length; i++)
            {
                // ij 0, hl 5
                // ij 1, hl 5
                for (int j = 0; (i + j) < haystack.Length; j++)
                {
                    // nj 0 b hij 0 a
                    // nj 0 b hij 1 a
                    if (needle[j] != haystack[i + j])
                    {
                        break; // pattern not found
                    }
                    if (j >= needle.Length - 1) return i;
                }
            }
            return -1;
        }
        private void P88Merge2SortedArrays(int[] nums1, int m, int[] nums2, int n)
        {
            int i1 = m - 1;
            int i2 = n - 1;
            int i = nums1.Length - 1;

            // 0 [0] 1 [1]
            // i1 -1 ? i2 0 1
            while (i1 > -1 && i2 > -1)
            {
                if (nums1[i1] < nums2[i2])
                {
                    nums1[i] = nums2[i2];
                    i2--;
                }
                else
                {
                    nums1[i] = nums1[i1];
                    i1--;
                }
                i--;
            }
            while (i1 < 0 && i2 >= 0)
            {
                nums1[i] = nums2[i2];
                i2--;
                i--;
            }
        }
        private int[] P350Intersect(int[] nums1, int[] nums2)
        {
            var result = new List<int>();

            // nums1 = [1,2,2,1], nums2 = [2,2]
            //               mark2 = [0,0]
            var mark2 = new List<int>();
            nums2.ToList().ForEach(n2 => { mark2.Add(0); });

            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (nums1[i] == nums2[j])
                    {
                        if (mark2[j] == 0)
                        {
                            result.Add(nums1[i]);
                            mark2[j] = 1;
                            break;
                        }
                    }
                }
            }
            return result.ToArray();
        }
        public int P121MaxProfit(int[] prices)
        {
            // [7,1,5,3,6,4]
            int maxProfit = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                var sellAmount = prices
                    .ToList()
                    .GetRange(i, prices.Length - i)
                    .Max<int>();
                var profit = sellAmount - prices[i];
                //if (profit <= 0) continue;
                if (profit > maxProfit) maxProfit = profit;
            }
            return maxProfit;
        }
        private int[][] P566MatrixReshape(int[][] mat, int r, int c)
        {
            int[][] result = new int[r][];
            var interimList = new List<int>();
            for (int rowi = 0; rowi < mat.Length; rowi++)
            {
                for (int coli = 0; coli < mat[rowi].Length; coli++)
                {
                    interimList.Add(mat[rowi][coli]);
                }
            }

            int interimi = 0;
            Console.WriteLine("interimList");
            interimList.ForEach(node => { Console.Write($"{node} "); });

            for (int rowi = 0; rowi < r; rowi++)
            {
                var innerList = new List<int>();
                for (int coli = 0; coli < c; coli++)
                {
                    // check if r+c is over provisioned
                    if (interimi > interimList.Count - 1) return mat;
                    innerList.Add(interimList[interimi]);
                    interimi++;
                }
                // check col count meets requirements
                if (innerList.Count != c) return mat;
                result[rowi] = innerList.ToArray();
            }
            // check row count meets requirements
            if (result.Length != r) return mat;
            // check if the whole array has been used
            if (interimi != interimList.Count) return mat;
            return result.ToArray();
        }
        private int P58LengthOfLastWord(string s)
        {
            // find index of last space
            int noBeginSpaceCount = 0;
            int wordCount = 0;
            if (s[s.Length - 1] == ' ')
            {
                // find non space
                for (int i = s.Length - 2; i >= 0; i--)
                {
                    if (s[i] != ' ')
                    {
                        for (int wordI = i - 1; wordI >= 0; wordI--)
                        {
                            Console.WriteLine($"WordCount: {wordCount}");
                            if (s[wordI] == ' ') return wordCount + 1;
                            wordCount++;
                        }
                        // only 1 word
                        return wordCount + 1;
                    }
                    Console.WriteLine($"NoBeginningSpaceCount: {noBeginSpaceCount}");
                    noBeginSpaceCount++;
                }
                // it's all spaces
                Console.WriteLine($"NoBeginningSpaceCount: {noBeginSpaceCount}");
                return noBeginSpaceCount;
            }
            else
            {
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (s[i] == ' ')
                    {
                        Console.WriteLine($"Last space found: {i}");
                        return wordCount;
                    }
                    wordCount++;
                }
                return wordCount;
            }
        }
        private IList<IList<int>> P118PascalTriangle(int numRows)
        {
            IList<IList<int>> triangle = new List<IList<int>>()
            { new List<int>() { 1 } };

            // numRows 
            // [1], 
            // [1,1], 
            // [1,1+1,1],
            // [1,1+2,1+2,1]

            var colCount = 0;
            for (int rowi = 0; rowi < numRows - 1; rowi++)
            {
                var newRow = new List<int>();
                for (int nodei = 0; nodei < colCount + 1; nodei++)
                {
                    // first node
                    if (nodei == 0) newRow.Add(1);
                    else
                    {
                        newRow[nodei] += triangle[rowi][nodei];
                    }
                    // second node
                    newRow.Add(triangle[rowi][nodei]);
                }
                triangle.Add(newRow);
                colCount++;
            }

            return triangle;
        }
        private int RandomSomething2(int[] A)
        {
            // original is O(n^2)
            // [ 2, 4, 5, 2, 3 ]

            int N = A.Length;
            int lastIterator = 0;

            // takes the first element in Array and finds the final instance
            int searchForLast = A[0];

            for (int i = 0; i < N; i++)
            {
                if (A[i] >= searchForLast)
                {
                    lastIterator = i;
                    searchForLast = A[i];
                };
            }

            return lastIterator;
        }

        private int RandomSomthing3(int[] N)
        {
            // 256
            // can't set char at an index with string
            // 
            string aString = N.ToString();

            // set charArray to let us insert / remove char
            //char[] charArray = new char[aString.Length-1];

            //for (int i = 0; i < aString.Length-1; i++)
            //{
            //    charArray[i] = aString[i];
            //}


            for (int i = 0; i < aString.Length; i++)
            {
                if (aString[i] == 5)
                {
                    aString = aString.Remove(i, 1);
                }
            }

            return Int32.Parse(aString);
        }

        public TreeNode P108AddNode(TreeNode travNode, int num)
        {
            if (num > travNode.val)
            {
                if (travNode.right == null)
                {
                    travNode.right = new TreeNode(num);
                    return travNode;
                }
                P108AddNode(travNode.right, num);
            }
            else
            {
                if (travNode.left == null)
                {
                    travNode.left = new TreeNode(num);
                    return travNode;
                }
                P108AddNode(travNode.left, num);
            }
            Console.WriteLine($"something's wrong: travValue: {travNode.val}, num: {num}");
            return travNode;
        }

        private IList<string> LC257BinaryTreePaths(TreeNode root)
        {
            // LeetCode Problem 257 Binary Tree Paths
            var resultList = new List<string>();
            var tempList = new Stack<int>();

            LCP257BuildTree(root, resultList, tempList);

            return resultList;
        }

        private void LCP257BuildTree(TreeNode node, List<string> resultList, Stack<int> tempStack)
        {
            tempStack.Push(node.val);

            if (node.left == null && node.right == null)
            {
                var intArray = tempStack.ToArray().Reverse().ToArray();
                var branch = string.Join("->", intArray);
                resultList.Add(branch);
                tempStack.Pop();
                return;
            }
            if (node.left != null)
                LCP257BuildTree(node.left, resultList, tempStack);
            if (node.right != null)
                LCP257BuildTree(node.right, resultList, tempStack);
            tempStack.Pop();
        }

        private bool LCP290WordPattern(string pattern, string s)
        {
            //LeetCode Problem 290 Word Pattern
            // O(pattern + s)
            var splitTest = s.Split(' ').Where(x => x != "").Select(x => x);
            var splitTestCount = splitTest.Count();

            if (splitTest.Count() != pattern.Length) return false;

            var wordMap = new Dictionary<char, string>();
            int start = 0;
            int end = 0;
            s += " ";


            // find first space
            while (s[start] == ' ') start++;
            end = start;

            for (int i = 0; i < pattern.Length; i++)
            {
                // find next
                while (s[end] != ' ')
                {
                    end++;
                }

                if (wordMap.ContainsKey(pattern[i]))
                {
                    if (wordMap[pattern[i]] != s.Substring(start, end - start))
                    {
                        return false;
                    }
                    // else valid because it's a valid entry in the map
                }
                else if (wordMap.ContainsValue(s.Substring(start, end - start)))
                {
                    return false;
                }
                else wordMap.Add(pattern[i], s.Substring(start, end - start));

                end++;
                start = end;
            }
            if (wordMap.Count != pattern.Length) return false;
            return true;
        }


        public bool LC383RansomNote(string ransomNote, string magazine)
        {
            // LeetCode Practice RansomNote
            // O(2n)
            // key ransom letter, value count
            var ransomMap = new Dictionary<char, int>();

            for (int i = 0; i < magazine.Length; i++)
            {
                if (ransomMap.ContainsKey(magazine[i]))
                {
                    ransomMap[magazine[i]]++;
                }
                else
                    ransomMap.Add(magazine[i], 1);
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                // doesn't exist in map
                if (!ransomMap.ContainsKey(ransomNote[i])) return false;
                // no characters left
                if (ransomMap[ransomNote[i]] <= 0) return false;

                ransomMap[ransomNote[i]]--;
            }

            // make sure ransomMap is empty

            var count = ransomMap.Where(x => x.Value != 0).Count();

            return true;
        }

        private int LC387FirstUniqChar(string s)
        {
            // LeetCode First Unique Char In a String
            // O(2s)
            // key s character, value count of character
            var temp = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!temp.TryAdd(s[i], 1))
                    temp[s[i]]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (temp[s[i]] == 1) return i;
            }

            return -1;
        }

        private int LC389FindTheDifference(string s, string t)
        {
            // LC389FindTheDifference
            // Leet Code Problem 389 Find the Difference
            // O(2n)
            // Runtime: 144 ms, faster than 29.05% of C# online submissions for Find the Difference.
            // Memory Usage: 38 MB, less than 55.76 % of C# online submissions for Find the Difference.
            var temp = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!temp.TryAdd(s[i], 1))
                    temp[s[i]]++;
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (!temp.ContainsKey(t[i]))
                    return t[i];
                if (temp[t[i]] < 1)
                    return t[i];
                temp[t[i]]--;
            }

            return t[0];
        }
        private IList<string> LC412FizzBuzz(int n)
        {
            // LeetCode Problem 412 Fizz Buzz
            // time O(n) space O(n)
            // Runtime: 207 ms, faster than 38.77% of C# online submissions for Fizz Buzz.
            // Memory Usage: 46.9 MB, less than 74.95% of C# online submissions for Fizz Buzz.
            var answer = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    answer.Add("FizzBuzz");
                else if (i % 3 == 0)
                    answer.Add("Fizz");
                else if (i % 5 == 0)
                    answer.Add("Buzz");
                else answer.Add(i.ToString());
            }
            return answer;
        }
        private int LCP1523CountOdds(int low, int high)
        {
            // leet code #1523 Count Odds
            //time O(high-low) space O(1)
            int oddCount = 0;

            for (; low <= high; low++)
            {
                if (low % 2 != 0) oddCount++;
            }
            return oddCount;
        }
        private double LCP1491Average(int[] salary)
        {
            // leetcode problem 1491 average excluding minimum
            // and maximum salary
            // time O(n) space O(1)
            double sum = 0;
            if (salary.Length == 0) return 0;
            double min = salary[0];
            double max = salary[0];

            for (int i = 0; i < salary.Length; i++)
            {
                if (salary[i] < min) min = salary[i];
                if (salary[i] > max) max = salary[i];
                sum += salary[i];
            }

            double result = (sum - min - max) / (salary.Length - 2);
            return result;
        }

        private bool LC392IsSubsequence(string s, string t)
        {
            // LeetCode 392 Is Subsequence
            // O(s+t)
            //Runtime: 87 ms, faster than 69.40% of C# online submissions for Is Subsequence.
            //Memory Usage: 36.7 MB, less than 43.13% of C# online submissions for Is Subsequence.
            if (s.Length > t.Length) return false;
            if (s.Length == 0) return true;
            int subi = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (s[subi] == t[i]) subi++;
                if (subi >= s.Length) return true;
            }
            if (subi == s.Length) return true;
            else return false;
        }

        private int LCP121MaxProfit(int[] prices)
        {
            // LeetCode 121 Best Time to Buy and Sell Stock
            // time O(n) space O(1)
            // Runtime: 254 ms, faster than 78.71% of C# online submissions for Best Time to Buy and Sell Stock.
            // Memory Usage: 46.3 MB, less than 83.74% of C# online submissions for Best Time to Buy and Sell Stock.
            int maxProfit = 0;
            int localMinI = 0;
            if (prices.Length == 0) return 0;

            for (int i = 0; i < prices.Length - 1; i++)
            {
                if (prices[localMinI] > prices[i])
                    localMinI = i;
                if (prices[i + 1] - prices[localMinI] > maxProfit)
                    maxProfit = prices[i + 1] - prices[localMinI];
            }

            return maxProfit;
        }
        private int LCP409LongestPalindrome(string s)
        {
            // LeetCode problem 409. Longest Palindrome
            // time O(2s) space O(s)
            // Runtime: 92 ms, faster than 43.38% of C# online submissions for Longest Palindrome.
            // Memory Usage: 35 MB, less than 48.68% of C# online submissions for Longest Palindrome.
            var temp = new Dictionary<char, int>();
            var count = 0;
            var middle = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (!temp.TryAdd(s[i], 1))
                    temp[s[i]]++;
            }

            for (int i = 0; i < temp.Count; i++)
            {
                if (temp.ElementAt(i).Value % 2 == 1)
                {
                    middle = true;
                    temp[temp.ElementAt(i).Key]--;
                }
                count += temp.ElementAt(i).Value;
            }
            if (middle == true) count++;
            return count;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
