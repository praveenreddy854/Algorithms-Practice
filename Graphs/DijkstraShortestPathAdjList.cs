namespace Algorithms_Practice.Graphs
{
    using System;
    using System.Collections.Generic;
    public class DijkstraShortestPathAdjList
    {
        private static IList<IList<KeyValuePair<int, int>>> graph;
        private static KeyValuePair<int, int>[] heap;
        private static int[] shortestPath;
        private static bool[] foundShortest;

        private static int heapSize;
        public DijkstraShortestPathAdjList(int graphLength, int sourceVertext)
        {
            heap = new KeyValuePair<int, int>[graphLength];
            heapSize = 0;
            graph = new List<IList<KeyValuePair<int, int>>>();
            shortestPath = new int[graphLength];
            foundShortest = new bool[graphLength];

            for(int i = 0; i < graphLength; i++)
            {
                graph.Add(new List<KeyValuePair<int, int>>());
                shortestPath[i] = int.MaxValue;
            }
            shortestPath[sourceVertext] = 0;
            foundShortest[sourceVertext] = true;
            AddToHeap(new KeyValuePair<int, int>(sourceVertext, 0));
        }

        public void AddEdge(int source, int dest, int weight)
        {
            graph[source].Add(new KeyValuePair<int, int>(dest, weight));
        }

        private void AddToHeap(KeyValuePair<int, int> kv)
        {
            heap[heapSize] = kv;
            Heapify(heapSize);
            heapSize++;
        }

        private void Heapify(int index)
        {
            int paretntIndex = index / 2;

            if(heap[paretntIndex].Value > heap[index].Value)
            {
                var temp = heap[paretntIndex];
                heap[paretntIndex] = heap[index];
                heap[index] = temp;
                Heapify(paretntIndex);
            }
        }

        private int PickMinimum()
        {
            if(heapSize > 0)
            {
                int lastIndex = heapSize - 1;
                var temp = heap[0];
                heap[0] = heap[lastIndex];
                heap[lastIndex] = new KeyValuePair<int, int>(temp.Key, int.MaxValue);

                Heapify(lastIndex);
                heapSize--;

                return temp.Key;

            }
            return -1;
        }
        public void GetShortesetPath()
        {
            int u = PickMinimum();

            if(u == -1)
            {
                return;
            }
            var nodes = graph[u];

            foreach(KeyValuePair<int, int> kv in nodes)
            {
                if(!foundShortest[kv.Key] && (shortestPath[kv.Key] > shortestPath[u] + kv.Value))
                {
                    shortestPath[kv.Key] = shortestPath[u] + kv.Value;
                    AddToHeap(new KeyValuePair<int, int>(kv.Key, shortestPath[kv.Key]));
                }
            }

            foundShortest[u] = true;
            GetShortesetPath();
        }

        public static void Test()
        {
            DijkstraShortestPathAdjList obj = new DijkstraShortestPathAdjList(9, 0);
            obj.AddEdge(0, 1, 4);
            obj.AddEdge(0, 7, 8);
            obj.AddEdge(1, 2, 8);
            obj.AddEdge(1, 7, 11);
            obj.AddEdge(2, 3, 7);
            obj.AddEdge(2, 8, 2);
            obj.AddEdge(2, 5, 4);
            obj.AddEdge(3, 4, 9);
            obj.AddEdge(3, 5, 14);
            obj.AddEdge(4, 5, 10);
            obj.AddEdge(5, 4, 10);
            obj.AddEdge(5, 6, 2);
            obj.AddEdge(6, 7, 1);
            obj.AddEdge(6, 8, 6);
            obj.AddEdge(6, 5, 2);
            obj.AddEdge(7, 8, 7);
            obj.AddEdge(7, 6, 1);

            obj.GetShortesetPath();

            foreach(int p in shortestPath)
            {
                System.Console.WriteLine(p);
            }
        }
    }
}