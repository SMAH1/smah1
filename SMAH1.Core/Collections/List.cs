using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace SMAH1.Collections
{
    /// <summary>
    /// Wrapper over System.Collections.Generic.List<T>.When size changed, raise event
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class List<T> : IEnumerable<T>, IEnumerable, IList<T>, IEnumCount<T>
    {
        private System.Collections.Generic.List<T> list;

        public List() { list = new System.Collections.Generic.List<T>(); }
        public List(IEnumerable<T> collection) { list = new System.Collections.Generic.List<T>(collection); }
        public List(int capacity) { list = new System.Collections.Generic.List<T>(capacity); }

        public int Capacity { get { return list.Capacity; } set { list.Capacity = value; } }
        public int Count { get { return list.Count; } }
        public T this[int index] { get { return list[index]; } set { list[index] = value; } }
        public void Add(T item) { list.Add(item); OnCountChanged(); }
        public void AddRange(IEnumerable<T> collection) { list.AddRange(collection); OnCountChanged(); }
        public ReadOnlyCollection<T> AsReadOnly() { return list.AsReadOnly(); }
        public int BinarySearch(T item) { return list.BinarySearch(item); }
        public int BinarySearch(T item, IComparer<T> comparer) { return list.BinarySearch(item, comparer); }
        public int BinarySearch(int index, int count, T item, IComparer<T> comparer) { return list.BinarySearch(index, count, item, comparer); }
        public void Clear() { list.Clear(); OnCountChanged(); }
        public bool Contains(T item) { return list.Contains(item); }
        public void CopyTo(T[] array) { list.CopyTo(array); }
        public void CopyTo(int index, T[] array, int arrayIndex, int count) { list.CopyTo(index, array, arrayIndex, count); }
        public bool Exists(Predicate<T> match) { return list.Exists(match); }
        public T Find(Predicate<T> match) { return list.Find(match); }
        public int FindIndex(Predicate<T> match) { return list.FindIndex(match); }
        public int FindIndex(int startIndex, Predicate<T> match) { return list.FindIndex(startIndex, match); }
        public int FindIndex(int startIndex, int count, Predicate<T> match) { return list.FindIndex(startIndex, count, match); }
        public T FindLast(Predicate<T> match) { return list.FindLast(match); }
        public int FindLastIndex(Predicate<T> match) { return list.FindLastIndex(match); }
        public int FindLastIndex(int startIndex, Predicate<T> match) { return list.FindLastIndex(startIndex, match); }
        public int FindLastIndex(int startIndex, int count, Predicate<T> match) { return list.FindLastIndex(startIndex, count, match); }
        public void ForEach(Action<T> action) { list.ForEach(action); }
        public System.Collections.Generic.List<T>.Enumerator GetEnumerator() { return list.GetEnumerator(); }
        public int IndexOf(T item, int index) { return list.IndexOf(item, index); }
        public int IndexOf(T item, int index, int count) { return list.IndexOf(item, index, count); }
        public void Insert(int index, T item) { list.Insert(index, item); OnCountChanged(); }
        public void InsertRange(int index, IEnumerable<T> collection) { list.InsertRange(index, collection); OnCountChanged(); }
        public int LastIndexOf(T item) { return list.LastIndexOf(item); }
        public int LastIndexOf(T item, int index) { return list.LastIndexOf(item, index); }
        public int LastIndexOf(T item, int index, int count) { return list.LastIndexOf(item, index, count); }
        public bool Remove(T item) { bool ret = list.Remove(item); OnCountChanged(); return ret; }
        public int RemoveAll(Predicate<T> match) { int ret = list.RemoveAll(match); OnCountChanged(); return ret; }
        public void RemoveAt(int index) { list.RemoveAt(index); OnCountChanged(); }
        public void RemoveRange(int index, int count) { list.RemoveRange(index, count); OnCountChanged(); }
        public void Reverse() { list.Reverse(); }
        public void Reverse(int index, int count) { list.Reverse(index, count); }
        public void Sort() { list.Sort(); }
        public void Sort(Comparison<T> comparison) { list.Sort(comparison); }
        public void Sort(IComparer<T> comparison) { list.Sort(comparison); }
        public void Sort(int index, int count, IComparer<T> comparer) { list.Sort(index, count, comparer); }
        public T[] ToArray() { return list.ToArray(); }
        public void TrimExcess() { list.TrimExcess(); }
        public bool TrueForAll(Predicate<T> match) { return list.TrueForAll(match); }

        #region Custom Events
        public event EventHandler CountChanged;

        private void OnCountChanged()
        {
            EventHandler handler = CountChanged;
            handler?.Invoke(this, new EventArgs());
        }
        #endregion

        #region IEnumerable<T> & IEnumerable & IList<T> & ICollection<T> Members
        IEnumerator<T> IEnumerable<T>.GetEnumerator() { return GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public int IndexOf(T item) { return list.IndexOf(item); }
        public void CopyTo(T[] array, int arrayIndex) { list.CopyTo(array, arrayIndex); }
        public bool IsReadOnly { get { return false; } }
        #endregion
    }
}
