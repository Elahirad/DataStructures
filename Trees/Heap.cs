using System.Text;

namespace Trees
{
    public class MaxHeap
    {
        private int[] _arr;
        private int _count;
        public MaxHeap(int capacity)
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

        public int Remove()
        {
            var item = _arr[0];
            _arr[0] = _arr[--_count];
            if (!IsValidHeap(0)) BubbleDown(0);
            return item;
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

        public static int[] Heapify(int[] array)
        {
            for (var i = array.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(array, i);
            }
            return array;
        }

        private static void Heapify(int[] array, int index)
        {
            int biggerChild;
            if (!HasLeftChild(array, index)) return;
            if (!HasRightChild(array, index)) biggerChild = LeftChildIndex(index);
            else
            {
                biggerChild = array[LeftChildIndex(index)] > array[RightChildIndex(index)]
                ? LeftChildIndex(index)
                : RightChildIndex(index);
            }
            if (array[index] > array[biggerChild]) return;
            Swap(array, index, biggerChild);
            Heapify(array, biggerChild);

        }

        public static bool IsMaxHeap(int[] array)
        {
            return IsMaxHeap(array, 0);
        }

        private static bool IsMaxHeap(int[] array, int index)
        {
            if (!HasLeftChild(array, index)) return true;
            if (!HasRightChild(array, index)) return array[index] >= array[LeftChildIndex(index)];
            return array[index] >= array[LeftChildIndex(index)]
                && array[index] >= array[RightChildIndex(index)]
                && IsMaxHeap(array, LeftChildIndex(index))
                && IsMaxHeap(array, RightChildIndex(index));
        }

        private static void Swap(int[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
        private static bool HasLeftChild(int[] array, int index)
        {
            return LeftChildIndex(index) < array.Length;
        }
        private static bool HasRightChild(int[] array, int index)
        {
            return RightChildIndex(index) < array.Length;
        }
        private static int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }
        private static int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        public static int KThLargestNumber(int[] array, int kth)
        {
            if (kth < 1 || kth > array.Length) throw new InvalidOperationException("Invalid argument");
            int result = 0;
            var heap = new MaxHeap(array.Length);
            foreach (var number in array) heap.Insert(number);
            for (var i = 0; i < kth; i++)
            {
                result = heap.Remove();
            }
            return result;
        }

        public int[] ToArray()
        {
            return _arr;
        }
    }
}