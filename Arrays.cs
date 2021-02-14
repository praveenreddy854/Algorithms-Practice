using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Arrays
    {
        static int[] dp = new int[7];

        class TernaryTree
        {
            public Node Root { get; set; }
            public static Node Construct(Node root, string pos, int data, int dataSub)
            {
                data = data - dataSub;
                if (data < 0)
                {
                    return new Node();
                }
                if (pos == "left")
                {
                    root.Left = new Node(data);
                    root.Left.DataSubtractor = dataSub;
                    return root.Left;
                }
                else if(pos == "mid")
                {
                    root.Middle = new Node(data);
                    root.Middle.DataSubtractor = dataSub;
                    return root.Middle;
                }
                else
                {
                    root.Right = new Node(data);
                    root.Right.DataSubtractor = dataSub;
                    return root.Right;
                }
            }
        }
        class Node
        {
            public Node()
            {

            }
            public Node(int data)
            {
                Data = data;
            }
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Middle { get; set; }
            public Node Right { get; set; }
            public int DataSubtractor { get; set; }
        }
        public static void FindTripleToGetGivenSum()
        {
            int[] a = { 1, 4, 5, 9, 12, 15 };
            int sum = 15;
            bool found = false;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1, k = a.Length - 1; j < k;)
                {
                    int temp = a[i] + a[j] + a[k];
                    if (temp > sum)
                    {
                        k--;
                    }
                    else if (temp < sum)
                    {
                        j++;
                    }
                    else
                    {
                        Console.WriteLine("The triplets are {0} {1} {2}", a[i], a[j], a[k]);
                        found = true;
                        break;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("No triplets found");
            }
        }
        public static void LongestNonRepeatingSubstring()
        {
            string input = "abcababcd";
            List<LNRS> list = new List<LNRS>();
        }

        public static void TargetSumUsingSubsetOfElements()
        {
            int[] a = { 1, 3, 5 };
            TernaryTree tree = new TernaryTree();
            tree.Root = new Node(6);
            int x = TargetSumUsingSubsetOfElementsUtils(6, 0, tree.Root);
            
            Console.WriteLine(x);
        }

        private static int TargetSumUsingSubsetOfElementsUtils(int n, int v, Node root)
        {
            n = n - v;
            
            if(n<0)
            {
                return 0;
            }
            else if(n ==0)
            {
                return 1;
            }
            //if(dp[n] != 0 )
            //{
            //    return dp[n];
            //}
            return dp[n] = TargetSumUsingSubsetOfElementsUtils(n, 1, TernaryTree.Construct(root,"left",n,1)) 
                + TargetSumUsingSubsetOfElementsUtils(n, 3, TernaryTree.Construct(root, "mid", n, 3)) 
                + TargetSumUsingSubsetOfElementsUtils(n, 5, TernaryTree.Construct(root, "right", n, 5));
        }

   
        class LNRS
        {
            public int Count { get; set; }
            public int StartIndex { get; set; }
            public int EndIndex { get; set; }
        }
    }
}
