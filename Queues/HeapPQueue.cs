using Trees;
namespace Queues
{

    public class MinHeapPQueue
    {
        private MinHeap _heap;

        public MinHeapPQueue(int capacity)
        {
            _heap = new MinHeap(capacity);
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
    public class MaxHeapPQueue
    {
        private MaxHeap _heap;

        public MaxHeapPQueue(int capacity)
        {
            _heap = new MaxHeap(capacity);
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