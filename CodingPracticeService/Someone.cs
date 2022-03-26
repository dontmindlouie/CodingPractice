using System.Collections.Generic;

namespace CodingPracticeService
{
    internal class Someone
    {
        public Someone()
        {
        }
        public int DoSomething1(string s, string t)
        {

            var temp = new Dictionary<char, int>();

            if (s.Length > t.Length) return 3;

            return t[0];
        }
    }
}