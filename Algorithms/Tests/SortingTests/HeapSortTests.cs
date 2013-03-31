using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting.SortingAlgorithmsLibrary;

namespace SortingTests
{
    [TestClass]
    public class HeapSortTests : BaseSortTest
    {
        [TestInitialize]
        public void Initialize()
        {
            sorter = new HeapSort<int>();
        }

        [TestMethod]
        public void HeapSortTests_SimpleTest()
        {
            // arrange
            PrepareSimpleSortTest();
            // act
            sorter.Sort(array);
            // assert
            CheckResult();
        }

        [TestMethod]
        public void HeapSortTests_RandomLargeTest()
        {
            // arrange
            PrepareRandomLargeTest();
            // act
            sorter.Sort(array);
            // arrange
            CheckResult();
        }
    }
}
