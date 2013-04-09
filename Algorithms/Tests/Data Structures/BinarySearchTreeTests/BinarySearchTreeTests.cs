using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearchTreeTests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void BinarySearchTreeTests_SearchTest()
        {
            IBinarySearchTree<int, int> tree = new BinarySearchTree<int, int>();

            IBinarySearchTreeNode<int, int> actual = tree.Search(100);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void BinarySearchTreeTests_SimpleTree_SearchTest()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            tree.Insert(10, "John");
            tree.Insert(5, "Clark");
            tree.Insert(13, "Pitty");

            IBinarySearchTreeNode<int, string> actual = tree.Search(5);
            IBinarySearchTreeNode<int, string> actual2 = tree.Search(13);
            IBinarySearchTreeNode<int, string> actual3 = tree.Search(10);
            IBinarySearchTreeNode<int, string> actual4 = tree.Search(0);

            Assert.IsTrue(actual.Key == 5 && actual.Value == "Clark");
            Assert.IsTrue(actual2.Key == 13 && actual2.Value == "Pitty");
            Assert.IsTrue(actual3.Key == 10 && actual3.Value == "John");
            Assert.IsNull(actual4);
        }

        [TestMethod]
        public void BinarySearchTreeTests_InsertTest()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();

            int key = 10;
            string value = "Irsli";

            tree.Insert(key, value);

            Assert.IsTrue(tree.Count == 1);
            Assert.IsNotNull(tree.Search(key));
            Assert.IsTrue(tree.Search(key).Value == value);
        }

        [TestMethod]
        public void BinarySearchTreeTests_InsertTest2()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            tree.Insert(10, "John");
            tree.Insert(5, "Clark");
            tree.Insert(13, "Pitty");

            int key = 103;
            string value = "Irsli";

            tree.Insert(key, value);

            Assert.IsTrue(tree.Count == 4);
            Assert.IsNotNull(tree.Search(key));
            Assert.IsTrue(tree.Search(key).Value == value);
        }

        [TestMethod]
        public void BinarySearchTreeTests_Traverse()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            tree.Insert(10, "John");
            tree.Insert(5, "Clark");
            tree.Insert(13, "Pitty");
            tree.Insert(17, "Lilly");

            IList<IBinarySearchTreeNode<int, string>> inOrderTraversedTree = tree.TraverseInOrder().ToList();

            Assert.IsTrue(inOrderTraversedTree.Count == 4);
            Assert.IsTrue(inOrderTraversedTree[0].Key == 5);
            Assert.IsTrue(inOrderTraversedTree[1].Key == 10);
            Assert.IsTrue(inOrderTraversedTree[2].Key == 13);
            Assert.IsTrue(inOrderTraversedTree[3].Key == 17);
        }

        [TestMethod]
        public void BinarySearchTreeTests_GetHeight()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();

            int height = tree.GetHeight();

            Assert.AreEqual(0, height);
        }

        [TestMethod]
        public void BinarySearchTests_GetHeight2()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            tree.Insert(10, "John");
            tree.Insert(5, "Clark");
            tree.Insert(13, "Pitty");
            tree.Insert(17, "Lilly");

            int height = tree.GetHeight();

            Assert.AreEqual(2, height);
        }

        [TestMethod]
        public void BinarySearchTreeTests_Remove0()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();

            bool actualResult = tree.Remove(10);

            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void BinarySearchTreeTests_Remove1()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            tree.Insert(10, "John");

            bool actualResult = tree.Remove(10);
            var actualKeys = tree.TraverseInOrder().Select(n => n.Key);

            Assert.IsTrue(actualResult);
            Assert.IsTrue(tree.Count == 0);
            Assert.IsTrue(actualKeys.Count() == 0);
        }

        [TestMethod]
        public void BinarySearchTreeTests_Remove2()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            tree.Insert(10, "John");
            tree.Insert(5, "Clark");
            tree.Insert(13, "Pitty");
            tree.Insert(17, "Lilly");

            int[] expectedKeys = { 5, 13, 17 };

            bool actualResult = tree.Remove(10);
            var actualKeys = tree.TraverseInOrder().Select(n => n.Key);

            Assert.IsTrue(actualResult);
            Assert.IsTrue(tree.Count == expectedKeys.Length);
            Assert.IsTrue(expectedKeys.Except(actualKeys).Count() == 0);
            Assert.IsTrue(actualKeys.Except(expectedKeys).Count() == 0);
        }

        [TestMethod]
        public void BinarySearchTreeTests_Remove3()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            tree.Insert(10, "John");
            tree.Insert(5, "Clark");
            tree.Insert(13, "Pitty");
            tree.Insert(17, "Lilly");

            int[] expectedKeys = { 10, 13, 17 };

            bool actualResult = tree.Remove(5);
            var actualKeys = tree.TraverseInOrder().Select(n => n.Key);

            Assert.IsTrue(actualResult);
            Assert.IsTrue(tree.Count == expectedKeys.Length);
            Assert.IsTrue(expectedKeys.Except(actualKeys).Count() == 0);
            Assert.IsTrue(actualKeys.Except(expectedKeys).Count() == 0);
        }

        [TestMethod]
        public void BinarySearchTreeTests_Remove4()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            tree.Insert(10, "John");
            tree.Insert(5, "Clark");
            tree.Insert(13, "Pitty");
            tree.Insert(17, "Lilly");
            tree.Insert(8, "Jack");
            tree.Insert(0, "Lui");
            tree.Insert(16, "Petr");

            int[] expectedKeys = { 8, 10, 16, 17 };

            bool actualResult = tree.Remove(5) && tree.Remove(13) && tree.Remove(0);
            var actualKeys = tree.TraverseInOrder().Select(n => n.Key);

            Assert.IsTrue(actualResult);
            Assert.IsTrue(tree.Count == expectedKeys.Length);
            Assert.IsTrue(expectedKeys.Except(actualKeys).Count() == 0);
            Assert.IsTrue(actualKeys.Except(expectedKeys).Count() == 0);
        }

        [TestMethod]
        public void BinarySearchTreeTests_Remove5()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            tree.Insert(10, "John");
            tree.Insert(5, "Clark");
            tree.Insert(8, "Jack");
            tree.Insert(3, "Lui");
            tree.Insert(7, "Lu-lu");
            tree.Insert(6, "Ben");
            tree.Insert(1, "Lui");
            tree.Insert(2, "Lui");
            tree.Insert(0, "Lui");

            int[] expectedKeys = { 0, 1, 2, 3, 6, 7, 8, 10 };

            bool actualResult = tree.Remove(5);
            var actualKeys = tree.TraverseInOrder().Select(n => n.Key);

            Assert.IsTrue(actualResult);
            Assert.IsTrue(tree.Count == expectedKeys.Length);
            Assert.IsTrue(expectedKeys.Except(actualKeys).Count() == 0);
            Assert.IsTrue(actualKeys.Except(expectedKeys).Count() == 0);
        }

        [TestMethod]
        public void BinarySearchTreeTests_Random_Remove()
        {
            Random r = new Random();

            int n =(r.Next(200)+ 1) * (r.Next(200)+ 1);

            List<int> expectedKeys = new List<int>();
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            for (int i = 0; i < n; i++)
            {
                int newKey = r.Next(int.MaxValue);
                expectedKeys.Add(newKey);
                tree.Insert(newKey, string.Empty);
            }

            int k = r.Next((int)Math.Sqrt(n)) + 1;
            var toRemove = expectedKeys.OrderBy(_ => r.NextDouble()).Take(k);
            expectedKeys.Sort();
            foreach(var key in toRemove)
            {
                bool actualResult = tree.Remove(key);
                expectedKeys.Remove(key);
                var actualKeys = tree.TraverseInOrder().Select(_ => _.Key);

                Assert.IsTrue(actualResult);
                Assert.IsTrue(tree.Count == expectedKeys.Count);
                Assert.IsTrue(expectedKeys.Except(actualKeys).Count() == 0);
                Assert.IsTrue(actualKeys.Except(expectedKeys).Count() == 0);
            }
        }

        [TestMethod]
        public void BinarySearchTreeTests_Mirror()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            tree.Insert(10, "John");
            tree.Insert(5, "Clark");
            tree.Insert(13, "Pitty");
            tree.Insert(17, "Lilly");
            tree.Insert(8, "Jack");
            tree.Insert(0, "Lui");
            tree.Insert(16, "Petr");

            var expectedOrder = tree.TraverseInOrder().Reverse();
            
            tree.Mirror();

            var actualOrder = tree.TraverseInOrder().ToList();

            Assert.IsTrue(expectedOrder.Except(actualOrder).Count() == 0);
            Assert.IsTrue(actualOrder.Except(expectedOrder).Count() == 0);
        }

        [TestMethod]
        public void BinarySearchTreeTests_Random_Mirror()
        {
            Random r = new Random();
            int n = r.Next(1000000) + 1;

            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            for (int i = 0; i < n; i++)
            {
                int key = r.Next(int.MaxValue);
                tree.Insert(key, string.Empty);
            }

            var expectedOrder = tree.TraverseInOrder().Reverse();

            tree.Mirror();

            var actualOrder = tree.TraverseInOrder().ToList();

            Assert.IsTrue(expectedOrder.Except(actualOrder).Count() == 0);
            Assert.IsTrue(actualOrder.Except(expectedOrder).Count() == 0);
        }

        [TestMethod]
        public void BinarySearchTreeTests_LCA()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            
            IBinarySearchTreeNode<int, string> john = tree.Insert(10, "John");
            IBinarySearchTreeNode<int, string> clark = tree.Insert(5, "Clark");
            IBinarySearchTreeNode<int, string> pitty = tree.Insert(13, "Pitty");

            IBinarySearchTreeNode<int, string> ancestor = tree.LCA(john, pitty);

            Assert.IsNotNull(ancestor);
            Assert.AreEqual(john, ancestor);
        }

        [TestMethod]
        public void BinarySearchTreeTests_LCA2()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();

            IBinarySearchTreeNode<int, string> john = tree.Insert(10, "John");
            IBinarySearchTreeNode<int, string> clark = tree.Insert(5, "Clark");
            IBinarySearchTreeNode<int, string> pitty = tree.Insert(13, "Pitty");

            IBinarySearchTreeNode<int, string> ancestor = tree.LCA(clark, pitty);

            Assert.IsNotNull(ancestor);
            Assert.AreEqual(john, ancestor);
        }

        [TestMethod]
        public void BinarySearchTreeTests_LCA3()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();

            IBinarySearchTreeNode<int, string> john = tree.Insert(10, "John");
            IBinarySearchTreeNode<int, string> clark = tree.Insert(5, "Clark");
            IBinarySearchTreeNode<int, string> pitty = tree.Insert(13, "Pitty");

            IBinarySearchTreeNode<int, string> ancestor = tree.LCA(john, john);

            Assert.IsNotNull(ancestor);
            Assert.AreEqual(john, ancestor);
        }

        [TestMethod]
        public void BinarySearchTreeTests_LCA4()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            IBinarySearchTreeNode<int, string> john = tree.Insert(10, "John");
            IBinarySearchTreeNode<int, string> clark = tree.Insert(5, "Clark");
            IBinarySearchTreeNode<int, string> jack = tree.Insert(8, "Jack");
            IBinarySearchTreeNode<int, string> lui = tree.Insert(3, "Lui");
            IBinarySearchTreeNode<int, string> lulu = tree.Insert(7, "Lu-lu");
            IBinarySearchTreeNode<int, string> ben = tree.Insert(6, "Ben");
            IBinarySearchTreeNode<int, string> joney = tree.Insert(1, "Joney");
            IBinarySearchTreeNode<int, string> cris = tree.Insert(2, "Cris");
            IBinarySearchTreeNode<int, string> lenon = tree.Insert(0, "Lenon");

            IBinarySearchTreeNode<int, string> ancestor = tree.LCA(lulu, lenon);

            Assert.IsNotNull(ancestor);
            Assert.AreEqual(clark, ancestor);
        }

        [TestMethod]
        public void BinarySearchTreeTests_LCA5()
        {
            IBinarySearchTree<int, string> tree = new BinarySearchTree<int, string>();
            IBinarySearchTreeNode<int, string> lui = tree.Insert(3, "Lui");
            IBinarySearchTreeNode<int, string> clark = tree.Insert(5, "Clark");
            IBinarySearchTreeNode<int, string> joney = tree.Insert(1, "Joney");
            IBinarySearchTreeNode<int, string> jack = tree.Insert(8, "Jack");
            IBinarySearchTreeNode<int, string> john = tree.Insert(10, "John");
            IBinarySearchTreeNode<int, string> ben = tree.Insert(6, "Ben");
            IBinarySearchTreeNode<int, string> lulu = tree.Insert(7, "Lu-lu");
            IBinarySearchTreeNode<int, string> cris = tree.Insert(2, "Cris");
            IBinarySearchTreeNode<int, string> lenon = tree.Insert(0, "Lenon");

            IBinarySearchTreeNode<int, string> ancestor = tree.LCA(lulu, john);

            Assert.IsNotNull(ancestor);
            Assert.AreEqual(jack, ancestor);
        }
    }
}
