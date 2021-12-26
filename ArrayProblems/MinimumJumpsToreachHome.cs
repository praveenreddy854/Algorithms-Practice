namespace Algorithms_Practice.ArrayProblems
{
    using System;
    using System.Collections.Generic;
    //https://leetcode.com/problems/minimum-jumps-to-reach-home/
    public class MinimumJumpsToreachHome
    {
        public int MinimumJumps(int[] forbidden, int a, int b, int x) 
        {
            
            HashSet<int> forbiddenSet = new HashSet<int>();

            foreach(int f in forbidden)
            {
                forbiddenSet.Add(f);
            }

            Queue<JumpEntity> q = new Queue<JumpEntity>();

            q.Enqueue(new JumpEntity(0, false, 0));

            while(q.Count > 0)
            {
                var currentJumpEntity = q.Dequeue();

                if(currentJumpEntity.CurrentPosition == x)
                {
                    return currentJumpEntity.MinJumps;
                }

                if(forbiddenSet.Contains(currentJumpEntity.CurrentPosition))
                {
                    continue;
                }

                forbiddenSet.Add(currentJumpEntity.CurrentPosition);

                if(currentJumpEntity.IsRightJump && !forbiddenSet.Contains(currentJumpEntity.CurrentPosition - b) && currentJumpEntity.CurrentPosition - b >= 0)
                {
                    q.Enqueue(new JumpEntity(currentJumpEntity.CurrentPosition - b, false, currentJumpEntity.MinJumps + 1));
                }
                if(!forbiddenSet.Contains(currentJumpEntity.CurrentPosition + a) && currentJumpEntity.CurrentPosition + a < 10000)
                {
                    q.Enqueue(new JumpEntity(currentJumpEntity.CurrentPosition + a, true, currentJumpEntity.MinJumps + 1));
                }
            }
            return -1;
        }
    }

    public class JumpEntity
    {
        public int CurrentPosition { get; set; }
        public bool IsRightJump { get; set; }
        public int MinJumps { get; set; }

        public JumpEntity(int currentPosition, bool isRightJump, int minJumps)
        {
            this.CurrentPosition = currentPosition;
            this.IsRightJump = isRightJump;
            this.MinJumps = minJumps;
        }   
    }
}