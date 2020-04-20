using System;
using System.Collections.Generic;
using System.Text;

namespace LinkeListConstractionSolution
{
    public class Node
    {
        public int Value;
        public Node Prev;
        public Node Next;

        public Node(int value)
        {
            this.Value = value;
        }
    }
}
