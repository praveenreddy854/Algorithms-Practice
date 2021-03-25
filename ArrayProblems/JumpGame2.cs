namespace Algorithms_Practice.ArrayProblems
{
    using System;
    using System.Collections.Generic;
    //https://leetcode.com/problems/jump-game-ii/
    public class JumpGame2
    {
        public int Jump(int[] nums) {
            Queue<JumpEntity> jumpQueue = new Queue<JumpEntity>();
            int length = nums.Length;
            HashSet<int> visited = new HashSet<int>();

            if(length < 2)
            {
                return 0;
            }

            jumpQueue.Enqueue(new JumpEntity{Index = 0, JumpsSoFar = 0, MaxJumps = nums[0]});

            while(jumpQueue.Count > 0)
            {
                  JumpEntity j = jumpQueue.Dequeue();
                  int maxJumps = j.MaxJumps;
                  for(int i = 1; i <= maxJumps && i < length; i++)
                  {
                      int newIndex = j.Index + i;
                      int newJumpsSoFar = j.JumpsSoFar + 1;
                      if(newIndex == length - 1)
                      {
                          return newJumpsSoFar;
                      }
                      if(visited.Contains(newIndex))
                      {
                          continue;
                      }
                      if(newIndex >= length)
                      {
                          break;
                      }
                     visited.Add(newIndex);
                      jumpQueue.Enqueue(new JumpEntity { Index = newIndex, JumpsSoFar = newJumpsSoFar, MaxJumps = nums[newIndex] });
                  }
            }
            return 0;
        }
        public class JumpEntity
        {
            public int Index { get; set; }
            public int JumpsSoFar { get; set; }
            public int MaxJumps { get; set; }
        }
    }
}