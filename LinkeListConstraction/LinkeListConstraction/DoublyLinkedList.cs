using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Text;

namespace LinkeListConstraction
{
    public class DoublyLinkedList
    {
        public Node Head;
        public Node Tail;

        public bool Empty
        {
            get
            {
                return Head == null;
            }
        }

        protected void SetHeadTail()
        {
            if (Head != null)
                Head.Prev = null;
            if (Tail != null)
                Tail.Next = null;
        }

        public void SetHead(Node node)
        {
            if (Head == node)
                return;

            if (Head == null)
            {
                Head = node;
                Tail = node;
                SetHeadTail();
                return;
            }

            if (ContainsNode(node))
            {
                Head.Prev = Tail;
                Tail.Next = Head;
                Head = node;
                Tail = Head.Prev;
                Tail.Next = null;
                Head.Prev = null;
            }

            SetHeadTail();
        }

        public void SetTail(Node node)
        {
            if (Tail == node)
                return;

            if (Tail == null)
            {
                Head = node;
                Tail = node;
                SetHeadTail();
                return;
            }

            if (ContainsNode(node))
            {
                Head.Prev = Tail;
                Tail.Next = Head;
                Tail = node;
                Head = Tail.Next;
                Tail.Next = null;
                Head.Prev = null;
                return;
            }

            if (Head == Tail)
            {
                Head.Next = node;
                Tail = node;
                Tail.Prev = Head;
                return;
            }

            Tail.Prev.Next = node;
            node.Prev = Tail.Prev;
            Tail = node;

            SetHeadTail();
        }

        public void InsertBefore(Node node, Node nodeToInsert)
        {
            if (node == null)
            {
                if (Empty)
                {
                    SetHead(nodeToInsert);
                    return;
                }
                node = Head;
            }
            if (nodeToInsert == Head)
            {
                nodeToInsert.Next.Prev = null;
                Head = nodeToInsert.Next;
            }
            else if (nodeToInsert == Tail)
            {
                nodeToInsert.Prev.Next = null;
                Tail = nodeToInsert.Prev;
            }
            else if (ContainsNode(nodeToInsert))
            {
                nodeToInsert.Prev.Next = nodeToInsert.Next;
                nodeToInsert.Next.Prev = nodeToInsert.Prev;
            }

            var nodeBefore = node.Prev;
            if (nodeBefore == null)
            {
                Head = nodeToInsert;
                nodeToInsert.Prev = null;
            }
            else
            {
                nodeBefore.Next = nodeToInsert;
                nodeToInsert.Prev = nodeBefore;
            }
            nodeToInsert.Next = node;
            node.Prev = nodeToInsert;

            if (Head == node)
                Head = nodeToInsert;
        }

        public void InsertAfter(Node node, Node nodeToInsert)
        {
            if (node == null)
            {
                if (Empty)
                {
                    SetTail(nodeToInsert);
                    return;
                }
                node = Tail;
            }
            else if (!ContainsNode(node))
                return;

            if (nodeToInsert == Head)
            {
                nodeToInsert.Next.Prev = null;
                Head = nodeToInsert.Next;
            }
            else if (nodeToInsert == Tail)
            {
                nodeToInsert.Prev.Next = null;
                Tail = nodeToInsert.Prev;
            }
            else if (ContainsNode(nodeToInsert))
            {
                nodeToInsert.Prev.Next = nodeToInsert.Next;
                nodeToInsert.Next.Prev = nodeToInsert.Prev;
            }

            var nodeAfter = node.Next;
            if (nodeAfter == null)
            {
                Tail = nodeToInsert;
                nodeToInsert.Next = null;
            }
            else
            {
                nodeAfter.Prev = nodeToInsert;
                nodeToInsert.Next = nodeAfter;
            }
            nodeToInsert.Prev = node;
            node.Next = nodeToInsert;

            if (Tail == node)
                Tail = nodeToInsert;
        }

        public void InsertAtPosition(int position, Node nodeToInsert)
        {
            var pos = 1;
            var cur = Head;
            while (cur != null && pos != position)
            {
                pos++;
                cur = cur.Next;
            }
            if (cur == null)
            {
                InsertAfter(Tail, nodeToInsert);
                return;
            }
            InsertBefore(cur, nodeToInsert);
        }

        public void RemoveNodesWithValue(int value)
        {
            if (Empty)
                return;
            if (Head == Tail)
            {
                if (Head.Value == value)
                {
                    Head = null;
                    Tail = null;
                }
                return;
            }

            var curH = Head;
            var curT = Tail;
            while (curH != curT)
            {
                Node t = null;
                if (curH != null)
                {
                    t = curH.Next;
                    if (curH.Value == value)
                        Remove(curH);
                    curH = t;
                }
                if (curH == curT && curH != null && curH.Value == value)
                {
                    Remove(curH);
                    return;
                }
                if (curT != null)
                {
                    t = curT.Prev;
                    if (curT.Value == value)
                        Remove(curT);
                    curT = t;
                }
                if (curH == curT && curH != null && curH.Value == value)
                {
                    Remove(curH);
                    return;
                }
            }
        }

        public void Remove(Node node)
        {
            if (node == Head)
            {
                Head = node.Next;
                if (Head != null)
                    Head.Prev = null;
                else
                    Tail = null;
                return;
            }
            if (node == Tail)
            {
                Tail = node.Prev;
                if (Tail != null)
                    Tail.Next = null;
                else
                    Head = null;
                return;
            }
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }

        private bool ContainsNode(Node node)
        {
            if (Empty)
                return false;

            if (Head == Tail)
                return Head == node;

            var curH = Head;
            var curT = Tail;
            while (curH != curT)
            {
                if (curH == node || curT == node)
                    return true;
                curH = curH.Next;
                if (curH == curT.Prev)
                    return curH == node;
                curT = curT.Prev;
            }
            return false;
        }

        public bool ContainsNodeWithValue(int value)
        {
            if (Empty)
                return false;

            if (Head == Tail)
                return Head.Value == value;

            var curH = Head;
            var curT = Tail;
            while (curH != curT)
            {
                if (curH.Value == value || curT.Value == value)
                    return true;
                curH = curH.Next;
                if (curH == curT)
                    return curH.Value == value;
                curT = curT.Prev;
            }
            return false;
        }
    }
}
