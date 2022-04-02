using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPracticeService.ClassProblems

{
    public class P155MinStack
    {
        // LeetCode 155. Min Stack
        // Runtime: 155 ms, faster than 70.79% of C# online submissions for Min Stack.
        // Memory Usage: 46.5 MB, less than 87.45% of C# online submissions for Min Stack.
        private Stack<int> stack = new Stack<int>();
        private int? min = null;

        public void Push(int val)
        {
            stack.Push(val);
            if (min == null) min = val;
            if (val < min) min = val;
        }
        public void Pop()
        {
            stack.Pop();
            if (stack.Count == 0)
            {
                min = null;
                return;
            }
            var tempStack = stack.ToArray();
            min = tempStack.Min();
        }
        public int Top()
        {
            return stack.Peek();
        }
        public int GetMin() => (Int32)min;
    }
}
