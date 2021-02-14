namespace ConsoleApp1.ArrayProblems
{
    using System;
    using System.Collections.Generic;

    // https://leetcode.com/problems/merge-intervals/
    public class MergeIntervals
    {
        public int[][] Merge(int[][] intervals) {

            if(intervals.Length == 0)
            {
                return new int[0][];
            }
            int lastStart = 0;
            bool[] skips = new bool[intervals.Length - 1];
            int skipsCounter = 0;

            for(int i = 0; i < intervals.Length - 1; i++)
            {
                if(intervals[i][1] >= intervals[i+1][0])
                {
                    if(lastStart == 0)
                    {
                        lastStart = intervals[i][0];
                    }
                    intervals[i + 1][0] = lastStart;
                    skips[i] = true;
                    skipsCounter++;
                }
                else
                {
                    lastStart = 0;
                }
            }

            int[][] result = new int[intervals.Length - skipsCounter][];

            for(int i = 0, j = 0; i < intervals.Length - 1; i++)
            {
                if(!skips[i])
                {
                    result[j] = intervals[i];
                    j++;
                }
            }

            result[result.Length - 1] = intervals[intervals.Length - 1];

            return result;

            
        }
    }
}