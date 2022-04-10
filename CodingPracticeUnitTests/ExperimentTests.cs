using CodingPracticeService;
using System;
using System.Collections;
using Xunit;

namespace CodingPracticeUnitTests
{
    public class ExperimentTests
    {

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
            var testBit1 = Convert.ToString(testInt1,2); // 1011
            int testInt2 = 9;
            var testBit2 = Convert.ToString(testInt2, 2); // 1001
            var testInt3 = -2147483648;
            var testBit3 = Convert.ToString(testInt3, 2);

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
