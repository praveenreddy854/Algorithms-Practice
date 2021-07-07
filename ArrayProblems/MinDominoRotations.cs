using System;

namespace Algorithms_Practice.ArrayProblems
{
    //https://leetcode.com/problems/minimum-domino-rotations-for-equal-row/
    public class MinDominoRotationsClass
    {
        public int MinDominoRotations(int[] tops, int[] bottoms) {
            int minRotations = int.MaxValue;
            minRotations = Math.Min(minRotations,MinDominoRotationHelper(tops, bottoms, tops[0]));
            minRotations = Math.Min(minRotations,MinDominoRotationHelper(tops, bottoms, bottoms[0]));
            minRotations = Math.Min(minRotations,MinDominoRotationHelper(bottoms, tops, bottoms[0]));
            minRotations = Math.Min(minRotations,MinDominoRotationHelper(bottoms, tops, tops[0]));
            return minRotations == int.MaxValue ? -1 : minRotations;
        }
        private int MinDominoRotationHelper(int[] tops, int[]  bottoms, int reference) {
            int counter = 0;
            for(int i = 0; i < tops.Length; i++)
            {
                if(reference == tops[i])
                {
                    continue;
                }
                if(reference == bottoms[i])
                {
                    counter++;
                }
                else
                {
                    return int.MaxValue;
                }
            }
            return counter;
        }
    }
}