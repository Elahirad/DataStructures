namespace Trees
{

    public class WeightedGraph
    {
        private class Node
        {
            private string _value;

            private Dictionary<Node, Edge> _edges;
            public Node(string value)
            {
                this._value = value;
                this._edges = new Dictionary<Node, Edge>();
            }

            public void AddEdge(Node to, int weight)
            {
                this._edges[to] = new Edge(this, to, weight);
            }

            public Dictionary<Node, Edge> Edges()
            {
                return this._edges;
            }

            public override string ToString()
            {
                return this._value;
            }
        }

        private class Edge
        {
            public Node? From { get; set; }
            public Node? To { get; set; }
            public int Weight { get; set; }

            public Edge(Node from, Node to, int weight)
            {
                this.From = from;
                this.To = to;
                this.Weight = weight;
            }
        }

        private class NodeEntry
        {
            private Node _node;

            private int _weight;

            public NodeEntry(Node node, int weight)
            {
                this._node = node;
                this._weight = weight;
            }

            public Node GetNode()
            {
                return this._node;
            }

            public int GetWeight()
            {
                return this._weight;
            }
        }
        private Dictionary<string, Node> _nodeDict;
        public WeightedGraph()
        {
            _nodeDict = new Dictionary<string, Node>();
        }

        public void AddNode(string value)
        {
            if (value == null) throw new ArgumentException();
            if (_nodeDict.ContainsKey(value)) throw new InvalidOperationException("Node exists.");
            _nodeDict[value] = new Node(value);
        }

        public void AddEdge(string from, string to, int weight)
        {
            if (from == null || to == null) throw new ArgumentException();
            if (!_nodeDict.ContainsKey(from) || !_nodeDict.ContainsKey(to)) throw new InvalidOperationException("Nodes does not exist.");
            var fromNode = _nodeDict[from];
            var toNode = _nodeDict[to];
            fromNode.AddEdge(toNode, weight);
            toNode.AddEdge(fromNode, weight);
        }

        public List<string> ShortestPath(string from, string to)
        {
            if (!_nodeDict.ContainsKey(from) || !_nodeDict.ContainsKey(to))
                throw new InvalidOperationException("Nodes does not exist.");

            var distanceDict = new Dictionary<Node, int>();
            var previousDict = new Dictionary<Node, Node>();
            var visited = new HashSet<Node>();
            var fromNode = _nodeDict[from];
            var toNode = _nodeDict[to];
            var pq = new PriorityQueue<NodeEntry, int>();
            foreach (var node in _nodeDict.Keys)
            {
                distanceDict.Add(_nodeDict[node], int.MaxValue);
                previousDict.Add(_nodeDict[node], _nodeDict[node]);
            }
            pq.Enqueue(new NodeEntry(fromNode, 0), 0);
            distanceDict[fromNode] = 0;
            while (pq.Count != 0)
            {
                var current = pq.Dequeue();
                if (visited.Contains(current.GetNode())) continue;
                var edges = current.GetNode().Edges();
                foreach (var node in edges.Keys)
                {
                    var weight = current.GetWeight() + edges[node].Weight;
                    if (weight < distanceDict[node])
                    {
                        distanceDict[node] = weight;
                        previousDict[node] = current.GetNode();
                    }
                    pq.Enqueue(new NodeEntry(node, weight), weight);
                }
                visited.Add(current.GetNode());
            }
            var s = new Stack<Node>();
            var buffer = toNode;
            while (true)
            {
                s.Push(buffer);
                if (buffer == fromNode)
                    break;
                buffer = previousDict[buffer];
            }
            var result = new List<string>();
            while (s.Count != 0)
            {
                result.Add(s.Pop().ToString());
            }
            return result;
        }

        public bool HasCycle()
        {
            var visited = new HashSet<Node>();
            foreach (var node in _nodeDict.Values)
            {
                if ((!visited.Contains(node)) &&
                    (HasCycle(node, new Node(""), visited))) return true;

            }
            return false;
        }

        private bool HasCycle(Node root, Node parent, HashSet<Node> visited)
        {
            visited.Add(root);
            var edges = root.Edges();
            foreach (var edge in edges.Keys)
            {
                if (parent == edge) continue;
                if ((visited.Contains(edge)) ||
                 (HasCycle(edge, root, visited))) return true;
            }
            visited.Add(root);
            return false;
        }
    }
}