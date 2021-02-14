using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.TreeProblems
{
    //https://leetcode.com/problems/diameter-of-binary-tree/
    class DiameterOfBinaryTreeClass
    {
        int diameter = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            return Math.Max(DiameterOfBinaryTreeUtils(root), diameter);
        }

        private int DiameterOfBinaryTreeUtils(TreeNode root)
        {
            if (root == null)
            {
                return -1;
            }
            int leftLenght = DiameterOfBinaryTreeUtils(root.left) + 1;
            int rightLenght = DiameterOfBinaryTreeUtils(root.right) + 1;
            diameter = Math.Max(diameter, leftLenght + rightLenght);
            return Math.Max(leftLenght, rightLenght);
        }
    }
}
