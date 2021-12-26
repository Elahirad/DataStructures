using Trees;
namespace Queues
{
    public class HeapPQueue
    {
        private Heap _heap;

        public HeapPQueue(int capacity)
        {
            _heap = new Heap(capacity);
        }

        public void Enqueue(int item)
        {
            _heap.Insert(item);
        }

        public int Dequeue()
        {
            return _heap.Remove();
        }

        public bool IsFull()
        {
            return _heap.IsFull();
        }

        public bool IsEmpty()
        {
            return _heap.IsEmpty();
        }
    }
}