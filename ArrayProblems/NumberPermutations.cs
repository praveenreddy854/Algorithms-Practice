namespace ConsoleApp1.ArrayProblems
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class NumberPermutations
    {
        private IList<IList<int>> totalPermutations;
        public IList<IList<int>> Permute(int[] nums) {

            totalPermutations = new List<IList<int>>();
            if(nums.Length == 0)
            {
                return totalPermutations;
            }
            Queue<int> q = new Queue<int>();
            q.Enqueue(int.MaxValue);
            foreach(int num in nums)
            {
                q.Enqueue(num);
            }
            HashSet<Queue<int>> set = new HashSet<Queue<int>>();
            PermuteHelper(q, new List<int>());
            return totalPermutations;

        }
        private void PermuteHelper(Queue<int> q, IList<int> list)
        {
            int current = q.Peek();
            if(current != int.MaxValue)
            {
                list.Add(current);
            }
            if(q.Count == 1)
            {
                totalPermutations.Add(new List<int>(list));
                return;
            }

             q.Dequeue();
             for(int i=0; i<q.Count;i++)
             {
                List<int> clonedList = new List<int>(list);
                PermuteHelper(q, clonedList);
             }
             q.Enqueue(current);
        }

        public static void Test()
        {
            NumberPermutations obj = new NumberPermutations();
            obj.Permute(new int[]{1,2,3});
            System.Console.WriteLine(" ");
        }
    }
}