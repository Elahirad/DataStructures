using System.Text;

namespace Trees
{
    public class Graph
    {
        private class Node
        {
            private string _label;

            public Node(string label)
            {
                this._label = label;
            }

            public override string ToString()
            {
                return this._label;
            }
        }

        private Dictionary<string, Node> _nodes;

        private Dictionary<Node, List<Node>> _aList;

        public Graph()
        {
            this._nodes = new Dictionary<string, Node>();
            this._aList = new Dictionary<Node, List<Node>>();
        }

        public void AddNode(string label)
        {
            if (label == null) return;
            if (this._nodes.ContainsKey(label)) throw new InvalidOperationException("Node Exists.");
            var newNode = new Node(label);
            this._nodes.Add(label, newNode);
            this._aList.Add(newNode, new List<Node>());
        }

        public void RemoveNode(string label)
        {
            if (label == null) return;
            if (!this._nodes.ContainsKey(label)) throw new ArgumentException();
            foreach (var nodeKey in this._aList.Keys) this._aList[nodeKey].Remove(nodeKey);
            this._aList.Remove(this._nodes[label]);
            this._nodes.Remove(label);
        }

        public void AddEdge(string from, string to)
        {
            if (!this._nodes.ContainsKey(from) || !this._nodes.ContainsKey(to)) throw new ArgumentException();
            this._aList[this._nodes[from]].Add(this._nodes[to]);
        }

        public void RemoveEdge(string from, string to)
        {
            if (!this._nodes.ContainsKey(from) || !this._nodes.ContainsKey(to)) throw new ArgumentException();
            this._aList[this._nodes[from]].Remove(this._nodes[to]);
        }

        public void TraverseDepthFirstIterative(string label)
        {
            if (!this._nodes.ContainsKey(label)) throw new ArgumentException("Node not found !");
            var set = new HashSet<Node>();
            TraverseDepthFirstIterative(this._nodes[label], set);
        }

        private void TraverseDepthFirstIterative(Node root, HashSet<Node> visited)
        {
            var stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                var buffer = stack.Pop();
                if (visited.Contains(buffer)) continue;
                System.Console.WriteLine(buffer);
                visited.Add(buffer);
                foreach (var node in this._aList[buffer])
                {
                    if (!visited.Contains(node)) stack.Push(node);
                }
            }
        }
        public void TraverseDepthFirst(string label)
        {
            if (!this._nodes.ContainsKey(label)) throw new ArgumentException("Node not found!");
            TraverseDepthFirst(this._nodes[label], new HashSet<Node>());
        }

        private void TraverseDepthFirst(Node root, HashSet<Node> visited)
        {
            System.Console.WriteLine(root);
            visited.Add(root);
            foreach (var node in this._aList[root])
            {
                if (!visited.Contains(node)) TraverseDepthFirst(node, visited);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var nodeKey in this._aList.Keys)
            {
                result.Append($"{nodeKey} is connected with : ["
                    + string.Join(", ", this._aList[nodeKey])
                    + "]" + '\n');
            }
            return result.ToString();
        }
    }
}