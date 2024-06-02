using ClassLibrary12_4;
using ClassLibraryLab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    public class MyObservableCollection<T> : MyCollection<T>, IEnumerable<T>, ICollection<T> where T : IInit, IComparable, ICloneable, new()
    {
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public int Length => table.Length;
        public string Name {  get; set; }

        public MyObservableCollection(string name, int size) : base(size)
        { 
             Name = name;
        }

        public MyObservableCollection() : base()
        {
            Name = "No name";
        }

        public MyObservableCollection(MyObservableCollection<T> collection) : base(collection)
        {
            Name = collection.Name;
        }

        public T this[int index]
        {
            get => table[index];
            set
            {
                ReferenceChanged(this, new CollectionHandlerEventArgs(Name, "Изменение ссылки", value));
                table[index] = value;
            }
        }

        public void OnAddDelete(object source, CollectionHandlerEventArgs args)
        {
            CollectionCountChanged?.Invoke(source, args);
        }

        public void ReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionReferenceChanged?.Invoke(source, args);
        }

        new public bool Remove(T item)
        {
            bool check = base.Remove(item);
            if (check)
            {
                OnAddDelete(this, new CollectionHandlerEventArgs(Name, "Удаление", item));
            }
            return check;
        }
        new public void Add(T item)
        {
            base.Add(item);
            if (!IsReadOnly)
            {
                OnAddDelete(this, new CollectionHandlerEventArgs(Name, "Добавление", item));
            }
        }
    }
}
