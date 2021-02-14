using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DFS
    {
        static List<List<int>> adj;
        static List<int> dfsList;
       
        
        private static void GetDfsUtils(int vertex, bool[] visited)
        {
            if (!visited[vertex])
                dfsList.Add(vertex);
            visited[vertex] = true;
            foreach (int v in adj[vertex])
            {
                if(!visited[v])
                {
                    GetDfsUtils(v, visited);
                }
            }
            
        }

        /// <summary>
        /// Vertex at which DFS is needed
        /// </summary>
        public static List<int> GetDfs(int vertex)
        {
            adj = Graph.GetGraph();
            dfsList = new List<int>();
            bool[] visited = new bool[adj.Count];
            GetDfsUtils(vertex, visited);
            return dfsList;
        }
    }
}
