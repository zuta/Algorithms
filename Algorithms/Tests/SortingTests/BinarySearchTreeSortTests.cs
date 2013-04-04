using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting.SortingAlgorithmsLibrary;

namespace SortingTests
{
    [TestClass]
    public class BinarySearchTreeSortTests : BaseSortTest
    {
        [TestInitialize]
        public void Initialize()
        {
            sorter = new BinarySearchTreeSort<int>();
        }

        [TestMethod]
        public void BinarySearchTreeSortTests_SimpleTest()
        {
            ExecuteSimpleSortTest();
        }

        [TestMethod]
        public void BinarySearchTreeSortTests_RandomLargeTest()
        {
            ExecuteSimpleSortTest();
        }
    }
}
