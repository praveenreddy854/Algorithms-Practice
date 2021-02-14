namespace ConsoleApp1.ArrayProblems
{
    //https://practice.geeksforgeeks.org/problems/merge-two-sorted-arrays-1587115620/1
    public class MergeTwoSortedArrays
    {
        public static void Merge(int[] arr1, int[] arr2, int n, int m) 
        { 
                int i = n - 1;
                int j = 0;

                while(i >= 0 && j < m)
                {
                    if(arr1[i] > arr2[j])
                    {
                        int temp = arr1[i];
                        arr1[i] = arr2[j];
                        arr2[j] = temp; 
                        i--;
                        j++;
                    }
                    else
                    {
                        i--;
                    }
                }
        } 
    }
}