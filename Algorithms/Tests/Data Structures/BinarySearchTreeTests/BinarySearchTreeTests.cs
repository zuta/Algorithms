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

            IList<IBinarySearchTreeNode<int, string>> inOrderTraversedTree = tree.Traverse().ToList();

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
    }
}
