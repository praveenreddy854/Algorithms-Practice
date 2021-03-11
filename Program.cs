using ConsoleApp1.Amazon;
using ConsoleApp1.ArrayProblems;
using ConsoleApp1.BitManipulation;
using ConsoleApp1.DynamicsProgrammingProblems;
using ConsoleApp1.Graphs;
using ConsoleApp1.HeapProblems;
using ConsoleApp1.LinkedListProblems;
using ConsoleApp1.NumberProblems;
using ConsoleApp1.StackProblems;
using ConsoleApp1.StringProblems;
using ConsoleApp1.TreeProblems;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms_Practice.Graphs;
using Algorithms_Practice.ArrayProblems;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //NUmberTriangle();
            //TopologicalSort.TopologicalSortInvoker();

            //DFS
            //DFS.GetDfs(1);

            //ActivitySelction.GetMostNumberOfActivities();
            //ActivitySelction.GetLeastChangeInLeastCoins();

            //DynamicsProgramming.SelectItemsForMaxProfit();

            //BubbleSort.BubbleSortFunc();

            //MergeSort.MergeSortFunc();

            //InsertionSort.InsertionSortFunc();

            //QuickSort.QuickSortFunc();

            //BinarySearchTree.CreateBST();

            //SinglyLinkedList.Create();
            //DoublyLinkedList.Create();
            //CircularLinkedList.Create();

            //Arrays.FindTripleToGetGivenSum();

            //Arrays.TargetSumUsingSubsetOfElements();

            //Heap.BuildHeap();

            //Console.WriteLine((new KthLargestElementInStream(3, new int[] { 3,2,3,1,2,4,5,5,6 })).KthLargest);

            //int n = UglyNumbers.NthUglyNumber(1352);

            //TopKFrequentElements.TopKFrequent(new int[] { 1,1,1,2,2,2,3,3,3}, 3);

            LongestSubString.Test();

            //ReverseInteger.Reverse(1534236469);

            //PalindromNumber.IsPolidrom(121);

            //LongestCommonPrefixClass.LongestCommonPrefix(new string[] { "abc", "abd", "abcef" });

            //ValidaParanthesis.IsValid("([{}])");

            //RemoveDuplicatesFromSortedArray.RemoveDuplicates(new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 });

            //MaximumSubArraySum.MaxSubArray(new int[] { 1, -1, 1, -2, 2, -2, 3, -3, 3 });

            //MaximumSubArraySum.MaxSumUsingDivideAndConquer(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });

            //ClimbingStairs.ClimbStairs(10);

            //SymmetricTree.CheckSymmetricity();

            //SortedArrayToBSTClass.SortedArrayToBST(new int[] { -10, -3, 0, 5, 9 });

            //PascalsTriangle.Generate(5);

            //BestTimeToBuyAndSellStocks.MaxProfit2(new int[]{ 1, 2, 4, 2, 5, 7, 2, 4, 9, 0});

            //SingleNumberClass.SingleNumber(new int[] { 4, 1, 2, 1, 2});

            //ReverseBits.ReverseBitsWithShift(21);
            //LinkedListProblems.Palindrome.TestIsPalindrome();

            //AddTwoNumberClass obj = new AddTwoNumberClass();
            //ListNode l1 = new ListNode(2);
            //l1.next = new ListNode(4);
            //l1.next.next = new ListNode(9);

            //ListNode l2 = new ListNode(5);
            //l2.next = new ListNode(6);
            //obj.AddTwoNumbers(l1,l2); ;

            //LongestPalidromicSubString.LongestPalindrome("babad");
            //LongestPalidromicSubString.LongestPalindrome("aaaabbaa");
            //FindFruitCombos.TestWinPrize();
            //ContactsClass.Test();
            //LargestItemAssociation.Test();

            //LevelOrderTraversal.Test();

            //GraphBFS.Test();

            //MaxLengthzofPaitChain.FindLongestChain(new int[][]{
            //    new int[]{ 5,24},
            //    new int[] {39,40},
            //    new int[] { 15,28},
            //    new int[] { 27,41},
            //    new int[]{ 50,90} });

            //LongestCommonSubsequenceClass.LongestCommonSubsequence("abcbcba", "abcba");
            //LongestIncreasingSubsequence.Test();

            //ReverseLinkedListInGroups.Test();
            //CountTriplets.Test();

            //ContiguousSubArraySum.Test();

            //ReArrangeElementsAlt.Test();

            //Count7sUsingRecursion.Test();

            //NumberPermutations.Test();

            //CombinationalSum.Test();
            //SubsetsClass.Test();

            //WordSearch.Test();

            //GroupAnagramsClass.Test();

            //GraphDFS.Test();

            //DetectCycleDFS.Test();

            //DijstraShortestpath.Test();

            //DijkstraShortestPathAdjList.Test();

            //ZerosAndOnesSegregation.Test();

            Console.Read();
        }

        private static void NUmberTriangle()
        {
            int size = 100;

            int[,] a = new int[size + 1, 2 * size];

            for (int i = 0; i < size; i++)
            {
                int lowerBound = size - i - 1;
                int upperBound = size + i - 1;
                int data = i + 1;
                bool increaseData = false;
                for (int j = lowerBound; j <= upperBound; j++)
                {
                    a[i, j] = data;

                    if (data == 1)
                    {
                        increaseData = true;
                    }
                    if (increaseData)
                    {
                        data++;
                    }
                    else
                    {
                        data--;
                    }
                }
                Console.WriteLine();
            }

            for (int i = 0; i < size; i++)
            {
                bool visited = false;
                for (int j = 0; j < 2 * size - 1; j++)
                {
                    if (a[i, j] == 0)
                    {
                        Console.Write("\t");
                    }
                    else
                    {
                        Console.Write(a[i, j] + "\t");
                    }

                    if (a[i, j] == i + 1)
                    {
                        if (visited)
                        {
                            continue;
                        }
                        else
                            visited = true;
                    }
                }
                Console.WriteLine();
            }
        }
    }

    class Graph
    {
        static List<List<int>> adj;
        public Graph(int v)
        {
            adj = new List<List<int>>(v);
            for (int i = 0; i < v; i++)
                adj.Add(new List<int>());
        }
        private void AddEdge(int from, int to)
        {
            adj[from].Add(to);
        }

        public static List<List<int>> GetGraph()
        {
            Graph g = new Graph(4);

            #region simple graph
            //g.AddEdge(0, 1);
            //g.AddEdge(0, 2);
            //g.AddEdge(0, 3);
            #endregion

            #region cyclic graph
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(3, 3);
            #endregion

            return adj;
        }
    }
}
