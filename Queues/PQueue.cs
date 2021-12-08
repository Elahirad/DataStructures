using System;
using System.Text;
namespace Queues
{
    public class PQueue
    {
        private int[] _arr;
        private int _count;

        public PQueue(int init_size)
        {
            _arr = new int[init_size];
            _count = 0;
        }

        public void Add(int item)
        {
            if (IsFull()) throw new InvalidOperationException("Queue is full");
            if (_count == 0)
            {
                _arr[_count] = item;
            }
            else
            {
                for (var i = _count - 1; i >= 0; i--)
                {
                    _arr[i + 1] = _arr[i];
                    if (item > _arr[i]) { _arr[i + 1] = item; break; }
                }
            }
            _count++;
        }

        public int Remove()
        {
            if (IsEmpty()) throw new InvalidOperationException("Queue is empty");
            return _arr[--_count];
        }

        public bool IsFull()
        {
            return _count == _arr.Length;
        }
        public bool IsEmpty()
        {
            return _count == 0;
        }

        public override string ToString()
        {
            var strB = new StringBuilder();
            strB.Append("[");
            for (var i = 0; i < _count; i++)
            {
                strB.Append($"{_arr[i]}, ");
            }
            strB.Remove(strB.Length - 2, 2);
            strB.Append("]");
            return strB.ToString();

        }
    }
}