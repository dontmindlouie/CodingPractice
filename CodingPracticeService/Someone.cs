using System.Collections.Generic;

namespace CodingPracticeService
{
    public class Someone
    {
        public Someone()
        {
        }
        public int DoSomething(string s, string t)
        {

            var temp = new Dictionary<char, int>();

            if (s.Length > t.Length) return 3;

            return t[0];
        }
    }
}