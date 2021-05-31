namespace Algorithms_Practice.ArrayProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    //https://leetcode.com/problems/subsets-ii/
    public class Subsets2
    {
        private IList<IList<int>> result = new List<IList<int>>();
        int[] nums;
        public IList<IList<int>> SubsetsWithDup(int[] nums) {
            Array.Sort(nums);
            this.nums = nums;
            result.Add(new List<int>());
            SubsetsWithDupHelper(new List<int>(), 0);
            return result;
        }
        private void SubsetsWithDupHelper(List<int> list , int index)
        {
            for(int i = index; i < nums.Length; i++)
            {
                if(i > index && nums[i] == nums[i - 1])
                {
                    continue;
                }
                list.Add(nums[i]);
                result.Add(new List<int>(list));
                SubsetsWithDupHelper(list, i + 1);

                if(list.Count == 1 && i == nums.Length - 1)
                {
                    return;
                }
                list.RemoveAt(list.Count - 1);
            }
        }

        public static void Test()
        {
            Subsets2 obj = new Subsets2();
            obj.SubsetsWithDup(new int[]{1,2,2});
        }
    }
}