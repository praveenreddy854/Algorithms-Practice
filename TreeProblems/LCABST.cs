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
            if(root == null)
            {
                return root;
            }
            
            if(p.val < root.val && q.val < root.val)
            {
                LowestCommonAncestor(root.left, p, q);
            }
            if(p.val > root.val && q.val > root.val)
            {
                LowestCommonAncestor(root.left, p, q);
            }
            return root;
        }
    }
}
