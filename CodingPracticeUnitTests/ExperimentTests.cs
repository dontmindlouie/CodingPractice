using CodingPracticeService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodingPracticeUnitTests
{
    public class ExperimentTests
    {
        [Fact]
        public string LinqTest()
        {
            var tempIntArray = new int[] { 2, 5, 3, 6, 4 };
            var tempString = "aabcc";
            var tempDictionary = new Dictionary<int, int>() { { 1,5}, { 2, 2}, { 3, 6} }
            var temp = tempIntArray.ElementAt(0);
            tempDictionary.Count();
            var tempKeyValPair = tempDictionary.ElementAt(0);
            var result = tempString.Contains("abc");


            return tempString;
        }
        [Fact]
        public string StringCheck()
        {
            var tempstring = "as-fe! ";
            var temp2 = tempstring.ToCharArray();
            var temp3 = temp2.Where(x => Char.IsLetterOrDigit(x));
            var temp4 = new string(temp3.ToArray());
            return temp4;
        }

        static void combinationUtil(int[] arr, int[] data,
                             int start, int end,
                             int index, int r)
        {
            if (index == r)
            {
                var comboList = new List<int>();
                for (int j = 0; j < r; j++)
                {
                    comboList.Add(data[j]);
                }
                Combos.Add(comboList);
                return;
            }

            // replace index with all
            // possible elements. The
            // condition "end-i+1 >=
            // r-index" makes sure that
            // including one element
            // at index will make a
            // combination with remaining
            // elements at remaining positions
            for (int i = start; i <= end 
                //&& end - i + 1 >= r - index
                      ; i++)
            {
                data[index] = arr[i];
                combinationUtil(arr, data, start: i + 1,
                                end: end, index: index + 1, r);
            }
        }
        [Fact]
        public IList<IList<int>> FindAllCombinations()
        {
            var result = new List<List<int>>();
            var input = new int[] { 3,2,3,2,3 };
            var temp = new int[input.Length];
            var comboSize = 3;

            combinationUtil(arr: input, data: temp, start: 0, end: input.Length - 1, index: 0, comboSize);


            return (IList<IList<int>>)Combos;
        }
        public static List<List<int>> Combos = new List<List<int>>();

        [Fact]
        public int[] TopDownMergeSort()
        {
            var nums = new int[] { 4, 3, 2, 5, 7, 7, 1 };

            TopDownMergeSort_Split(nums, 0, nums.Length - 1);

            Assert.Equal(nums, new int[] { 1, 2, 3, 4, 5, 7, 7 });
            return nums;
        }

        private void TopDownMergeSort_Split(int[] nums, int begini, int endi)
        {
            if (endi - begini <= 0) return;
            var midi = (begini + endi) / 2;
            TopDownMergeSort_Split(nums, begini, midi);
            TopDownMergeSort_Split(nums, midi + 1, endi);
            TopDownMergeSort_Merge(nums, begini, midi, endi);
        }

        private void TopDownMergeSort_Merge(int[] nums, int begini, int midi, int endi)
        {
            int lenA = midi - begini + 1;
            int lenB = endi - midi;

            var numsA = new int[lenA];
            var numsB = new int[lenB];

            Array.Copy(nums, begini, numsA, 0, lenA);
            Array.Copy(nums, midi + 1, numsB, 0, lenB);

            int ai = 0, bi = 0;
            int len = begini;
            while (ai < lenA && bi < lenB)
            {
                if (numsA[ai] < numsB[bi])
                {
                    nums[len] = numsA[ai];
                    ai++;
                }
                else
                {
                    nums[len] = numsB[bi];
                    bi++;
                }
                len++;
            }
            while (ai < lenA)
            {
                nums[len] = numsA[ai];
                ai++;
                len++;
            }
            while (bi < lenB)
            {
                nums[len] = numsB[bi];
                bi++;
                len++;
            }
        }

        [Fact]
        public int[] BottomUpMergeSort()
        {
            var nums = new int[] { 4, 2, 5, 7, 7, 1, 9 };
            var begini = 0;
            var sizeOfHalves = 1;
            while (sizeOfHalves <= nums.Length) 
            {
                while (begini <= nums.Length)
                {
                    BottomUpMergeSort_Merge(begini, sizeOfHalves, nums);
                    begini += 2 * sizeOfHalves;
                }
                sizeOfHalves *= 2;
                begini = 0;
            }
            Assert.Equal(nums, new int[] { 1, 2, 4, 5, 7, 7, 9 });
            return nums;
        }
        void BottomUpMergeSort_Merge(int begini, int sizeOfHalves, int[] nums)
        {
            // 4,3,2,5,7,1
            var halfA = new List<int>();
            var halfB = new List<int>();

            int ai = 0; int bi = 0; int ni = begini;

            while (ai < sizeOfHalves & ni < nums.Length)
            {
                halfA.Add(nums[ni]);
                ai++;
                ni++;
            }
            while (bi < sizeOfHalves & ni < nums.Length)
            {
                halfB.Add(nums[ni]);
                bi++;
                ni++;
            }

            ai = 0; bi = 0; ni = begini;

            while (ai < halfA.Count && bi < halfB.Count)
            {
                if (halfA[ai] < halfB[bi])
                {
                    nums[ni] = halfA[ai];
                    ai++;
                }
                else
                {
                    nums[ni] = halfB[bi];
                    bi++;
                }
                ni++;
            }
            while (ai < halfA.Count)
            {
                nums[ni] = halfA[ai];
                ai++;
                ni++;
            }
            while (bi < halfB.Count)
            {
                nums[ni] = halfB[bi];
                bi++;
                ni++;
            }
        }
        [Fact]
        public void ArrayTest()
        {
            var rng = new Random();
            var arrayTest = new int[] { 3, 6, 2, 5, 7 };
            var rngint = rng.Next(0, 4);
            var asdf = 45 / 3;
            var threepow = Math.Pow(3, 5);
            Array.Sort(arrayTest);
        }
        [Fact]
        public void ModTest()
        {
            var rng = new Random();
            var rngint = rng.Next(0, 4);
            var test1 = 17 % 2;
            var test2 = 17 % 3;
            var test3 = 17 % 4;
            var test4 = 17 % 5;

        }
        [Fact]
        public void StackTest()
        {
            var testStack = new Stack<int>();
            testStack.Push(1);
            var stackCount = testStack.Count;
        }

        [Fact]
        public void IntStringConversions()
        {
            var testInt1 = 19;
            var testChar = '5';
            var intString = testInt1.ToString();
            var charArray = intString.ToCharArray();
            Array.Reverse(charArray);
            var reversed = int.Parse(charArray);
            var intParse = int.Parse(intString);
            var singleChar = int.Parse(new char[] { testChar });
        }

        [Fact]
        public void BitWiseShiftTest()
        {
            int testInt1 = 11;
            var testBit1 = Convert.ToString(testInt1, 2); // 1011
            int testInt2 = 9;
            var testBit2 = Convert.ToString(testInt2, 2); // 1001
            var testInt3 = -2147483648;
            var testBit3 = Convert.ToString(testInt3, 2);

            int initial = 1;

            initial = initial << 1 | 1;


            var asdf = "10000000000000000000000000000000".ToCharArray().Length;

            var result1 = testInt1 << 1;
            var result2 = testInt1 >> 1;

            var result3 = GetBit(testInt1, 3);
            var result4 = SetBit(testInt1, 1, 2);
            var result5 = SetBit(testInt1, 0, 1);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Value to evaluate</param>
        /// <param name="position">Position from the right of <paramref name="value"/>. Start from 0</param>
        /// <returns></returns>
        public int GetBit(int value, int position)
        {
            return (value >> position) & 1;
        }
        public int SetBit(int valToEval, int setValue, int position)
        {
            int result = valToEval;
            var shift = 1 << position;

            if (setValue == 1)
                result = result | (1 << position); // 1011 | 0100 = 1111
            else if (setValue == 0)
                result = result & (1 << position); // 1011 & 1101 = 1001
            return result;
        }


        [Fact]
        public void BitWiseOrTest()
        {
            int testInt1 = 5;
            int testInt2 = 3;

            var result = testInt1 | testInt2; // 101 | 011 = 111
            var result3 = testInt1 & testInt2; // 101 & 011 = 001
            var result4 = testInt1 ^ testInt2; // 101 ^ 011 = 110
            var result5 = ~testInt1; // ~101 = 10


            return;
        }

        [Fact]
        public void XorTest()
        {
            var testTrue = true;
            var testFalse = false;

            testTrue ^= true;
            testTrue ^= false;
            testFalse ^= true;
            testFalse ^= false;

            var zero = 0;
            zero ^= 0;
            zero = 0;
            zero ^= 1;

            var one = 1;
            one ^= 0;
            one = 1;
            one ^= 1;

            var two = 2;
            two ^= 2;

        }
        [Fact]
        //[InlineData(new ListNode(1, new ListNode(1)), new ListNode(1, new ListNode(2))]
        //[InlineData("}", false)]
        public void TestSomething()//(ListNode list1, ListNode list2)
        {
            var balls = new string[] { "R", "B", "Y", "G" };
            var K = 6;
            var someone = new Someone();
            var pattern = "aa";
            var s = "aab";
            //var s2 = "ymbgaraibkfmvocpizdydugvalagaivdbfsfbepeyccqfepzvtpyxtbadkhmwmoswrcxnargtlswqemafandgkmydtimuzvjwxvlfwlhvkrgcsithaqlcvrihrwqkpjdhgfgreqoxzfvhjzojhghfwbvpfzectwwhexthbsndovxejsntmjihchaotbgcysfdaojkjldprwyrnischrgmtvjcorypvopfmegizfkvudubnejzfqffvgdoxohuinkyygbdzmshvyqyhsozwvlhevfepdvafgkqpkmcsikfyxczcovrmwqxxbnhfzcjjcpgzjjfateajnnvlbwhyppdleahgaypxidkpwmfqwqyofwdqgxhjaxvyrzupfwesmxbjszolgwqvfiozofncbohduqgiswuiyddmwlwubetyaummenkdfptjczxemryuotrrymrfdxtrebpbjtpnuhsbnovhectpjhfhahbqrfbyxggobsweefcwxpqsspyssrmdhuelkkvyjxswjwofngpwfxvknkjviiavorwyfzlnktmfwxkvwkrwdcxjfzikdyswsuxegmhtnxjraqrdchaauazfhtklxsksbhwgjphgbasfnlwqwukprgvihntsyymdrfovaszjywuqygpvjtvlsvvqbvzsmgweiayhlubnbsitvfxawhfmfiatxvqrcwjshvovxknnxnyyfexqycrlyksderlqarqhkxyaqwlwoqcribumrqjtelhwdvaiysgjlvksrfvjlcaiwrirtkkxbwgicyhvakxgdjwnwmubkiazdjkfmotglclqndqjxethoutvjchjbkoasnnfbgrnycucfpeovruguzumgmgddqwjgdvaujhyqsqtoexmnfuluaqbxoofvotvfoiexbnprrxptchmlctzgqtkivsilwgwgvpidpvasurraqfkcmxhdapjrlrnkbklwkrvoaziznlpor"
            //; var t2 = "qhxepbshlrhoecdaodgpousbzfcqjxulatciapuftffahhlmxbufgjuxstfjvljybfxnenlacmjqoymvamphpxnolwijwcecgwbcjhgdybfffwoygikvoecdggplfohemfypxfsvdrseyhmvkoovxhdvoavsqqbrsqrkqhbtmgwaurgisloqjixfwfvwtszcxwktkwesaxsmhsvlitegrlzkvfqoiiwxbzskzoewbkxtphapavbyvhzvgrrfriddnsrftfowhdanvhjvurhljmpxvpddxmzfgwwpkjrfgqptrmumoemhfpojnxzwlrxkcafvbhlwrapubhveattfifsmiounhqusvhywnxhwrgamgnesxmzliyzisqrwvkiyderyotxhwspqrrkeczjysfujvovsfcfouykcqyjoobfdgnlswfzjmyucaxuaslzwfnetekymrwbvponiaojdqnbmboldvvitamntwnyaeppjaohwkrisrlrgwcjqqgxeqerjrbapfzurcwxhcwzugcgnirkkrxdthtbmdqgvqxilllrsbwjhwqszrjtzyetwubdrlyakzxcveufvhqugyawvkivwonvmrgnchkzdysngqdibhkyboyftxcvvjoggecjsajbuqkjjxfvynrjsnvtfvgpgveycxidhhfauvjovmnbqgoxsafknluyimkczykwdgvqwlvvgdmufxdypwnajkncoynqticfetcdafvtqszuwfmrdggifokwmkgzuxnhncmnsstffqpqbplypapctctfhqpihavligbrutxmmygiyaklqtakdidvnvrjfteazeqmbgklrgrorudayokxptswwkcircwuhcavhdparjfkjypkyxhbgwxbkvpvrtzjaetahmxevmkhdfyidhrdeejapfbafwmdqjqszwnwzgclitdhlnkaiyldwkwwzvhyorgbysyjbxsspnjdewjxbhpsvj"
            //; 
            var s1 = "";
            var t1 = "ahbgdc";
            someone.DoSomething(s1, t1);

            //Assert.Equal(expected, actual);
        }
    }
}
