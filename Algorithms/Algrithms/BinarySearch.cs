using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Algrithms
{
    class BinarySearch
    {
        public static int Search(int[] array, int search)
        {
            int[] searchArray = array;
            int low = 0;
            var high = searchArray.Length - 1;
            int guess, mid;

            while(low <= high)
            {
                mid = (low + high) / 2;
                guess = searchArray[mid];
                if (guess == search)
                    return guess;
                if (guess > search)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return 0;
        }
    }
}
