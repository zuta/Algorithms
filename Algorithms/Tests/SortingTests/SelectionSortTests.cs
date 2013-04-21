using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting.SortingAlgorithmsLibrary;

namespace SortingTests
{
    [TestClass]
    public class SelectionSortTests : BaseQuadraticSortTest
    {
        [TestInitialize]
        public void Initialize()
        {
            this.sorter = new SelectionSort<int>();
        }

        [TestMethod]
        [TestCategory("Quadratic Sorts")]
        public void SelectionSortTests_SimpleTest()
        {
            ExecuteSimpleSortTest();
        }

        [TestMethod]
        [TestCategory("Quadratic Sorts")]
        public void SelectionSortTests_RandomLargeTest()
        {
            ExecuteRandomLargeSortTest();
        }
    }
}
