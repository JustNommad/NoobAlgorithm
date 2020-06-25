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

            Console.WriteLine("Тест алгоритма обхода в ширину:");
            BreadthFirstSearch bfs = new BreadthFirstSearch();
            Console.WriteLine(bfs.Search());
            Console.ReadLine();

            string start = "Да";
            while (start.Contains("Да"))
            {
                Console.Clear();
                TestBinarySearch();
                Console.WriteLine("Тест бинарного поиска еще раз?");
                start = Console.ReadLine();
            }
            start = "Да";
            while (start.Contains("Да"))
            {
                Console.Clear();
                Console.Write("Введите размер факториала: ");
                int x = int.Parse(Console.ReadLine());
                x = Factorial(x);
                Console.WriteLine("Ответ: {0}", x);
                Console.WriteLine("Провести тест функции факториала еще раз?");
                start = Console.ReadLine();
            }
            start = "Да";
            while (start.Contains("Да"))
            {
                Console.Clear();
                TestQuickSort();
                Console.WriteLine("Тест быстрой сортировки еще раз?");
                start = Console.ReadLine();
            }
            Console.ReadLine();
        }

        public static void TestQuickSort()
        {
            int[] array = Initialization();

            Console.WriteLine("Без сортировки: ");
            PrintArray(array);

            QuickSort.Sort(array);

            Console.WriteLine("После сортировки: ");
            PrintArray(array);
        }

        public static void TestBinarySearch()
        {
            SelectionSort selectionSort = new SelectionSort();
            int[] array = Initialization();

            array = selectionSort.selectionSort(array);
            PrintArray(array);

            Console.Write("Введите искомое число: ");
            var s = Console.ReadLine();

            int answer = BinarySearch.Search(array, int.Parse(s));
            Console.WriteLine(answer);

        }

        public static int[] Initialization()
        {
            int[] array = new int[100];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(200);

            return array;
        }
        public static int Factorial(int x)
        {
            if(x == 1)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}
