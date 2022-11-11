using System;
using System.Collections;
using System.Collections.Generic;

namespace Dondoko.Collections
{
    [Serializable]
    public struct LinkedRange<T> : IEnumerable<T>, IEnumerable
    {
        private readonly LinkedListNode<T> _head;
        private readonly LinkedListNode<T> _tail;

        public LinkedRange(LinkedListNode<T> head, LinkedListNode<T> tail)
        {
            if ((head is null) || (tail is null) || (head == tail))
            {
                throw new InvalidOperationException(SR.InvalidOperation_LinkedRangeInvalid);
            }

            _head = head;
            _tail = tail;
        }

        public LinkedListNode<T> Head => _head;

        public LinkedListNode<T> Tail => _tail;

        public bool IsValid => (_head is not null) && (_tail is not null) && (_head != _tail);

        public int Count
        {
            get
            {
                if (!IsValid)
                {
                    return 0;
                }

                int count = 0;
                for (LinkedListNode<T>? current = _head; (current is not null) && (current != _tail); current = current.Next)
                {
                    count++;
                }

                return count;
            }
        }

        public bool Contains(T value)
        {
            for (LinkedListNode<T>? current = _head; (current is not null) && (current != _tail); current = current.Next)
            {
                if (current.Value is null)
                {
                    continue;
                }

                if (current.Value.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public Enumerator GetEnumerator() => new Enumerator(this);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private readonly LinkedRange<T> _range;
            private LinkedListNode<T>? _node;
            private T? _current;

            internal Enumerator(LinkedRange<T> range)
            {
                if (!range.IsValid)
                {
                    throw new InvalidOperationException(SR.InvalidOperation_LinkedRangeInvalid);
                }

                _range = range;
                _node = _range._head;
                _current = default;
            }

            public T Current => _current!;

            object? IEnumerator.Current => _current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if ((_node is null) || (_node == _range._tail))
                {
                    return false;
                }

                _current = _node.Value;
                _node = _node.Next;

                return true;
            }

            void IEnumerator.Reset()
            {
                _node = _range._head;
                _current = default;
            }
        }
    }
}