namespace ConsoleApp1.ArrayProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class CombinationalSum
    {
        private IList<IList<int>> combinations;
        public IList<IList<int>> CombinationSum(int[] candidates, int target) {
            combinations = new List<IList<int>>();

            // Array.Sort(candidates);
            // int[] newCandidates = new int[candidates.Length + 1];
            // newCandidates[0] = 0;

            // for(int i = 0; i < candidates.Length; i++)
            // {
            //     newCandidates[i + 1] = candidates[i];
            // }
            CombinationSumUtils(candidates, target, new List<int>(), 0, 0);

            // foreach(List<int> list in combinations)
            // {
            //     list.Sort();
            // }
            
            // IList<List<int>> x = combinations.GroupBy(x => String.Join(",", x))
            //              .Select(x => x.First().ToList())
            //              .ToList();

            // return new List<IList<int>>(x);
            return combinations;

        }
        private void CombinationSumUtils(int[] candidates, int target, List<int> list, int sum, int pos)
        {
            if(sum == target)
            {
                combinations.Add(new List<int>(list));
                return;
            }
            if(pos == candidates.Length || sum > target)
            {
                return;
            }

            for(int i = pos; i < candidates.Length; i++)
            {
                list.Add(candidates[i]);
                CombinationSumUtils(candidates, target, list, sum + candidates[i], i);
                list.RemoveAt(list.Count - 1);
            }
        }

        public static void Test()
        {
            CombinationalSum obj = new CombinationalSum();
            int[] candidates = new int[]{2, 3, 6, 7};
            int target = 7;
            obj.CombinationSum(candidates, target);
        }
    }

    public class CusComparer : IEqualityComparer<List<int>>
{
    public bool Equals(List<int> x, List<int> y)
    {
        return x.SequenceEqual(y);
    }

    public int GetHashCode(List<int> obj)
    {
        int hashCode = 0;

        for (var index = 0; index < obj.Count; index++)
        {
            hashCode ^= new {Index = index, Item = obj[index]}.GetHashCode();
        }

        return hashCode;
    }
}
}