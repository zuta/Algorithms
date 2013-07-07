using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting.SortingAlgorithmsLibrary;

namespace SortingTests
{
    [TestClass]
    public class PancakeSortTests : BaseQuadraticSortTest
    {
        [TestInitialize]
        public void Initialize()
        {
            this.sorter = new PancakeSort<int>();
        }

        [TestMethod]
        [TestCategory("Quadratic Sorts")]
        public void PancakeSortTests_SimpleTest()
        {
            ExecuteSimpleSortTest();
        }

        [TestMethod]
        [TestCategory("Quadratic Sorts")]
        public void PancakeSortTests_RandomLargeTest()
        {
            ExecuteRandomLargeSortTest();
        }
    }
}
