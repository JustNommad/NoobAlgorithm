using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Algrithms
{
    class SelectionSort
    {
        private int findSmallest(List<int> arr)
        {
            int smallest = arr[0];
            int smallest_index = 0;

            for(int i = 0; i < arr.Count; i++)
            {
                if(arr[i] < smallest)
                {
                    smallest = arr[i];
                    smallest_index = i;
                }
            }
            return smallest_index;
        }
        public int[] selectionSort(int[] arr)
        {
            List<int> list = new List<int>(arr);
            int[] array = new int[arr.Length];

            for(int i = 0; i < arr.Length; i++)
            {
                int smallest = findSmallest(list);
                array[i] = list[smallest];
                list.RemoveAt(smallest);
            }
            return array;
        }

    }
}
