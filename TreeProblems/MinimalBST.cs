namespace Algorithms_Practice.TreeProblems
{
    // Given an array of ints in increasing order. Find Minimal height of BST can be built
    public class MinimalBST
    {
        public void GetMinimalBST(int[] inputArray)
        {
            BST bst = new BST();
            bst.Root = GetMinimalBSTHelper(bst.Root, inputArray, 0, inputArray.Length - 1);
        }
        private Node GetMinimalBSTHelper(Node root, int[] input, int low, int high)
        {
            if(low == high)
            {
                return new Node(input[low]);
            }
            if(low > high)
            {
                return null;
            }
            int mid = (low + high) / 2;
            root = new Node(input[mid]);
            root.Left = GetMinimalBSTHelper(root.Left, input, low, mid - 1);
            root.Right = GetMinimalBSTHelper(root.Right, input, mid + 1, high);
            return root;
        }
        public static void Test()
        {
            MinimalBST minimalBST = new MinimalBST();
            int[] inputArray = new int[10] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            minimalBST.GetMinimalBST(inputArray);
        }
    }
    public class BST{
        public Node Root { get; set; }
        
    }
    public class Node {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Data { get; set; }
        public Node(int data, Node left = null, Node right = null)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
        }
    }
}