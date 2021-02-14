using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.TreeProblems
{
    //https://leetcode.com/problems/merge-two-binary-trees/
    class MergeBinaryTrees
    {
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
            {
                return t2;
            }
            if(t2 == null)
            {
                return t1;
            }
            t1.val += t2.val;
            t1.left = MergeTrees(t1?.left, t2?.left);
            t1.right = MergeTrees(t1?.right, t2?.right);
            
            return t1;
        }
    }
}
