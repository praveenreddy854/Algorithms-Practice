namespace Algorithms_Practice.BackTracking
{
    using System.Collections.Generic;
    using System;
    public class CombinationalSum2
    {
        int[] candidates;
        int target;
        IList<IList<int>> result = new List<IList<int>>();
        public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
            Array.Sort(candidates);
            this.candidates = candidates;
            this.target = target;
            Helper(0, new List<int>(), 0);
            return result;
        }
        private int Helper(int sum, IList<int> list, int index)
        {
            if(sum == target)
            {
                result.Add(new List<int>(list));
                return 0;
            }
            if(sum > target)
            {
                return -1;
            }

            for(int i = index; i < candidates.Length; i++)
            {
                if(i > index && candidates[i -1] == candidates[i])
                {
                    continue;
                }
                list.Add(candidates[i]);
                int ret = Helper(sum + candidates[i], list, i + 1);
                list.RemoveAt(list.Count - 1);
                if(ret == -1)
                {
                    break;
                }
            }
            return 0;
        }

        public static void Test()
        {
            CombinationalSum2 obj = new CombinationalSum2();
            obj.CombinationSum2(new int[]{10,1,2,7,6,1,5}, 8);
        }
    }
}