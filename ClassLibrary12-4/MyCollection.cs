using ClassLibrary12_4.Lab12_4;
using ClassLibraryLab10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary12_4
{
    public class MyCollection<T> : MyHashTable<T>, IEnumerable<T>, ICollection<T> where T : IInit, IComparable, ICloneable, new()
    {
        public MyCollection() : base() { }
        public MyCollection(int size) : base(size) { }
        public MyCollection(MyCollection<T> collection)
        {
            table = new T[collection.Capacity];
            check = new bool[collection.Capacity];
            fillRatio = collection.fillRatio;
            for (int i = 0; i < Capacity; i++)
            {
                if (collection.table[i] != null)
                {
                    table[i] = (T)collection.table[i].Clone();
                }
            }
        }

        bool isReadOnly;

        public bool IsReadOnly
        {
            get => isReadOnly;
            set => isReadOnly = value;
        }

        public void Add(T item)
        {
            if (isReadOnly) return;
            AddItem(item);
        }

        public void Clear()
        {
            if (isReadOnly) return;
            table = new T[10];
            check = new bool[0];
            count = 0;
        }

        public bool Contains(T item)
        {
            return Contain(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int j = 0;
            for (int i = arrayIndex; i < Capacity; i++)
            {
                if (table[i] != null)
                {
                    array[j++] = table[i];
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (table[i] != null)
                {
                    yield return table[i];
                }
            }
            yield break;
        }

        public bool Remove(T item)
        {
            if (isReadOnly) return false;
            return RemoveItem(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
