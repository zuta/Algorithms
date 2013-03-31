using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting.SortingAlgorithmsLibrary;
using System.Linq;
using System.Collections.Generic;

namespace SortingTests
{
    public abstract class BaseSortTest
    {
        protected ISort<int> sorter;
        protected int[] array;
        protected int[] expectedResult;

        protected void PrepareSimpleSortTest()
        {
            this.array = new int[] { 1, 3, 1, 0, 5, 9, 4, 13 };

            this.expectedResult = new int[] { 0, 1, 1, 3, 4, 5, 9, 13 };
        }

        public void PrepareRandomLargeTest()
        {
            Random r = new Random();

            int n = (r.Next(1000) + 1) * (r.Next(1000) + 1);

            this.array = new int[n];
            this.expectedResult = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = r.Next(int.MaxValue) - r.Next(int.MaxValue);
                expectedResult[i] = array[i];
            }
            
            Array.Sort(expectedResult);
        }

        protected void CheckResult()
        {
            Assert.IsTrue(array.Except(expectedResult).Count() == 0);
            Assert.IsTrue(expectedResult.Except(array).Count() == 0);
        }
    }
}
