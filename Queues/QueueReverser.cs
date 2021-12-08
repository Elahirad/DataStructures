namespace Queues
{
    public class QueueReverser{
        public void Reverse(Queue<int> q)
        {
            var stack = new Stack<int>();
            while (q.Count > 0)
            {
                stack.Push(q.Dequeue());
            }
            while (stack.Count > 0)
            {
                q.Enqueue(stack.Pop());
            }
        }
    }
}