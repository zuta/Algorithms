using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Algorithms.DataStructure.BinaryHeap.BinaryHeapLibrary;

namespace BinaryHeapTests
{
    [TestClass]
    public class BinaryHeapTests
    {
        private IHeap<int> heap;
        private Comparison<int> comparision;

        [TestInitialize]
        public void Initialize()
        {
            this.comparision = (x, y) => y.CompareTo(x);
            this.heap = new BinaryHeap<int>(comparision);
        }

        [TestMethod]
        public void InsertTest()
        {
            int expectedValue = 10;

            heap.Insert(expectedValue);

            Assert.AreEqual(1, heap.Count);
        }

        [TestMethod]
        public void InsertTest2()
        {
            int[] values = { 1, 2, 10, 24, 12, 44, 10, 5 };

            foreach (int value in values)
            {
                heap.Insert(value);
            }

            Assert.AreEqual(values.Length, heap.Count);
        }

        [TestMethod]
        public void GetTheBestTest()
        {
            int[] values = { 1, 2, 10, 24, 12, 44, 10, 5 };
            int expectedBest = values[0];
            foreach (int value in values)
            {
                if (comparision(value, expectedBest) > 0)
                {
                    expectedBest = value;
                }
                heap.Insert(value);
            }

            Assert.AreEqual(expectedBest, heap.GetTheBest());
        }

        [TestMethod]
        public void DeleteTheBest()
        {
            Random r = new Random();

            List<int> values = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                values.Add(r.Next(100) - r.Next(100));
            }

            foreach (int value in values)
            {
                heap.Insert(value);
            }

            int deleteCount = r.Next(values.Count);

            List<int> sortedValues = values.ToList();
            sortedValues.Sort(comparision);
            sortedValues.Reverse();
            int expectedTheBestValue = sortedValues.Skip(deleteCount).FirstOrDefault();

            for (int i = 0; i < deleteCount; i++)
            {
                Assert.IsTrue(heap.DeleteTheBest());
            }

            Assert.AreEqual(values.Count - deleteCount, heap.Count);
            Assert.AreEqual(expectedTheBestValue, heap.GetTheBest());
        }

        [TestMethod]
        public void DeleteTheBest2()
        {
            Assert.IsFalse(heap.DeleteTheBest());
        }
    }
}