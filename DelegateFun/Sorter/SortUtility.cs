using System;

namespace Sorter
{
    public class SortUtility
    {
        public delegate bool Analyze(int x, int y);

        public int[] SelectionSortUtil(int[] intArray, Analyze analyze)
        {
            if (intArray is null || analyze is null)
            {
                throw new ArgumentNullException(nameof(intArray));
            }

            for (int start = 0; start < intArray.Length - 1; start++)
            {
                int min = start;
                for (int search = start + 1; search < intArray.Length; search++)
                {
                    if(analyze(intArray[search],intArray[min]))
                    {
                        min = search;
                    }
                }
                int temp = intArray[min];
                intArray[min] = intArray[start];
                intArray[start] = temp;
            }

            return intArray;
        }

    }
}
