namespace ConsoleApp1.ArrayProblems
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    // https://leetcode.com/problems/merge-intervals/
    public class MergeIntervals
    {
        public int[][] Merge(int[][] intervals) {

            if(intervals.Length == 0)
            {
                return new int[0][];
            }
            
            Array.Sort(intervals, new IntervalComparer());
            Stack<int[]> stack = new Stack<int[]>();
            stack.Push(intervals[0]);

            for(int i = 0; i < intervals.Length; i++)
            {
                int[] temp = stack.Pop();
                
                if(temp[1] >= intervals[i][0])
                {
                    temp[1] = Math.Max(temp[1], intervals[i][1]);
                    stack.Push(temp);
                }
                else
                {
                    stack.Push(temp);
                    stack.Push(intervals[i]);
                }
            }

            int[][] result = new int[stack.Count][];
            int j = 0;

            while(stack.Count > 0)
            {
                result[j] = stack.Pop();
                j++;
            }
            return result;
        }
    }
    public class IntervalComparer: IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            int[] x1 = (int[])x;
            int[] y1 = (int[])y;
            if(x1[0] >= y1[0])
            {
                return 1;
            }
            return -1;
        }
    }
}