using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SMAH1.Collections
{
    /// <summary>
    /// Like System.Collections.Generic.List<T> with: 1) Count changed event, 2) Assert in add
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericCollection<T> : IEnumerable<T>, IEnumerable, IList<T>, IEnumCount<T>
    {
        System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T>();

        #region override
        public override string ToString() { return list.ToString(); }
        public override int GetHashCode() { return list.GetHashCode(); }
        #endregion

        #region abstract
        protected abstract bool IsAssertForAdd(T item);
        #endregion

        #region list method & property
        public int Count { get { return list.Count; } }
        public virtual T this[int index]
        {
            get { return list[index]; }
            set
            {
                if (!IsAssertForAdd(value))
                    return;
                list[index] = value;
            }
        }

        public virtual void Add(T item)
        {
            if (IsAssertForAdd(item))
            {
                list.Add(item);
                OnCountChanged();
            }
        }
        public virtual void AddRange(IEnumerable<T> collection)
        {
            foreach (T item in collection)
                if (!IsAssertForAdd(item))
                    return; //Ignore All

            list.AddRange(collection);
            OnCountChanged();
        }
        public virtual void Clear() { list.Clear(); OnCountChanged(); }
        public virtual bool Contains(T item) { return list.Contains(item); }
        public virtual T Find(Predicate<T> match) { return list.Find(match); }
        public virtual System.Collections.Generic.List<T> FindAll(Predicate<T> match) { return list.FindAll(match); }
        public virtual System.Collections.Generic.List<T>.Enumerator GetEnumerator() { return list.GetEnumerator(); }
        public virtual void Insert(int index, T item) { list.Insert(index, item); OnCountChanged(); }
        public virtual bool Remove(T item)
        {
            bool ret = list.Remove(item);
            OnCountChanged();
            return ret;
        }
        public virtual void RemoveAt(int index) { list.RemoveAt(index); OnCountChanged(); }
        public virtual T[] ToArray() { return list.ToArray(); }
        #endregion

        #region IEnumerable<T> & IEnumerable & IList<T> & ICollection<T> Members
        IEnumerator<T> IEnumerable<T>.GetEnumerator() { return GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public int IndexOf(T item) { return list.IndexOf(item); }
        public void CopyTo(T[] array, int arrayIndex) { list.CopyTo(array, arrayIndex); }
        public bool IsReadOnly { get { return false; } }
        #endregion

        #region Custom Events
        public event System.EventHandler CountChanged;

        private void OnCountChanged()
        {
            EventHandler handler = CountChanged;
            handler?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
