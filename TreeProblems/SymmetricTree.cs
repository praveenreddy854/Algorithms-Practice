using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.TreeProblems
{
    public class SymmetricTree
    {
        public bool IsSymmetric(TreeNode root)
        {
            TreeNode temp = DeepClone(root);
            return IsMirrorIterativeLR(root, root) && IsMirrorIterativeRL(temp, temp);

            //return IsMirror(root, root);
        }

        public static bool CheckSymmetricity()
        {
            object[] a = new object[] { 2, 3, 3, 4, 5, null, 4 };
            TreeNode tree = new TreeNode(2);

            tree.left = new TreeNode(3);
            tree.right = new TreeNode(3);
            tree.left.left = new TreeNode(4);
            tree.left.right = new TreeNode(3);
            tree.right.right = new TreeNode(4);
            SymmetricTree s = new SymmetricTree();

            bool res = s.IsSymmetric(tree);
            return res;

        }

        public TreeNode DeepClone(TreeNode obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;
                
                return (TreeNode)formatter.Deserialize(ms);
            }
        }

        private bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
                return true;
            if(left == null || right == null)
            {
                return false;
            }

            return (left.val == right.val) && IsMirror(left.right, right.left) && IsMirror(left.left, right.right);
        }

        private bool IsMirrorIterativeLR(TreeNode left, TreeNode right)
        {
            while (true)
            {
                if (left == null && right == null)
                {
                    return true;
                }
                if ((left == null || right == null))
                {
                    return false;
                }
                if (left.val != right.val)
                {
                    return false;
                }
                left = left.left;
                right = right.right;
            }
        }

        private bool IsMirrorIterativeRL(TreeNode left, TreeNode right)
        {
            while (true)
            {
                if (left == null && right == null)
                {
                    return true;
                }
                if((left == null || right == null))
                {
                    return false;
                }
                if (left.val != right.val)
                {
                    return false;
                }
                left = left.right;
                right = right.left;
            }
        }
        
    }

    [Serializable]
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
