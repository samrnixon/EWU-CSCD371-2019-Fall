using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment6
{
    public class Array<T>: ICollection<T>
    {
        public int Capacity { get; }

        private ICollection<T> _Array;

        public int Count => _Array.Count;

        public bool IsReadOnly => true; //I want to make sure it cannot be written to from someone else. Making it read only for security

        public Array(int capacity)
        {
            if(capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            Capacity = capacity;
            _Array = new List<T>(capacity);
        }

        public T this[int i]
        {
            get => _Array.ElementAt(i);
            //Do I need a set in this case?
        }

        public void Add(T item)
        {
            if(item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if(Count == Capacity)
            {
                throw new ArgumentOutOfRangeException(nameof(item));
            }

            _Array.Add(item);
        }

        public void Clear()
        {
            _Array.Clear();
        }

        public bool Contains(T item)
        {
            if(item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (!(_Array.Contains(item)))
            {
                throw new ArgumentException("Item does not exist in Array");
            }
            return _Array.Contains(item);
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
