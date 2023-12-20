using System;
using System.Collections.Generic;

namespace Algoritmos
{
    public static class BubbleSort
    {
        public static T[] Sort<T>(T[] arr) where T : IComparable<T>
        {
            var comparer = Comparer<T>.Default;

            for (int i = arr.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    bool greaterThan =
                        comparer.Compare(arr[j], arr[j+1]) == 1;

                    if (greaterThan)
                    {
                        T temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
    }
}