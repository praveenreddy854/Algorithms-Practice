using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.TreeProblems
{
    class MaxDepthBT
    {
        private int Depth { get; set; }
        public int MaxDepth(TreeNode root)
        {
            return MaxDepthUtils(root, 0);
        }

        private int MaxDepthUtils(TreeNode root, int max)
        {
            if(root == null)
            {
                return max;
            }
            max++;

            if(max > Depth)
            {
                Depth = max;
            }
            MaxDepthUtils(root.left, max);
            MaxDepthUtils(root.right, max);
            return Depth;
        }
    }
}
