using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPracticeService.ClassProblems
{
    class P232MyQueue
    {

        public Stack<int> myStack;

        public P232MyQueue()
        {
            myStack = new Stack<int>();
        }

        public void Push(int x)
        {
            myStack.Push(x);
        }

        public int Pop()
        {
            var tempStack = new Stack<int>();
            var myStackCount = myStack.Count;
            for (int i = 0; i < myStackCount - 1; i++)
            {
                tempStack.Push(myStack.Pop());
            }
            var popVal = myStack.Pop();
            var tempStackCount = tempStack.Count;
            for (int i = 0; i < tempStackCount; i++)
            {
                myStack.Push(tempStack.Pop());
            }
            return popVal;
        }

        public int Peek()
        {
            var tempStack = new Stack<int>();
            var myStackCount = myStack.Count;
            for (int i = 0; i < myStackCount - 1; i++)
            {
                tempStack.Push(myStack.Pop());
            }
            var popVal = myStack.Pop();
            tempStack.Push(popVal);
            var tempStackCount = tempStack.Count;
            for (int i = 0; i < tempStackCount; i++)
            {
                myStack.Push(tempStack.Pop());
            }
            return popVal;
        }

        public bool Empty()
        {
            if (myStack.Count == 0) return true;
            return false;
        }
    }
}
