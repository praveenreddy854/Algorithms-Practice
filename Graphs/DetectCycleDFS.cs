namespace Algorithms_Practice.Graphs
{
    using System.Collections.Generic;
    public class DetectCycleDFS
    {
        static IList<IList<int>> graph;

        public DetectCycleDFS(int v)
        {
            graph = new List<IList<int>>();
            for(int i =0; i < v; i++)
            {
                graph.Add(new List<int>());
            }
        }

        public void AddEdge(int u, int v)
        {
            graph[u].Add(v);
        }

        public bool IsCyclic(bool[] visited, bool[] currentRecVisited, int index)
        {
            if(currentRecVisited[index])
            {
                return true;
            }
            if(visited[index])
            {
                return false;
            }

            IList<int> children = graph[index];
            visited[index] = true;
            currentRecVisited[index] = true;

            foreach(int child in children)
            {
                if(IsCyclic(visited, currentRecVisited, child))
                {
                    return true;
                }
            }
            
            currentRecVisited[index] = false;
            return false;
        }

        public static void Test()
        {
            DetectCycleDFS obj = new DetectCycleDFS(6);

            obj.AddEdge(0,5);
            obj.AddEdge(5,2);
            obj.AddEdge(2,3);
            obj.AddEdge(3,2);
            obj.AddEdge(3,1);
            obj.AddEdge(1,4);

            bool[] visited = new bool[6];
            bool[] currentRecVisited = new bool[6];
            bool isCyclic = false;
            for(int i=0; i < graph.Count; i++)
            {
                if(obj.IsCyclic(visited, currentRecVisited, i))
                {
                    System.Console.WriteLine("Cycle exists");
                    isCyclic = true;
                    break;
                }
            }

            if(!isCyclic)
            {
                System.Console.WriteLine("Cycle doesn't exists");
            }
        }
    }
}