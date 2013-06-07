using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Misc.Median_Of_Two_Sorted_Arrays
{
    class Program
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            int[] a = GenerateSortedArray(2, 10);
            int[] b = GenerateSortedArray(4, 10);
            a = new int[] { 2, 7 };
            b = new int[] { 1, 3, 4, 9 };

            Console.WriteLine("Length of first array \t: {0}", a.Length);
            Console.WriteLine("Length of second array \t: {0}", b.Length);
            PrintArray(a);
            PrintArray(b);

            Console.WriteLine();

            IMedianSeeker bruteForceSeeker = new BruteForceMedianSeeker();
            IMedianSeeker binarySearchSeeker = new BinarySearchMedianSeeker();
            
            DateTime before = DateTime.Now;
            Console.WriteLine("Brute force \t\t: {0}\t{1}", bruteForceSeeker.FindMedian(a, b), DateTime.Now - before);

            before = DateTime.Now;
            Console.WriteLine("Binary search \t\t: {0}\t{1}", binarySearchSeeker.FindMedian(a, b), DateTime.Now - before);

            Console.WriteLine();
        }

        private static void PrintArray(int[] array)
        {
            foreach(int item in array)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
        }

        private static int[] GenerateSortedArray(int n, int max)
        {
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = r.Next(max);
            }

            Array.Sort(result);

            return result;
        }
    }
}
