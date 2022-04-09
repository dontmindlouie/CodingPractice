using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPracticeService.ClassProblems
{
    class P225MyStack
    {
        // Leetcode 225. Implement Stack using Queues
        public Queue<int> queue;
        public P225MyStack()
        {
            queue = new Queue<int>();
        }

        public void Push(int x)
        {
            queue.Enqueue(x);
        }

        public int Pop()
        {
            var tempQueue = new Queue<int>();
            while (queue.Count > 1)
            {
                tempQueue.Enqueue(queue.Dequeue());
            }
            var popVal = queue.Dequeue();
            queue = tempQueue;
            return popVal;
        }

        public int Top()
        {
            var tempQueue = new Queue<int>();
            while (queue.Count > 1)
            {
                tempQueue.Enqueue(queue.Dequeue());
            }
            var popVal = queue.Dequeue();
            tempQueue.Enqueue(popVal);
            queue = tempQueue;
            return popVal;
        }

        public bool Empty()
        {
            if (queue.Count == 0) return true;
            return false;
        }

    }
}
