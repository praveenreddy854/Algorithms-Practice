namespace Algorithms_Practice.Graphs
{
    using System.Collections.Generic;
    using System.Linq;
    public class DijstraShortestpath
    {
        int[] shortest;
        static int[,] graph;
         Queue<int> queue;

        public DijstraShortestpath(int source)
        {
            int cols = graph.GetLength(0);
            shortest = new int[cols];
            queue = new Queue<int>();
            queue.Enqueue(source);

            for(int i = 0; i < cols; i++)
            {
                shortest[i] = int.MaxValue;
            }
            shortest[source] = 0;
        }

        public void GetshortestPathFromSourceToAllOther(int source, int[] adjNodes)
        {
            if(queue.Count == 0)
            {
                return;
            }

            for(int node = 0; node < adjNodes.Length; node++)
            {
                if(graph[source, node] == -1)
                {
                    continue;
                }
                int td = graph[source, node] + shortest[source];
                int tm = shortest[node];
                if(tm <= td)
                {
                    continue;
                }
                shortest[node] = td;
                queue.Enqueue(node);
            }
            
            int currentNode = queue.Dequeue();
            adjNodes = GetRow(source);
            GetshortestPathFromSourceToAllOther(currentNode, adjNodes);
                
        }

        public int[] GetRow(int rowIndex)
        {
            int cols = graph.GetLength(0);
            int[] row = new int[cols];

            for(int i=0; i< cols; i++)
            {
                row[i] = graph[rowIndex, i];
            }
            return row;
        }

        public static void Test()
        {
            graph = new int[,]{ 
                    { 0, 4, -1, -1, -1, -1, -1, 8, -1 }, 
                    { 4, 0, 8, -1, -1, -1, -1, 11, -1 }, 
                    { -1, 8, 0, 7, -1, 4, -1, -1, 2 }, 
                    { -1, -1, 7, 0, 9, 14, -1, -1, -1 }, 
                    { -1, -1, -1, 9, 0, 10, -1, -1, -1 }, 
                    { -1, -1, 4, 14, 10, 0, 2, -1, -1 }, 
                    { -1, -1, -1, -1, -1, 2, 0, 1, 6 }, 
                    { 8, 11, -1, -1, -1, -1, 1, 0, 7 }, 
                    { -1, -1, 2, -1, -1, -1, 6, 7, 0 } 
                }; 

                DijstraShortestpath dsp = new DijstraShortestpath(0);
                dsp.GetshortestPathFromSourceToAllOther(0, dsp.GetRow(0));
                foreach(int s in dsp.shortest)
                {
                    System.Console.WriteLine(s + " ");
                }
        }
    }
}