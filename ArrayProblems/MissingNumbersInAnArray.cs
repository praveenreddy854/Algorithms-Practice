using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    class MissingNumbersInAnArray
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            // nums : [4,2,1,2]
            int i = 0;
            while(i<nums.Length)
            {
                if(nums[i] == 0)
                {
                    i++;
                    continue;
                }
                int temp = nums[nums[i]-1];

                // 4 is kept at index 3. Value zero means this number exists
                nums[nums[i] - 1] = 0;

                while(temp != 0)
                {
                    int temp2 = nums[temp - 1];
                    nums[temp - 1] = 0;
                    temp = temp2;
                }
                i++;
            }

            IList<int> result = new List<int>();
            for(int j = 0; j < nums.Length; j++ )
            {
                if(nums[j] != 0)
                {
                    result.Add(j + 1);
                }
            }
            return result;
        }
    }
}
