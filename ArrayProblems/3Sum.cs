using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    class _3Sum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            int len = nums.Length;
            IList<IList<int>> res = new List<IList<int>>();
            if(len < 3)
            {
               return res;
            }
            Array.Sort(nums);
            
            int lastIndex = len - 1;
            for(int i=0;i < lastIndex;i++)
            {
                int j = i + 1;
                int k = lastIndex;
                while(j < k)
                {
                    int sum = nums[k] + nums[j] + nums[i];

                    if (sum < 0)
                    {
                        j++;
                    }
                    else if(sum > 0)
                    {
                        k--;
                    }
                    else
                    {
                        res.Add(new List<int> { nums[k], nums[j], nums[i] });
                        j++;
                        while(j < lastIndex && nums[j] == nums[j - 1])
                        {
                            j++;
                        }
                    }
                }
                while(i < lastIndex && nums[i] == nums[i + 1])
                {
                    i++;
                }
            }
            return res;
        }
    }
}
