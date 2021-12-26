using System.Text;

namespace Trees
{
    public class Heap
    {
        private int[] _arr;
        private int _count;
        public Heap(int capacity)
        {
            _arr = new int[capacity];
            _count = 0;
        }

        public void Insert(int item)
        {
            if (IsFull()) throw new InvalidOperationException("Heap is full");
            _arr[_count] = item;
            if (ShouldBubbleUp(_count)) BubbleUp(_count);
            _count++;
        }

        public void Remove()
        {
            _arr[0] = _arr[--_count];
            if (!IsValidHeap(0)) BubbleDown(0);
        }

        private void BubbleDown(int index)
        {
            while (index <= _count && !IsValidHeap(index))
            {
                var biggerChild = BiggerChild(index);
                Swap(index, biggerChild);
                index = biggerChild;
            }
        }

        private int BiggerChild(int index)
        {
            if (!HasLeftChild(index)) return index;
            if (!HasRightChild(index)) return LeftChild(index);
            return _arr[LeftChild(index)] > _arr[RightChild(index)] ? LeftChild(index) : RightChild(index);
        }
        private bool IsValidHeap(int index)
        {
            if (!HasLeftChild(index)) return true;
            if (!HasRightChild(index)) return _arr[index] >= LeftChild(index);
            return _arr[index] >= _arr[LeftChild(index)] && _arr[index] >= _arr[RightChild(index)];
        }

        private int LeftChild(int index)
        {
            return 2 * index + 1;
        }
        private int RightChild(int index)
        {
            return 2 * index + 2;
        }

        private bool HasLeftChild(int index)
        {
            return LeftChild(index) <= _count;
        }
        private bool HasRightChild(int index)
        {
            return RightChild(index) <= _count;
        }
        public bool IsFull()
        {
            return _count == _arr.Length;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }
        private bool ShouldBubbleUp(int index)
        {
            return _arr[(index - 1) / 2] < _arr[index];
        }

        private void BubbleUp(int index)
        {
            while (index > 0 && ShouldBubbleUp(index))
            {
                var parentIndex = (index - 1) / 2;
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void Swap(int first, int second)
        {
            var temp = _arr[first];
            _arr[first] = _arr[second];
            _arr[second] = temp;
        }
    }
}