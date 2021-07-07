namespace Algorithms_Practice.Graphs
{
    // https://leetcode.com/problems/clone-graph/
    using System.Collections.Generic;
    public class CloneGraphEntity
    {
        Dictionary<int, bool> visited;
        Dictionary<Node, Node> nodesDict;
        public Node CloneGraph(Node node) {
            if(node == null)
            {
                return null;
            }
            visited = new Dictionary<int, bool>();
            nodesDict = new Dictionary<Node, Node>();

            PopulateNodesDict(node);
            PopulateNeighborsInNodeDict();
            return nodesDict[node];
        }
        private void PopulateNodesDict(Node node){
            if(!visited.ContainsKey(node.val) || !visited[node.val])
            {
                nodesDict.Add(node, new Node(node.val));
                visited[node.val] = true;
                IList<Node> neighbors = node.neighbors;
                foreach(Node neighbor in neighbors)
                {
                    PopulateNodesDict(neighbor);
                }
            }
        }
        private void PopulateNeighborsInNodeDict()
        {
            foreach(var nodeKp in nodesDict)
            {
                IList<Node> keyNeighbors = nodeKp.Key.neighbors;
                foreach(var keyNeighbor in keyNeighbors)
                {
                    nodeKp.Value.neighbors.Add(nodesDict[keyNeighbor]);
                }
            }
        }
    }
    public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
}