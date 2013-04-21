using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting.SortingAlgorithmsLibrary;

namespace SortingTests
{
    [TestClass]
    public class QuickSortTests : BaseSortTest
    {
        [TestInitialize]
        public void Initialize()
        {
            sorter = new QuickSort<int>();
        }

        [TestMethod]
        public void QuickSortTests_SimpleTest()
        {
            ExecuteSimpleSortTest();
        }

        [TestMethod]
        public void QuickSortTests_RandomLargeTest()
        {
            ExecuteRandomLargeSortTest();
        }
    }
}
