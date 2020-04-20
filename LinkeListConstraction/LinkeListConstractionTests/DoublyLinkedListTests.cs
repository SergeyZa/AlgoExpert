using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkeListConstractionSolution;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkeListConstractionSolution.Tests
{
    [TestClass()]
    public class DoublyLinkedListTests
    {
        private void expectEmpty(DoublyLinkedList list)
        {
            Assert.IsTrue(list.Head == null);
            Assert.IsTrue(list.Tail == null);
        }
        private void expectHeadTail(DoublyLinkedList linkedList, Node Head, Node Tail)
        {
            Assert.IsTrue(linkedList.Head == Head);
            Assert.IsTrue(linkedList.Tail == Tail);
            Assert.IsTrue(linkedList.Head?.Prev == null);
            Assert.IsTrue(linkedList.Tail?.Next == null);
        }

        private void expectSingleNode(DoublyLinkedList linkedList, Node node)
        {
            expectHeadTail(linkedList, node, node);
        }

        private List<int> getNodeValuesHeadToTail(DoublyLinkedList linkedList)
        {
            List<int> values = new List<int>();
            Node node = linkedList.Head;
            while (node != null)
            {
                values.Add(node.Value);
                node = node.Next;
            }
            return values;
        }

        private List<int> getNodeValuesTailToHead(DoublyLinkedList linkedList)
        {
            List<int> values = new List<int>();
            Node node = linkedList.Tail;
            while (node != null)
            {
                values.Add(node.Value);
                node = node.Prev;
            }
            return values;
        }

        private void removeNodes(DoublyLinkedList linkedList, List<Node> nodes)
        {
            foreach (var node in nodes)
            {
                linkedList.Remove(node);
            }
        }

        private bool compare(List<int> array1, int[] array2)
        {
            if (array1.Count != array2.Length)
            {
                return false;
            }
            for (int i = 0; i < array1.Count; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }

        [TestMethod()]
        public void SetHeadTest()
        {

        }

        [TestMethod()]
        public void SetTailTest()
        {

        }

        [TestMethod()]
        public void InsertBeforeTest()
        {

        }

        [TestMethod()]
        public void InsertAfterTest()
        {

        }

        [TestMethod()]
        public void InsertAtPositionTest()
        {

        }

        [TestMethod()]
        public void RemoveNodesWithValueTest()
        {

        }

        [TestMethod()]
        public void RemoveTest()
        {

        }

        [TestMethod()]
        public void ContainsNodeWithValueTest()
        {

        }

        [TestMethod]
        public void TestCase1()
        {
            var linkedList = new DoublyLinkedList();
            var node = new Node(1);

            linkedList.SetHead(node);
            expectSingleNode(linkedList, node);
            linkedList.Remove(node);
            expectEmpty(linkedList);
            linkedList.SetTail(node);
            expectSingleNode(linkedList, node);
            linkedList.RemoveNodesWithValue(1);
            expectEmpty(linkedList);
            linkedList.InsertAtPosition(1, node);
            expectSingleNode(linkedList, node);
        }

        [TestMethod]
        public void TestCase2()
        {
            var linkedList = new DoublyLinkedList();
            var first = new Node(1);
            var second = new Node(2);
            var nodes = new List<Node>();
            nodes.Add(first);
            nodes.Add(second);

            linkedList.SetHead(first);
            linkedList.SetTail(second);
            expectHeadTail(linkedList, first, second);
            removeNodes(linkedList, nodes);
            expectEmpty(linkedList);

            linkedList.SetHead(first);
            linkedList.InsertAfter(first, second);
            expectHeadTail(linkedList, first, second);
            removeNodes(linkedList, nodes);
            expectEmpty(linkedList);

            linkedList.SetHead(first);
            linkedList.InsertBefore(first, second);
            expectHeadTail(linkedList, second, first);
            removeNodes(linkedList, nodes);
            linkedList.InsertAtPosition(1, first);
            linkedList.InsertAtPosition(2, second);
            expectHeadTail(linkedList, first, second);
            removeNodes(linkedList, nodes);
            linkedList.InsertAtPosition(2, first);
            linkedList.InsertAtPosition(1, second);
            expectHeadTail(linkedList, second, first);
        }

        [TestMethod]
        public void TestCase3()
        {
            var linkedList = new DoublyLinkedList();
            var first = new Node(1);
            var second = new Node(2);
            var third = new Node(3);
            var fourth = new Node(4);

            linkedList.SetHead(first);
            Assert.IsTrue(linkedList.ContainsNodeWithValue(1) == true);
            linkedList.InsertAfter(first, second);
            Assert.IsTrue(linkedList.ContainsNodeWithValue(2) == true);
            linkedList.InsertAfter(second, third);
            Assert.IsTrue(linkedList.ContainsNodeWithValue(3) == true);
            linkedList.InsertAfter(third, fourth);
            Assert.IsTrue(linkedList.ContainsNodeWithValue(4) == true);
            linkedList.RemoveNodesWithValue(3);
            Assert.IsTrue(linkedList.ContainsNodeWithValue(3) == false);
            linkedList.Remove(first);
            Assert.IsTrue(linkedList.ContainsNodeWithValue(1) == false);
            linkedList.RemoveNodesWithValue(4);
            Assert.IsTrue(linkedList.ContainsNodeWithValue(4) == false);
            linkedList.Remove(second);
            Assert.IsTrue(linkedList.ContainsNodeWithValue(2) == false);
        }

        [TestMethod]
        public void TestCase4()
        {
            DoublyLinkedList linkedList = new DoublyLinkedList();
            Node first = new Node(1);
            Node second = new Node(2);
            Node third = new Node(3);
            Node fourth = new Node(3);
            Node fifth = new Node(3);
            Node sixth = new Node(6);
            Node seventh = new Node(7);

            linkedList.SetHead(first);
            linkedList.InsertAfter(first, second);
            linkedList.InsertAfter(second, third);
            linkedList.InsertAfter(third, fourth);
            linkedList.InsertAfter(fourth, fifth);
            linkedList.InsertAfter(fifth, sixth);
            linkedList.InsertAfter(sixth, seventh);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 1, 2, 3, 3, 3, 6, 7 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 7, 6, 3, 3, 3, 2, 1 }));
            expectHeadTail(linkedList, first, seventh);
            linkedList.Remove(second);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 1, 3, 3, 3, 6, 7 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 7, 6, 3, 3, 3, 1 }));
            expectHeadTail(linkedList, first, seventh);
            linkedList.RemoveNodesWithValue(1);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 3, 3, 3, 6, 7 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 7, 6, 3, 3, 3 }));
            expectHeadTail(linkedList, third, seventh);
            linkedList.RemoveNodesWithValue(3);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList), new int[] { 6, 7 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList), new int[] { 7, 6 }));
            expectHeadTail(linkedList, sixth, seventh);
            linkedList.RemoveNodesWithValue(7);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList), new int[] { 6 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList), new int[] { 6 }));
            expectHeadTail(linkedList, sixth, sixth);
        }

        [TestMethod]
        public void TestCase5()
        {
            DoublyLinkedList linkedList = new DoublyLinkedList();
            Node first = new Node(1);
            Node second = new Node(2);
            Node third = new Node(3);
            Node fourth = new Node(4);
            Node fifth = new Node(5);
            Node sixth = new Node(6);
            Node seventh = new Node(7);

            linkedList.SetHead(first);
            linkedList.InsertAfter(first, second);
            linkedList.InsertAfter(second, third);
            linkedList.InsertAfter(third, fourth);
            linkedList.InsertAfter(fourth, fifth);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 1, 2, 3, 4, 5 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 5, 4, 3, 2, 1 }));
            expectHeadTail(linkedList, first, fifth);
            linkedList.InsertAfter(third, fifth);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 1, 2, 3, 5, 4 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 4, 5, 3, 2, 1 }));
            expectHeadTail(linkedList, first, fourth);
            linkedList.InsertAfter(third, first);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 2, 3, 1, 5, 4 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 4, 5, 1, 3, 2 }));
            expectHeadTail(linkedList, second, fourth);
            linkedList.InsertAfter(fifth, second);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 3, 1, 5, 2, 4 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 4, 2, 5, 1, 3 }));
            expectHeadTail(linkedList, third, fourth);
            linkedList.InsertAfter(second, first);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 3, 5, 2, 1, 4 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 4, 1, 2, 5, 3 }));
            expectHeadTail(linkedList, third, fourth);
            linkedList.InsertAfter(fourth, sixth);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 3, 5, 2, 1, 4, 6 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 6, 4, 1, 2, 5, 3 }));
            expectHeadTail(linkedList, third, sixth);
            linkedList.InsertAfter(second, seventh);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 3, 5, 2, 7, 1, 4, 6 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 6, 4, 1, 7, 2, 5, 3 }));
            expectHeadTail(linkedList, third, sixth);
        }

        [TestMethod]
        public void TestCase6()
        {
            DoublyLinkedList linkedList = new DoublyLinkedList();
            Node first = new Node(1);
            Node second = new Node(2);
            Node third = new Node(3);
            Node fourth = new Node(4);
            Node fifth = new Node(5);
            Node sixth = new Node(6);
            Node seventh = new Node(7);

            linkedList.SetHead(first);
            linkedList.InsertBefore(first, second);
            linkedList.InsertBefore(second, third);
            linkedList.InsertBefore(third, fourth);
            linkedList.InsertBefore(fourth, fifth);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 5, 4, 3, 2, 1 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 1, 2, 3, 4, 5 }));
            expectHeadTail(linkedList, fifth, first);
            linkedList.InsertBefore(third, first);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 5, 4, 1, 3, 2 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 2, 3, 1, 4, 5 }));
            expectHeadTail(linkedList, fifth, second);
            linkedList.InsertBefore(fifth, second);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 2, 5, 4, 1, 3 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 3, 1, 4, 5, 2 }));
            expectHeadTail(linkedList, second, third);
            linkedList.InsertBefore(fifth, fourth);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 2, 4, 5, 1, 3 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 3, 1, 5, 4, 2 }));
            expectHeadTail(linkedList, second, third);
            linkedList.InsertBefore(second, sixth);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 6, 2, 4, 5, 1, 3 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 3, 1, 5, 4, 2, 6 }));
            expectHeadTail(linkedList, sixth, third);
            linkedList.InsertBefore(first, seventh);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 6, 2, 4, 5, 7, 1, 3 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 3, 1, 7, 5, 4, 2, 6 }));
            expectHeadTail(linkedList, sixth, third);
        }

        [TestMethod]
        public void TestCase7()
        {
            DoublyLinkedList linkedList = new DoublyLinkedList();
            Node first = new Node(1);
            Node second = new Node(2);
            Node third = new Node(3);
            Node fourth = new Node(4);
            Node fifth = new Node(5);
            Node sixth = new Node(6);
            Node seventh = new Node(7);

            linkedList.SetHead(first);
            linkedList.InsertAtPosition(1, second);
            linkedList.InsertAtPosition(1, third);
            linkedList.InsertAtPosition(1, fourth);
            linkedList.InsertAtPosition(1, fifth);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 5, 4, 3, 2, 1 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 1, 2, 3, 4, 5 }));
            expectHeadTail(linkedList, fifth, first);
            linkedList.InsertAtPosition(2, first);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 5, 1, 4, 3, 2 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 2, 3, 4, 1, 5 }));
            expectHeadTail(linkedList, fifth, second);
            linkedList.InsertAtPosition(1, second);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 2, 5, 1, 4, 3 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 3, 4, 1, 5, 2 }));
            expectHeadTail(linkedList, second, third);
            linkedList.InsertAtPosition(2, fourth);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 2, 4, 5, 1, 3 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 3, 1, 5, 4, 2 }));
            expectHeadTail(linkedList, second, third);
            linkedList.InsertAtPosition(1, sixth);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 6, 2, 4, 5, 1, 3 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 3, 1, 5, 4, 2, 6 }));
            expectHeadTail(linkedList, sixth, third);
            linkedList.InsertAtPosition(5, seventh);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 6, 2, 4, 5, 7, 1, 3 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 3, 1, 7, 5, 4, 2, 6 }));
            expectHeadTail(linkedList, sixth, third);
            linkedList.InsertAtPosition(8, fourth);
            Assert.IsTrue(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 6, 2, 5, 7, 1, 3, 4 }));
            Assert.IsTrue(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 4, 3, 1, 7, 5, 2, 6 }));
            expectHeadTail(linkedList, sixth, fourth);
        }
    }
}