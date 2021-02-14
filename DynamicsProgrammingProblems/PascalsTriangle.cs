using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DynamicsProgrammingProblems
{
    class PascalsTriangle
    {
        public static IList<IList<int>> Generate(int numRows)
        {
            int[][] a = new int[numRows+1][];
            IList<IList<int>> lists = new List<IList<int>>();
            a[0] = new int[numRows + 1];
            for(int i=1;i<= numRows; i++)
            {
                IList<int> list = new List<int>();
                a[i] = new int[i+2];
                for (int j=1;j<=i;j++)
                {
                    if(i==j)
                    {
                        a[i][j] = 1;
                    }
                    else
                    {
                        a[i][j] = a[i - 1][j] + a[i - 1][j - 1];
                    }
                    list.Add(a[i][j]);
                }
                lists.Add(list);
            }
            return lists;
        }
    }
}
