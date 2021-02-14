using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp1.TreeProblems
{
    class LCABST
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            Stack<TreeNode> sp = new Stack<TreeNode>();
            FindUtil(root, p, sp);
            Stack<TreeNode> sq = new Stack<TreeNode>();
            FindUtil(root, q, sq);

            int diff = sp.Count - sq.Count;

            if(diff > 0)
            {
                for (int i = 0; i < diff; i++)
                {
                    sp.Pop();
                }
            }
            else if(diff < 0)
            {
                for (int i = 0; i < -1 * diff; i++)
                {
                    sp.Pop();
                }
            }

            while(sp.Peek() != sq.Peek())
            {
                Console.WriteLine("sp "+sp.Peek().val);
                Console.WriteLine("sq " + sq.Peek().val);
                sp.Pop();
                sq.Pop();
            }
            return sp.Peek();
            
        }
        private TreeNode FindUtil(TreeNode root, TreeNode find, Stack<TreeNode> s)
        {
            if(find == root)
            {
                return root;
            }
            s.Push(root);
            if(find.val <= root.val)
            {
                root = root.left;
            }
            else
            {
                root = root.right;
            }
            root = FindUtil(root, find, s);
            return root;
        }
    }
}
