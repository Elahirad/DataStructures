using System.Collections.Generic;
using System.Text;

namespace StringReverser
{
    public class StringReverser
    {
        public string Reverse(string input)
        {
            var stack = new Stack<char>();
            var output = new StringBuilder();
            foreach (var c in input)
            {
                stack.Push(c);
            }

            while (stack.Count > 0)
            {
                output.Append(stack.Pop());
            }

            return output.ToString();
        }
    }
}