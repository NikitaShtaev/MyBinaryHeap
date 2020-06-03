
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MyBinaryHeap.Model
{
    public class Heap<T> : IEnumerable
        where T: IComparable
    {
        private List<T> Items = new List<T>();
        public int Count => Items.Count;
        
        public Heap(){ }
        public Heap(List<T> items)
        {
            Items.AddRange(items);
        }
        public T Peek()
        {
            if(Count>0)
            {
                return Items[0];
            }
            else
            {
                return default(T);
            }
        }
        public void Add(T item)
        {
            Items.Add(item);
            BalanceHeap();
        }
        public T GetMax()
        {
            var result = Items[0];
            Items[0] = Items[Count - 1];
            Items.RemoveAt(Count - 1);
            Sort(0);
            return result;
        }
        private void Sort(int currentIndex)
        {
            int leftIndex, rightIndex;
            int maxIndex = currentIndex;
            while (currentIndex < Count)
            {
                leftIndex = 2 * currentIndex + 1;
                rightIndex = 2 * currentIndex + 2;
                if (leftIndex < Count && Items[maxIndex].CompareTo(Items[leftIndex]) == -1)
                {
                    maxIndex = leftIndex;
                }
                if (rightIndex < Count && Items[maxIndex].CompareTo(Items[rightIndex]) == -1)
                {
                    maxIndex = rightIndex;
                }
                if(maxIndex == currentIndex)
                {
                    break;
                }
                SwapMethod(currentIndex, maxIndex);
                currentIndex = maxIndex;
            }
        }
        private void BalanceHeap()
        {
            int currentIndex = Count - 1;
            int parantIndex = GetParantIndex(currentIndex);
            while (currentIndex > 0 && Items[parantIndex].CompareTo(Items[currentIndex]) == -1)
            {
                SwapMethod(currentIndex, parantIndex);
                currentIndex = parantIndex;
                parantIndex = GetParantIndex(currentIndex);
            }
        }
        private void SwapMethod(int currentIndex, int parantIndex)
        {
            var temp = Items[currentIndex];
            Items[currentIndex] = Items[parantIndex];
            Items[parantIndex] = temp;
        }
        private int GetParantIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        public IEnumerator GetEnumerator()
        {
            while (Count > 0)
            {
                yield return GetMax();
            }
        }
    }
}
