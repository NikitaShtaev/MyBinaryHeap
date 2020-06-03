using MyBinaryHeap.Model;
using System;
using System.Collections.Generic;

namespace MyBinaryHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var lst = new List<int>();
            var heap = new Heap<int>();
            for (int i = 0; i < 1000; i++)
            {
                heap.Add(rnd.Next(-1000, 1000));
            }
            heap.Add(6);
            heap.Add(6);
            heap.Add(6);
            heap.Add(6);
            heap.Add(6);
            heap.Add(6);
            heap.Add(6);
            heap.Add(6);
            foreach (var item in heap)
            {
                lst.Add(Int32.Parse(item.ToString()));
            }
            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
