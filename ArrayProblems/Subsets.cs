namespace ConsoleApp1.ArrayProblems
{
    using System;
    using System.Collections.Generic;
    public class SubsetsClass
    {
        //https://leetcode.com/problems/subsets/
        private IList<IList<int>> AllSubsets{get;set;}
        private int[] nums;
        public IList<IList<int>> Subsets(int[] nums) {
            this.nums = nums;
            AllSubsets = new List<IList<int>>();
            AllSubsets.Add(new List<int>());
            SubsetsHelper(new List<int>(), 0);
            return AllSubsets;
        }
        private void SubsetsHelper(IList<int> list, int index)
        {
            for(int i = index; i < nums.Length; i++)
            {
                list.Add(nums[i]);
                AllSubsets.Add(new List<int>(list));
                SubsetsHelper(list, i + 1);

                if(list.Count == 1 && i == nums.Length - 1)
                {
                    return;
                }
                list.RemoveAt(list.Count - 1);
            }
        }

        public static void Test()
        {
            SubsetsClass obj = new SubsetsClass();
            obj.Subsets(new int[]{1,3,5,7,9});
        }
        
    }
}