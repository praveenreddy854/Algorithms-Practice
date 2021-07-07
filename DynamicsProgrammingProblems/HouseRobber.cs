using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DynamicsProgrammingProblems
{
    class HouseRobber
    {
        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            nums[1] = Math.Max(nums[0], nums[1]);
            for(int i=2;i<nums.Length;i++)
            {
                nums[i] = Math.Max(nums[i - 2] + nums[i], nums[i - 1]);
            }
            return nums[nums.Length - 1];
        }
    }
}
