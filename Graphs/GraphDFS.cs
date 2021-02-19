namespace Algorithms_Practice.Graphs
{
    using System.Collections.Generic;
    using System;
    public class GraphDFS
    {
        private static IList<List<int>> graph;
        private static bool[] Visited;
        public void PrintDFS(int startIndex)
        {
            if(startIndex == -1 || Visited[startIndex])
            {
                return;
            }
            System.Console.WriteLine(startIndex +" ");
            Visited[startIndex] = true;
            foreach(int index in graph[startIndex])
            {
                PrintDFS(index);
            }
        }

        public static void Test()
        {
            graph = new List<List<int>>();

            graph.Add(new List<int>() {1});
            graph.Add(new List<int>() {2, 5});
            graph.Add(new List<int>() {3});
            graph.Add(new List<int>() {1, 4});
            graph.Add(new List<int>() {-1});
            graph.Add(new List<int>() {-1});

            GraphDFS gdfs = new GraphDFS();
            Visited = new bool[graph.Count];
            gdfs.PrintDFS(0);
        }
    }
}