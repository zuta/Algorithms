using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructure.BinarySearchTree.OrderStatisticTreeLibrary;
using System.Collections.Generic;
using Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary;

namespace OrderStatisticTreeTests
{
    [TestClass]
    public class OrderStatisticTreeTests
    {
        [TestMethod]
        public void OrderStatisticTreeTests_FindTheKthSmallestNode()
        {
            IOrderStatisticTree<int, string> tree = new OrderStatisticTree<int, string>();
            tree.Insert(10, "John");
            tree.Insert(5, "Clark");
            tree.Insert(13, "Pitty");
            tree.Insert(17, "Lilly");
            tree.Insert(8, "Jack");
            var expectedNode = tree.Insert(0, "Lui");
            tree.Insert(16, "Petr");

            var actualNode = tree.FindTheKthSmallestNode(0);

            Assert.IsNotNull(actualNode);
            Assert.AreEqual(expectedNode, actualNode);
        }

        [TestMethod]
        public void OrderStatisticTreeTests_FindTheKthSmallestNode2()
        {
            IOrderStatisticTree<int, string> tree = new OrderStatisticTree<int, string>();
            tree.Insert(10, "John");
            var expectedNode = tree.Insert(5, "Clark");
            tree.Insert(13, "Pitty");
            tree.Insert(17, "Lilly");
            tree.Insert(8, "Jack");
            tree.Insert(0, "Lui");
            tree.Insert(16, "Petr");

            var actualNode = tree.FindTheKthSmallestNode(1);

            Assert.IsNotNull(actualNode);
            Assert.AreEqual(expectedNode, actualNode);
        }

        [TestMethod]
        public void OrderStatisticTreeTests_FindTheKthSmallestNode3()
        {
            IOrderStatisticTree<int, string> tree = new OrderStatisticTree<int, string>();
            var expectedNode = tree.Insert(10, "John");
            tree.Insert(5, "Clark");
            tree.Insert(13, "Pitty");
            tree.Insert(17, "Lilly");
            tree.Insert(8, "Jack");
            tree.Insert(0, "Lui");
            tree.Insert(16, "Petr");

            var actualNode = tree.FindTheKthSmallestNode(3);

            Assert.IsNotNull(actualNode);
            Assert.AreEqual(expectedNode, actualNode);
        }

        [TestMethod]
        public void OrderStatisticTreeTests_FindTheKthSmallestNode4()
        {
            IOrderStatisticTree<int, string> tree = new OrderStatisticTree<int, string>();
            tree.Insert(10, "John");
            tree.Insert(5, "Clark");
            tree.Insert(13, "Pitty");
            var expectedNode = tree.Insert(17, "Lilly");
            tree.Insert(8, "Jack");
            tree.Insert(0, "Lui");
            tree.Insert(16, "Petr");

            var actualNode = tree.FindTheKthSmallestNode(6);

            Assert.IsNotNull(actualNode);
            Assert.AreEqual(expectedNode, actualNode);
        }

        [TestMethod]
        public void OrderStatisticTreeTests_Random_FindTheKthSmallestNode()
        {
            Random r = new Random();
            int n = r.Next(10000) + 1;

            IOrderStatisticTree<int, string> tree = new OrderStatisticTree<int, string>();
            List<IBinarySearchTreeNode<int, string>> list = new List<IBinarySearchTreeNode<int, string>>();
            for (int i = 0; i < n; i++)
            {
                int key = r.Next(int.MaxValue);
                list.Add(tree.Insert(key, string.Empty));
            }
            
            list.Sort(new Comparison<IBinarySearchTreeNode<int, string>>((x, y) => x.Key.CompareTo(y.Key)));

            for (int i = 0; i < n / 2; i++)
            {
                int request = r.Next(n);

                var expectedNode = list[request];

                var actualNode = tree.FindTheKthSmallestNode(request);
                
                Assert.IsNotNull(actualNode);
                Assert.AreEqual(expectedNode, actualNode);
            }
        }
    }
}
