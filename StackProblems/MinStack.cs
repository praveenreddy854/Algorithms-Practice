using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StackProblems
{
    class MinStack
    {
        public Stack<int> stack;
        public Stack<int> minStack;
        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int x)
        {
            stack.Push(x);
            if(minStack.Count == 0 || x <= minStack.Peek())
            {
                minStack.Push(x);
            }
        }

        public void Pop()
        {
            int x = stack.Pop();
            if (minStack.Count > 0 && x == minStack.Peek())
            {
                minStack.Pop();
            }
        }

        public int Top()
        {
            if(stack.Count > 0)
            {
                return stack.Peek();
            }
            return 0;
            
        }

        public int GetMin()
        {
            if (minStack.Count > 0)
            {
                return minStack.Peek();
            }
            return 0;
        }
    }
}
