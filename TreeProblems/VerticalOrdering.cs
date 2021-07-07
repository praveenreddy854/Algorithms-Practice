namespace Algorithms_Practice.TreeProblems
{
    //https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/
    using System.Collections.Generic;
    using System.Linq;
    public class VerticalOrdering
    {
        private Dictionary<int, IList<TreeNodeOrder>> verticalOrderDict;
        private KeyValuePair<int, IList<TreeNodeOrder>>[] verticalOrderMinHeap;
        private IList<IList<int>> resultMinHeap;
        private int heapSize;
        public IList<IList<int>> VerticalTraversal(TreeNode root) {
             verticalOrderDict = new Dictionary<int, IList<TreeNodeOrder>>();
             resultMinHeap = new List<IList<int>>();
             heapSize = 0;
             VerticalTraversalHelper(root, 0, 0);
             verticalOrderMinHeap = new KeyValuePair<int, IList<TreeNodeOrder>>[verticalOrderDict.Count];
             InsertToMinHeap();

             foreach(var kp in verticalOrderMinHeap)
             {
                 System.Console.WriteLine(kp.Key);
             }
             OrderByNodeValues();
             return resultMinHeap;
        }

        private TreeNode VerticalTraversalHelper(TreeNode root, int row, int col)
        {
            if(root == null)
            {
                return root;
            }
            
            root.left = VerticalTraversalHelper(root.left, row + 1, col - 1);

            if(!verticalOrderDict.ContainsKey(col))
            {
                var treeNodeOrderList = new List<TreeNodeOrder>();
                treeNodeOrderList.Add(new TreeNodeOrder(root, row, col));
                verticalOrderDict.Add(col, new List<TreeNodeOrder>(treeNodeOrderList));
            }
            else
            {
                verticalOrderDict[col].Add(new TreeNodeOrder(root, row, col));
            }

            root.right = VerticalTraversalHelper(root.right, row + 1, col + 1);
            return root;
        }

        private void InsertToMinHeap()
        {
           foreach(var kp in verticalOrderDict)
           {
               verticalOrderMinHeap[heapSize++] = kp;
               Heapify(heapSize - 1);
           }
        }
        private void Heapify(int pos)
        {
            int parent = pos / 2;

            while(verticalOrderMinHeap[pos].Key < verticalOrderMinHeap[parent].Key)
            {
                Swap(pos, parent);
                Heapify(parent);
            }
        }
        private void DeleteHeapify(int pos){
            int leftChildPos = 2 * pos + 1;
            int rightChildPos = 2 * pos + 2;
            int smallest = pos;

            if(leftChildPos < heapSize && verticalOrderMinHeap[leftChildPos].Key < verticalOrderMinHeap[smallest].Key)
            {
                smallest = leftChildPos;
            }
            if(rightChildPos < heapSize && verticalOrderMinHeap[rightChildPos].Key < verticalOrderMinHeap[smallest].Key)
            {
                smallest = rightChildPos;
            }

            if(smallest != pos)
            {
                Swap(smallest, pos);
                DeleteHeapify(smallest);
            }
        }
        private KeyValuePair<int, IList<TreeNodeOrder>> ExtractMinFromHeap()
        {
            var result = verticalOrderMinHeap.FirstOrDefault();
            heapSize--;
            Swap(0, heapSize);
            DeleteHeapify(0);
            return result;
        }
        private void Swap(int index1, int index2)
        {
            var temp = verticalOrderMinHeap[index1];
            verticalOrderMinHeap[index1] = verticalOrderMinHeap[index2];
            verticalOrderMinHeap[index2] = temp;
        }

        private void OrderByNodeValues()
        {
            //var sortedDict  = verticalOrderDict.OrderBy(d => d.Key);
            while(heapSize > 0){
                var verticalOrderKp = ExtractMinFromHeap();
                var sortedVerticalOrderKp = verticalOrderKp.Value.OrderBy(t => t.TreeNode.val).OrderBy(t => t.Row);

                resultMinHeap.Add(sortedVerticalOrderKp.Select( t => t.TreeNode.val).ToList());
            }
        }

        public static void Test()
        {
            VerticalOrdering verticalOrdering = new VerticalOrdering();
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            verticalOrdering.VerticalTraversal(root);
        }
    }
    public class TreeNodeOrder
    {
        public TreeNodeOrder(TreeNode node, int row, int col)
        {
            this.TreeNode = node;
            this.Row = row;
            this.Col = col;
        }
        public TreeNode TreeNode { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}