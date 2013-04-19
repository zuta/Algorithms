using System;
using Algorithms.Sorting.SortingAlgorithmsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingTests
{
	[TestClass]
	public class BottomUpMergeSortTests : BaseSortTest
	{
		[TestInitialize]
		public void Initialize()
		{
			sorter = new BottomUpMergeSort<int>();
		}

		[TestMethod]
		public void BottomUpMergeSortTests_SimpleTest()
		{
			ExecuteSimpleSortTest();
		}

		[TestMethod]
		public void BottomUpMergeSortTests_RandomLargeTest()
		{
			ExecuteRandomLargeSortTest();
		}
	}
}
