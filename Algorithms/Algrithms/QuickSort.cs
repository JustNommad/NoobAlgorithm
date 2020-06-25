using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Algrithms
{
    class QuickSort
    {
        public static void Sort(int[] arr)
        {
            if(arr.Length < 2)
            { 
                return;
            }
            else if(arr.Length == 2)
            {
                if(arr[0] > arr[1])
                {
                    var temp = arr[0];
                    arr[0] = arr[1];
                    arr[1] = temp;
                }
                return;
            }
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(int[] arr, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
            {
                return;
            }

            var pivotLocation = ChosePivotLocation(leftStart, rightEnd);
            pivotLocation = OrderItemsAroundPivot(arr, leftStart, pivotLocation, rightEnd);
            Sort(arr, leftStart, pivotLocation - 1);
            Sort(arr, pivotLocation + 1, rightEnd);
        }

        private static int OrderItemsAroundPivot(int[] arr, int leftStart, int pivotLocation, int rightEnd)
        {
            var pivot = arr[pivotLocation];
            Swap(arr, pivotLocation, rightEnd);
            var leftIndex = leftStart;
            var rightIndex = rightEnd - 1;
            while (leftIndex <= rightIndex)
            {
                if (arr[leftIndex] <= pivot)
                {
                    leftIndex++;
                    continue;
                }

                if (arr[rightIndex] >= pivot)
                {
                    rightIndex--;
                    continue;
                }

                Swap(arr, leftIndex, rightIndex);
            }

            Swap(arr, rightEnd, leftIndex);
            return leftIndex;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private static int ChosePivotLocation(int leftStart, int rightEnd)
        {
            var middle = leftStart + (rightEnd - leftStart) / 2;
            return middle;
        }
    }
}
