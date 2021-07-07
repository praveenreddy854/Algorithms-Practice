namespace Algorithms_Practice.TreeProblems
{
    using System;
    using System.Collections.Generic;
    public class SubtreeWithAllDeepestClass
    {

        IDictionary<int, TreeNode> parentTrackerDict;
        TreeNode leftMostLeaf;
        int leftMostDepth;
        TreeNode rightMostLeaf;
        int rightMostDepth;
        public TreeNode SubtreeWithAllDeepest(TreeNode root) {
            parentTrackerDict = new Dictionary<int, TreeNode>();
            parentTrackerDict.Add(new KeyValuePair<int, TreeNode>(root.val, null));
            leftMostDepth = 0;
            rightMostDepth = 0;
            leftMostLeaf = root;
            rightMostLeaf = root;
            PopulateParentTracker(root, root, 0);
            return GetSubTreeWithDeepestNodes();
        }
        private void PopulateParentTracker(TreeNode root, TreeNode parent, int depth) { 
            if(root == null)
            {
                if(leftMostDepth < depth)
                {
                    leftMostLeaf = parent;
                    leftMostDepth = depth;
                }
                if(rightMostDepth <= depth)
                {
                    rightMostLeaf = parent;
                    rightMostDepth = depth;
                }
                return;
            }

            PopulateParentTracker(root.left, root, depth + 1);
            PopulateParentTracker(root.right, root, depth + 1);

            parentTrackerDict.Add(new KeyValuePair<int, TreeNode>(root.val, parent));
        }

        private TreeNode GetSubTreeWithDeepestNodes()
        {
            int leftLeaf = leftMostLeaf.val;
            int rightLeaf = rightMostLeaf.val;
            if(leftLeaf == rightLeaf)
            {
                return leftMostLeaf;
            }

            while(parentTrackerDict[leftLeaf].val != parentTrackerDict[rightLeaf].val)
            {
                leftLeaf = parentTrackerDict[leftLeaf].val;
                rightLeaf = parentTrackerDict[rightLeaf].val;
            }
            return parentTrackerDict[leftLeaf];
        }
        public static void Test()
        {
            SubtreeWithAllDeepestClass subtreeWithAllDeepestClass = new SubtreeWithAllDeepestClass();
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(5);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(6);
            root.left.right = new TreeNode(2);
            root.right.left = new TreeNode(0);
            root.right.right = new TreeNode(8);
            root.left.right.left = new TreeNode(7);
            root.left.right.right = new TreeNode(4);
            subtreeWithAllDeepestClass.SubtreeWithAllDeepest(root);
        }
    }
}