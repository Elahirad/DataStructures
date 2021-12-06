using System;
using System.Text;

namespace CustomStack
{
    public class CustomStack
    {
        private readonly int[] _arr;
        private int _count;

        public CustomStack(int len)
        {
            _arr = new int[len];
            _count = 0;
        }

        public void Push(int item)
        {
            if (_count == _arr.Length) throw new StackOverflowException();
            _arr[_count] = item;
            _count++;
        }

        public int Pop()
        {
            if (_count == 0) throw new InvalidOperationException("Stack is empty");
            return _arr[--_count];
        }

        public int Peek()
        {
            if (_count == 0) throw new InvalidOperationException("Stack is empty");
            return _arr[_count - 1];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public override string ToString()
        {
            var strB = new StringBuilder();
            for (var i = 0; i < _count; i++)
            {
                strB.Append(_arr[i] + " ");
            }

            return strB.ToString();
        }
    }
}