using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseSortLibrary;
using HeapSortLibrary;
using System.Linq;
using System.Collections.Generic;

namespace SortingTests
{
    [TestClass]
    public class HeapSortTests
    {
        private ISort<int> sorter;

        [TestInitialize]
        public void Initialize()
        {
            sorter = new HeapSort<int>();
        }

        [TestMethod]
        public void SimpleSortTest()
        {
            int[] array = { 1, 3, 1, 0, 5, 9, 4, 13 };

            int[] expectedArray = { 0, 1, 1, 3, 4, 5, 9, 13 };

            sorter.Sort(array);

            Assert.IsTrue(array.Except(expectedArray).Count() == 0);
            Assert.IsTrue(expectedArray.Except(array).Count() == 0);
        }

        [TestMethod]
        public void RandomSortTest()
        {
            Random r = new Random();
            int n = (r.Next(1000) + 1) * (r.Next(1000) + 1);
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = r.Next(int.MaxValue) - r.Next(int.MaxValue);
            }

            List<int> expected = array.ToList();
            expected.Sort();

            sorter.Sort(array);

            Assert.IsTrue(array.Except(expected).Count() == 0);
            Assert.IsTrue(expected.Except(array).Count() == 0);
        }
    }
}
