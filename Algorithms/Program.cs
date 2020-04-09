using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Algrithms;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            string start = "Да";
            while (start.Contains("Да"))
            {
                Console.Clear();
                TestBinarySearch();
                Console.WriteLine("Тест бинарного поиска еще раз?");
                start = Console.ReadLine();
            }
            Console.ReadLine();
        }

        public static void TestBinarySearch()
        {
            int[] array = Initialization();

            Console.Write("Введите искомое число: ");
            var s = Console.ReadLine();

            int answer = BinarySearch.Search(array, int.Parse(s));
            Console.WriteLine(answer);

        }

        public static int[] Initialization()
        {
            int[] array = new int[100];
            Random random = new Random();
            SelectionSort selectionSort = new SelectionSort();

            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(200);

            array = selectionSort.selectionSort(array);

            /*int temp = 0;
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length; j++)
                    if (array[i] < array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
*/
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            return array;
        }
    }
}
