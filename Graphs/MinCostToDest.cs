namespace Algorithms_Practice.Graphs
{
    // Given a list of streets in a matrix
    // 1 on a cell indicates it has road from its adjucent street, 0 indicates it doesn't
    // Find min cost from vertex 0,0 to to a given dest if no such road return -1

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MinCostToDest
    {
        PathTree tree;
        int[,] pathMatrix = new int[4,4]{
            {1,1,1,0},
            {0,1,1,1},
            {1,1,0,1},
            {1,1,1,1}
        };

        int rows = 0;
        int columns = 0;
        bool[,] visited = new bool[4,4]{
            {false, false, false, false},
            {false, false, false, false},
            {false, false, false, false},
            {false, false, false, false}
        };

        int[,] costFromSource = new int[4,4]
        {
            {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue},
            {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue},
            {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue},
            {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue}
        };

        Queue<PathNode> queue = new Queue<PathNode>();
        public MinCostToDest()
        {
            tree = new PathTree();
            tree.Root = new PathNode();
            rows = pathMatrix.GetLength(1);
            columns = pathMatrix.GetLength(0);
        }

        public int GetMinCost(PathNode dest)
        {
            PathNode root = ConstructPathTree(dest, 0, 0, tree.Root);
            root.minCostFromSource = 0;
            queue.Enqueue(root);
            PouplateMinCostHelper(root);

            queue = new Queue<PathNode>();
            queue.Enqueue(root);
            return GetMinCostHelper(root, dest);
        }
        public static void Test()
        {
            MinCostToDest obj = new MinCostToDest();
            System.Console.WriteLine("Actual {0} : Epected {1}", obj.GetMinCost(new PathNode(){rowIndex = 1, columnIndex = 0}), -1);
            obj = new MinCostToDest();
            System.Console.WriteLine("Actual {0} : Epected {1}", obj.GetMinCost(new PathNode(){rowIndex = 3, columnIndex = 0}), 5);
            obj = new MinCostToDest();
            System.Console.WriteLine("Actual {0} : Epected {1}", obj.GetMinCost(new PathNode(){rowIndex = 1, columnIndex = 3}), 4);
        }

        private int GetMinCostHelper(PathNode root, PathNode dest)
        {
            PathNode temp = root;
            while(queue.Count > 0 && !(root.rowIndex == dest.rowIndex & root.columnIndex == dest.columnIndex))
            {
                root = queue.Dequeue();
                if(root.Left != null)
                {
                    queue.Enqueue(root.Left);
                }
                if(root.Right != null)
                {
                    queue.Enqueue(root.Right);
                }
                // if(root.Top != null)
                // {
                //     queue.Enqueue(root.Top);
                // }
                if(root.Bottom != null)
                {
                    queue.Enqueue(root.Bottom);
                }
            }
            if(queue.Count == 0)
            {
                return -1;
            }
            else
            {
                return root.minCostFromSource;
            }
        }

        private void PouplateMinCostHelper(PathNode root)
        {
            PathNode temp = root;
            while(queue.Count > 0)
            {
                root = queue.Dequeue();
                if(root.Left != null)
                {
                    root.Left.minCostFromSource = Math.Min(root.Left.minCostFromSource, root.minCostFromSource + 1);
                    queue.Enqueue(root.Left);
                }
                if(root.Right != null)
                {
                    root.Right.minCostFromSource = Math.Min(root.Right.minCostFromSource, root.minCostFromSource + 1);
                    queue.Enqueue(root.Right);
                }
                // if(root.Top != null)
                // {
                //     root.Top.minCostFromSource = Math.Min(root.Top.minCostFromSource, root.minCostFromSource + 1);
                //     queue.Enqueue(root.Top);
                // }
                if(root.Bottom != null)
                {
                    root.Bottom.minCostFromSource = Math.Min(root.Bottom.minCostFromSource, root.minCostFromSource + 1);
                    queue.Enqueue(root.Bottom);
                }
            }
            root = temp;
            
            // root.Left.minCostFromSource = root.Left == null ? int.MaxValue : Math.Min(root.minCostFromSource + 1, GetMinCostHelper(root.Left));
            // root.Right.minCostFromSource = root.Right == null ? int.MaxValue :  Math.Min(root.minCostFromSource + 1, GetMinCostHelper(root.Right));
            // root.Top.minCostFromSource = root.Top == null ? int.MaxValue : Math.Min(root.minCostFromSource + 1, GetMinCostHelper(root.Top));
            // root.Bottom.minCostFromSource = root.Bottom == null ? int.MaxValue : Math.Min(root.minCostFromSource + 1, GetMinCostHelper(root.Bottom));
            // return root.minCostFromSource;
        }
        public PathNode ConstructPathTree(PathNode dest, int currentRow, int currentColumn, PathNode root)
        {
            if((currentRow < 0 || currentColumn < 0) || (currentRow >= rows || currentColumn >= columns) || (visited[currentRow, currentColumn]))
            {
                return null;
            }

            if(pathMatrix[currentRow, currentColumn] == 0)
            {
                return null;
            }

            if(root == null)
            {
                root = new PathNode(){ rowIndex = currentRow, columnIndex = currentColumn };
                visited[currentRow, currentColumn] = true;
            }

            root.Left = ConstructPathTree(dest, currentRow, currentColumn - 1, root.Left);
            root.Bottom = ConstructPathTree(dest, currentRow + 1, currentColumn, root.Bottom);
            root.Right = ConstructPathTree(dest, currentRow, currentColumn + 1, root.Right);
            //root.Top = ConstructPathTree(dest, currentRow - 1, currentColumn, root.Top);

            visited[currentRow, currentColumn] = true;

            return root;
        }

    }
    public class PathTree
    {
        public PathNode Root{get;set;}
    }
    public class PathNode
    {
        public PathNode()
        {
            minCostFromSource = int.MaxValue;
        }
        public int minCostFromSource{get;set;}
        public int rowIndex{get;set;}
        public int columnIndex{get;set;}
        public PathNode Left{get;set;}
        public PathNode Bottom{get;set;}
        public PathNode Top{get;set;}
        public PathNode Right{get;set;}
    }
}