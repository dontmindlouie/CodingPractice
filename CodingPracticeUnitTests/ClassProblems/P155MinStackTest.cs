using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CodingPracticeService.ClassProblems;

namespace CodingPracticeUnitTests.ClassProblems
{
    public class P155MinStackTest
    {
        [Fact]
        void MinStackTest()
        {
            //["MinStack","push","push","push","top","pop","getMin","pop","getMin","pop","push","top","getMin","push","top","getMin","pop","getMin"]
            //[[],[2147483646],[2147483646],[2147483647],[],[],[],[],[],[],[2147483647],[],[],[-2147483648],[],[],[],[]]
            P155MinStack obj = new P155MinStack();
            obj.Push(2147483646);
            obj.Push(2147483646);
            obj.Push(2147483647);
            Assert.Equal(obj.Top(), 2147483647);
            obj.Pop();
            Assert.Equal(obj.GetMin(), 2147483646);
            obj.Pop();
            obj.GetMin();
            //"pop","getMin","pop","push","top","getMin","push","top","getMin","pop","getMin"]
        }


    }
}
