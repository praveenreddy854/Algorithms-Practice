using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Graphs
{
    class GraphBFS
    {
        private static void PrintGraphBFS(List<List<int>> graph)
        {
            int graphSize = graph.Count;
            bool[] visited = new bool[graphSize];

            Queue<List<int>> qNodes = new Queue<List<int>>();

            qNodes.Enqueue(graph[0]);
            Console.WriteLine(0);
            visited[0] = true;

            while(qNodes.Count != 0)
            {
                List<int> temp = qNodes.Peek();
                foreach (int node in temp)
                {
                    if(visited[node] == true)
                    {
                        continue;
                    }
                    qNodes.Enqueue(graph[node]);
                    Console.WriteLine(node);
                    visited[node] = true;
                }
                qNodes.Dequeue();
            }
        }
        public static void Test()
        {
            List<List<int>> graph = Graph.GetGraph();
            PrintGraphBFS(graph);
        }
    }
    
}
