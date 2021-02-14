using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // A C# program to print topological 
    // sorting of a DAG 
    using System;
    using System.Collections.Generic;

    // This class represents a directed graph 
    // using adjacency list representation 
    class TopologicalSort
    {

        // No. of vertices 
        private int V;

        // Adjacency List as ArrayList 
        // of ArrayList's 
        private List<List<int>> adj;

        //Constructor 
        TopologicalSort(int v)
        {
            V = v;
            adj = new List<List<int>>(v);
            for (int i = 0; i < v; i++)
                adj.Add(new List<int>());
        }

        // Function to add an edge into the graph 
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }

        // A recursive function used by topologicalSort 
        void TopologicalSortUtil(int v, bool[] visited,
                                Stack<int> stack)
        {

            // Mark the current node as visited. 
            visited[v] = true;

            // Recur for all the vertices 
            // adjacent to this vertex 
            foreach (var vertex in adj[v])
            {
                if (!visited[vertex])
                    TopologicalSortUtil(vertex,
                                        visited,
                                        stack);
            }

            // Push current vertex to 
            // stack which stores result 
            stack.Push(v);
        }

        // The function to do Topological Sort. 
        // It uses recursive topologicalSortUtil() 
        void TopologicalSortFunc()
        {
            Stack<int> stack = new Stack<int>();

            // Mark all the vertices as not visited 
            var visited = new bool[V];

            // Call the recursive helper function 
            // to store Topological Sort starting 
            // from all vertices one by one 
            for (int i = 0; i < V; i++)
            {
                if (visited[i] == false)
                    TopologicalSortUtil(i, visited,
                                        stack);
            }

            // Print contents of stack 
            foreach (var vertex in stack)
            {
                Console.Write(vertex + " ");
            }

        }

        // Driver code 
        public static void TopologicalSortInvoker()
        {

            // Create a graph given 
            // in the above diagram 
            TopologicalSort g = new TopologicalSort(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(0, 3);

            Console.WriteLine("Following is a Topological " +
                            "sort of the given graph");

            g.TopologicalSortFunc();
        }
    }

    // This code is contributed by Abhinav Galodha 

}
