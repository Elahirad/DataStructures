namespace Queues
{
    public class ArrayQueue
    {
        private int[] _arr;
        private int _f;
        private int _l;

        private int _count;

        public ArrayQueue(int init_size)
        {
            _arr = new int[init_size];
            _f = _l = 0;
            _count = 0;
        }

        public void Enqueue(int item)
        {
            _arr[_l] = item;
            _l = (_l + 1) % _arr.Length;
            _count++;
        }

        public int Dequeue()
        {
            if (_count == 0) throw new InvalidOperationException("Queue is empty");
            var item = _arr[_f];
            _count--;
            _f = (_f + 1) % _arr.Length;
            return item;

        }

        public int Peek()
        {
            if (_count == 0) throw new InvalidOperationException("Queue is empty");
            return _arr[_f];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }
    }
}