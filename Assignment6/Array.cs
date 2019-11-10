using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T>: ICollection<T>
    {
        public int Capacity { get; }

        public int Count => _Array.Count;

        public bool IsReadOnly => false;

        private ICollection<T> _Array;

        public Array(int capacity)
        {
            if(capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            Capacity = capacity;
            _Array = new List<T>(capacity);
        }

        public void Add(T item)
        {
            if(item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _Array.Add(item);
        }

        public void Clear()
        {
            _Array.Clear();
        }

        public bool Contains(T item)
        {
            if(_Array.Contains(item))
            {
                return _Array.Contains(item);
            }
            else
            {
                throw new ArgumentException("Array does not contain this item.",nameof(item));
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if(arrayIndex < 0 || arrayIndex > _Array.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            _Array.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            return _Array.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _Array.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
