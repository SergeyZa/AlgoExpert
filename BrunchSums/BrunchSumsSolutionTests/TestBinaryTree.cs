using BrunchSumsSolution;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrunchSumsSolutionTests
{
    internal class TestBinaryTree : BinaryTree
    {
        public TestBinaryTree(int value) : base(value)
        {
        }

        public TestBinaryTree Insert(List<int> values)
        {
            return Insert(values, 0);
        }

        public TestBinaryTree Insert(List<int> values, int i)
        {
            if (i >= values.Count) return null;

            List<TestBinaryTree> queue = new List<TestBinaryTree>();
            queue.Add(this);
            while (queue.Count > 0)
            {
                TestBinaryTree current = queue[0];
                queue.RemoveAt(0);
                if (current.left == null)
                {
                    current.left = new TestBinaryTree(values[i]);
                    break;
                }
                queue.Add((TestBinaryTree)current.left);
                if (current.right == null)
                {
                    current.right = new TestBinaryTree(values[i]);
                    break;
                }
                queue.Add((TestBinaryTree)current.right);
            }
            Insert(values, i + 1);
            return this;
        }
    }
}
