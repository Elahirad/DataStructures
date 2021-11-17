using System;

namespace CustomArray
{
    public class CustomArray
    {
        private object[] _array;
        private int _insertedCount;
        public CustomArray(int length)
        {
            _array = new object[length];
            _insertedCount = 0;
        }

        public void Insert(object item)
        {
            if (_insertedCount < _array.Length)
            {
                _array[_insertedCount++] = item;
            }
            else
            {
                var newArr = new object[_insertedCount*2];
                for (var i = 0; i < _insertedCount; i++)
                {
                    newArr[i] = _array[i];
                }

                newArr[_insertedCount++] = item;
                _array = newArr;
            }
        }

        public void Remove(int index)
        {
            _insertedCount--;
            for (var i = index; i < _insertedCount; i++)
            {
                _array[i] = _array[i + 1];
            }
        }

        public int IndexOf(object item)
        {
            for (int i = 0; i < _insertedCount; i++)
            {
                if (_array[i].Equals(item)) return i;

            }

            return -1;
        }

        public void Print()
        {
            for (var i = 0; i < _insertedCount; i++)
            {
                Console.WriteLine(_array[i]);
            }
        }
    }
}