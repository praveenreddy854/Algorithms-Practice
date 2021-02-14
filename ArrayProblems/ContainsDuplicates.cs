using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    class ContainsDuplicates
    {
        public bool ContainsDuplicate(int[] nums)
        {
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            for(int i=0;i<nums.Length;i++)
            {
                if(dict.ContainsKey(nums[i]))
                {
                    return true;
                }
                dict[nums[i]] = true;
            }
            return false;
        }
    }
}
