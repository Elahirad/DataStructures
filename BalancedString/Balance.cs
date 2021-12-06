using System.Collections.Generic;

namespace IsBalanced
{
    public class Balance
    {

        private readonly List<char> _leftChars = new List<char>() {'(', '{', '[', '<'};
        private readonly List<char> _rightChars = new List<char>() { ')', '}', ']', '>' };

        private bool IsLeftChar(char c)
        {
            return _leftChars.Contains(c);
        }

        private bool IsRightChar(char c)
        {
            return _rightChars.Contains(c);
        }

        private bool DoesMatch(char left, char right)
        {
            return _leftChars.IndexOf(left) == _rightChars.IndexOf(right);
        }
        public bool IsBalanced(string input)
        {
            var stack = new Stack<char>();
            foreach (var c in input)
            {
                if (IsLeftChar(c))
                {
                    stack.Push(c);
                }

                if (IsRightChar(c))
                {
                    if (!(stack.Count > 0)) return false;
                    if (!DoesMatch(c, stack.Pop())) return false;
                }
            }

            return stack.Count <= 0;
        }
    }
}