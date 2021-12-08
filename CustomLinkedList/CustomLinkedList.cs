namespace CLinkedList
{
    public class CustomLinkedList
    {
        private Node _head;
        private Node _tail;
        public int _size;

        public bool IsEmpty => _head == null;

        public CustomLinkedList()
        {
            _size = 0;
        }
        public void AddFirst(object item)
        {
            if (IsEmpty)
            {
                _head = _tail = new Node() { Data = item };
            }
            else
            {
                var data = new Node() { Data = item, Next = _head };
                _head = data;
            }

            _size++;
        }

        public void AddLast(object item)
        {
            var data = new Node() { Data = item };
            if (IsEmpty)
                _head = _tail = data;
            else
            {
                _tail.Next = data;
                _tail = data;
            }

            _size++;
        }

        public void DeleteFirst()
        {
            if (IsEmpty) throw new InvalidOperationException("Linked List is empty!");
            if (_head == _tail)
            {
                _head = _tail = null;
            }
            var newHead = _head.Next;
            _head.Next = null;
            _head = newHead;
            _size--;
        }

        public void DeleteLast()
        {
            if (IsEmpty) throw new InvalidOperationException("Linked List is empty!");
            if (_head == _tail)
            {
                _head = _tail = null;
            }
            var buffer = _head;
            while (true)
            {
                if (buffer.Next.Next == null)
                {
                    buffer.Next = null;
                    _tail = buffer;
                    break;
                }

                buffer = buffer.Next;
            }

            _size--;
        }

        /*public void Reverse() // My first implementation... Bad Idea
        {
            for (var i = _size; i > 0; i--)
            {
                var buffer = _head;
                Node previousItem = null;
                var j = 1;
                while (j < i)
                {
                    previousItem = buffer;
                    buffer = buffer.Next;
                    j++;
                }

                buffer.Next = previousItem;
            }

            var newTail = _head;
            _head = _tail;
            _tail = newTail;
        }*/

        public void Reverse()
        {
            if (IsEmpty) return;
            var first = _head;
            var second = first.Next;
            var third = second.Next;
            while (true)
            {
                if (third == null)
                {
                    second.Next = first;
                    break;
                }
                second.Next = first;
                first = second;
                second = third;
                third = third.Next;
            }
            _head.Next = null;
            var newTail = _head;
            _head = _tail;
            _tail = newTail;
        }
        public bool Contains(object item)
        {
            var buffer = _head;
            while (buffer != null)
            {
                if (buffer.Data.Equals(item)) return true;
                buffer = buffer.Next;
            }

            return false;
        }

        public int IndexOf(object item)
        {
            var buffer = _head;
            var i = 0;
            while (buffer != null)
            {
                if (buffer.Data.Equals(item)) return i;
                buffer = buffer.Next;
                i++;
            }

            return -1;
        }

        public Array ToArray()
        {
            var array = new object[_size];
            var i = 0;
            var buffer = _head;
            while (buffer != null)
            {
                array[i++] = buffer.Data;
                buffer = buffer.Next;
            }

            return array;
        }

        public int Size => _size;

        public object this[int index]
        {
            get
            {
                var buffer = _head;
                for (var i = 0; i < index; i++)
                {
                    buffer = buffer.Next;
                }

                return buffer.Data;
            }
        }
    }
}