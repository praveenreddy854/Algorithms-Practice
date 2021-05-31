namespace Algorithms_Practice.Graphs
{
    using System;
    using System.Collections.Generic;
    public class FindIfThereExistsAPath
    {
        public bool IsPathExists(IList<IList<int>> graph, int source, int dest)
        {
            Queue<int> q = new Queue<int>();
            bool[] visited = new bool[graph.Count];
            q.Enqueue(source);
            return IsPathExists(graph, dest, visited, q);
        }
        private bool IsPathExists(IList<IList<int>> graph, int dest, bool[] visited, Queue<int> q)
        {
            if(q.Count > 0)
            {
                int node = q.Dequeue();
                if(node == dest)
                {
                    return true;
                }
                if(visited[node])
                {
                    return false;
                }
                
                IList<int> neighbors = graph[node];
                foreach(int neighbor in neighbors)
                {
                    q.Enqueue(neighbor);
                }
                if(IsPathExists(graph, dest, visited, q))
                {
                    return true;
                }
            }
            return false;
        }
        public static void Test()
        {
            FindIfThereExistsAPath pathFilder = new FindIfThereExistsAPath();
            IList<IList<int>> graph = new List<IList<int>>(8);
            for(int i =0; i < 8; i++)
            {
                graph.Add(new List<int>());
            }
            graph[0].Add(1);
            graph[1].Add(2);
            graph[2].Add(3);
            graph[0].Add(4);
            graph[1].Add(5);
            graph[6].Add(7);
            System.Console.WriteLine(pathFilder.IsPathExists(graph, 0, 5));
        }
    }
}