namespace Queues
{
    public class StackQueue
    {
        private Stack<int> _first_stack;
        private Stack<int> _second_stack;

        private void MoveStacks()
        {
            while (_first_stack.Count > 0)
            {
                _second_stack.Push(_first_stack.Pop());
            }
        }
        public StackQueue()
        {
            _first_stack = new Stack<int>();
            _second_stack = new Stack<int>();
        }

        public void Enqueue(int item)
        {
            _first_stack.Push(item);
        }

        public int Dequeue()
        {
            if (IsEmpty()) throw new InvalidOperationException("Queue is empty");
            if (_second_stack.Count == 0) MoveStacks();
            return _second_stack.Pop();
        }

        public int Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException("Queue is empty");
            if (_second_stack.Count == 0) MoveStacks();

            return _second_stack.Peek();
        }

        public bool IsEmpty()
        {
            return _first_stack.Count == 0 && _second_stack.Count == 0;
        }
    }
}