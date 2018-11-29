using System;
using System.Collections.Generic;
using System.Text;

namespace LINQAndTesting.Library
{
    public class MyGenericCollection<T> //where T : new()
    {
        protected List<T> _list = new List<T>();

        /*public void AddDefaultValue()
        {
            _list.Add(new T());
        }*/

        public virtual void Add(T item)
        {
            _list.Add(item);
        }

        public void Sort()
        {
            _list.Sort();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }
    }
}
