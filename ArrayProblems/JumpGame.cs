namespace ConsoleApp1.ArrayProblems
{
    // https://leetcode.com/problems/jump-game/
    public class JumpGame
    {
        private int[] nums;
        enum IndexState{
            Good,
            Bad,
            Unknown
        }

        private IndexState[] indexStates;
        public bool CanJump(int[] nums) {
            this.nums = nums;
            int lastIndex = nums.Length - 1;
            this.indexStates = new IndexState[nums.Length];

            for(int i = 0; i < lastIndex; i++)
            {
                indexStates[i] = IndexState.Unknown;
            }

            indexStates[lastIndex] = IndexState.Good;

            return JumHelper(0, nums[0], lastIndex);
        }
        private bool JumHelper(int index, int maxJumps, int lastIndex)
        {
            if(indexStates[index] != IndexState.Unknown)
            {
                return indexStates[index] == IndexState.Good ? true : false;
            }
            if(index == lastIndex)
            {
                return true;
            }
            if(index > lastIndex)
            {
                return false;
            }
            if(nums[index] == 0)
            {
                return false;
            }

            for(int i = 1; i <= maxJumps; i++)
            {
                int newIndex = index + i;
                if(newIndex > lastIndex)
                {
                    break;
                }
                if(JumHelper(newIndex, nums[newIndex], lastIndex))
                {
                    indexStates[newIndex] = IndexState.Good;
                    return true;
                }
            }
            indexStates[index] = IndexState.Bad;
            return false;
        }
    }
}