using System.Collections.Generic;

namespace DepthFirstSearchSolution
{
    public class Node
    {
        public string name;
        public List<Node> children = new List<Node>();

        public Node(string name)
        {
            this.name = name;
        }

        public List<string> DepthFirstSearch(List<string> array)
        {
            array.Add(name);
            foreach (var node in children)
                node.DepthFirstSearch(array);
            return array;
        }

        public Node AddChild(string name)
        {
            Node child = new Node(name);
            children.Add(child);
            return this;
        }
    }
}
