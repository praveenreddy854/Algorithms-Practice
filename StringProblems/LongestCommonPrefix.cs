using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringProblems
{
    class LongestCommonPrefixClass
    {
        public static string LongestCommonPrefix(string[] strs)
        {
            int prefixLenght = 0;
            try
            {
                for (int i = 0; i <= 200; i++)
                {
                    char temp = default(char);
                    for (int j = 0; j < strs.Length; j++)
                    {
                        if (temp == default(char))
                        {
                            temp = (strs[j])[i];
                        }
                        else
                        {
                            if (temp != (strs[j])[i])
                            {
                                return strs[0].Substring(0,prefixLenght);
                            }
                        }
                    }
                    prefixLenght++;
                }
            }
            catch
            {
                return strs[0].Substring(0, prefixLenght);
            }

            return "";
        }
    }
}
