using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPracticeService
{
    class EasyCompletedProblems
    {
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
            return sortedList;
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
        private class ListNode
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
                    int sum = SumSubArray(nums, i, j);
                    if (sum > largestSum) largestSum = sum;
                }
            }
            return largestSum;
        }
        private int SumSubArray(int[] nums, int i, int j)
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
            int needleI = 0;
            int haystackI = 0;

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

        public TreeNode P108SortedArrayToBST(int[] nums)
        {

            int midi = nums.Length / 2;
            var root = new TreeNode(nums[midi]);

            // [-10,-3,0,5,9]

            foreach (var num in nums)
            {
                if (num == nums[midi]) continue;

                var newNode = new TreeNode(num);
                var travNode = root;

                // traverse to correct spot
                P108AddNode(travNode, num);

            }
            return root;
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
