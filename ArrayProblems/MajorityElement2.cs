namespace Algorithms_Practice.ArrayProblems
{
    using System.Collections.Generic;
    public class MajorityElement2
    {
        public IList<int> MajorityElement(int[] nums) {
            List<int> result = new List<int>();
            int candidate1 = int.MaxValue;
            int candidate2 = int.MaxValue;;

            int counter1 = 0;
            int counter2 = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                if(candidate2 != nums[i] && counter1 == 0)
                {
                    candidate1 = nums[i];
                    counter1 = 1;
                }
                else if(candidate1 != nums[i] && counter2 == 0)
                {
                    candidate2 = nums[i];
                    counter2 = 1;
                }
                else if(candidate1 == nums[i])
                {
                    counter1++;
                }
                else if(candidate2 == nums[i])
                {
                    counter2++;
                }
                else
                {
                    counter1--;
                    counter2--;
                }

            }

            counter1 = 0;
            counter2 = 0;

            foreach(int num in nums)
            {
                if(candidate1 == num)
                {
                    counter1++;
                }
                else if(candidate2 == num)
                {
                    counter2++;
                }
            }
            if(counter1 > nums.Length / 3)
            {
                result.Add(candidate1);
            }
            if(counter2 > nums.Length / 3)
            {
                result.Add(candidate2);
            }
            return result;
        }
        public static void Test()
        {
            MajorityElement2 majorityElement2 = new MajorityElement2();
            majorityElement2.MajorityElement(new int[]{2,1,1,3,1,4,5,6});
        }
    }

}