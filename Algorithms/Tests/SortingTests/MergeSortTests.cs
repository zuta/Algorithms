using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting.SortingAlgorithmsLibrary;

namespace SortingTests
{
    [TestClass]
    public class MergeSortTests : BaseSortTest
    {
        [TestInitialize]
        public void Initialize()
        {
            sorter = new MergeSort<int>();
        }

        [TestMethod]
        public void MergeSortTests_SimpleTest()
        {
            ExecuteSimpleSortTest();
        }

        [TestMethod]
        public void MergeSortTests_RandomLargeTest()
        {
            ExecuteRandomLargeSortTest();
        }
    }
}
