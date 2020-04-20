using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrunchSumsSolution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrunchSumsSolutionTests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod]
        public void TestCase1()
        {
            TestBinaryTree tree = new TestBinaryTree(1);
            List<int> expected = new List<int>() { 1 };
            Assert.IsTrue(Program.BranchSums(tree).SequenceEqual(expected));
        }

        [TestMethod]
        public void TestCase2()
        {
            TestBinaryTree tree = new TestBinaryTree(1).Insert(new List<int>() { 2 });
            List<int> expected = new List<int>() { 3 };
            Assert.IsTrue(Program.BranchSums(tree).SequenceEqual(expected));
        }

        [TestMethod]
        public void TestCase3()
        {
            TestBinaryTree tree = new TestBinaryTree(1).Insert(new List<int>() { 2, 3 });
            List<int> expected = new List<int>() { 3, 4 };
            Assert.IsTrue(Program.BranchSums(tree).SequenceEqual(expected));
        }

        [TestMethod]
        public void TestCase4()
        {
            TestBinaryTree tree = new TestBinaryTree(1).Insert(new List<int>() { 2, 3, 4, 5 });
            List<int> expected = new List<int>() { 7, 8, 4 };
            Assert.IsTrue(Program.BranchSums(tree).SequenceEqual(expected));
        }

        [TestMethod]
        public void TestCase5()
        {
            TestBinaryTree tree = new TestBinaryTree(1).Insert(new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            List<int> expected = new List<int>() { 15, 16, 18, 10, 11 };
            Assert.IsTrue(Program.BranchSums(tree).SequenceEqual(expected));
        }

        [TestMethod]
        public void TestCase6()
        {
            TestBinaryTree tree = new TestBinaryTree(0);
            tree.left = new TestBinaryTree(1);
            tree.left.left = new TestBinaryTree(10);
            tree.left.left.left = new TestBinaryTree(100);
            List<int> expected = new List<int>() { 111 };
            Assert.IsTrue(Program.BranchSums(tree).SequenceEqual(expected));
        }

        [TestMethod]
        public void TestCase7()
        {
            TestBinaryTree tree = new TestBinaryTree(0);
            tree.left = new TestBinaryTree(1);
            tree.left.left = new TestBinaryTree(10);
            tree.left.left.left = new TestBinaryTree(100);
            List<int> expected = new List<int>() { 111 };
            Assert.IsTrue(Program.BranchSums(tree).SequenceEqual(expected));
        }

        [TestMethod]
        public void TestCase8()
        {
            TestBinaryTree tree = new TestBinaryTree(0);
            tree.right = new TestBinaryTree(1);
            tree.right.right = new TestBinaryTree(10);
            tree.right.right.right = new TestBinaryTree(100);
            List<int> expected = new List<int>() { 111 };
            Assert.IsTrue(Program.BranchSums(tree).SequenceEqual(expected));
        }

        [TestMethod]
        public void TestCase9()
        {
            TestBinaryTree tree = new TestBinaryTree(0);
            tree.left = new TestBinaryTree(9);
            tree.right = new TestBinaryTree(1);
            tree.right.left = new TestBinaryTree(15);
            tree.right.right = new TestBinaryTree(10);
            tree.right.right.left = new TestBinaryTree(100);
            tree.right.right.right = new TestBinaryTree(200);
            List<int> expected = new List<int>() { 9, 16, 111, 211 };
            Assert.IsTrue(Program.BranchSums(tree).SequenceEqual(expected));
        }
    }
}