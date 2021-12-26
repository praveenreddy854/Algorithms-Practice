using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Amazon
{
    public class LargestItemAssociation
    {
        // Time complexity : O(n) as dictionary lookup is O(1)
        // Space complexity : O(n)
        public List<String> largestItemAssociation(List<PairString> itemAssociation)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            int max = 0;
            string maxKey = "";
            foreach(PairString pairString in itemAssociation)
            {
                bool first = false;
                bool second = false;
                if((first = dict.ContainsKey(pairString.first)) || (second = dict.ContainsKey(pairString.second)))
                {
                    if(!first)
                    {
                        dict[pairString.second].Add(pairString.first);
                        dict[pairString.first] = new List<string>() { pairString.first, pairString.second };
                    }
                    else
                    {
                        dict[pairString.first].Add(pairString.second);
                        dict[pairString.second] = new List<string>() { pairString.first, pairString.second };
                    }
                }
                else
                {
                    dict[pairString.first] = new List<string>() { pairString.first, pairString.second };
                    dict[pairString.second] = new List<string>() { pairString.first, pairString.second };
                }
            }
            SortedSet<string> result = new SortedSet<string>();
            SortedSet<string> temp = new SortedSet<string>();
            foreach (var kp in dict)
            {
                foreach(string item in kp.Value)
                {
                    temp = new SortedSet<string>(dict[kp.Key].Union(dict[item]));
                }
                int count = temp.Count();
                if(count < max)
                {
                    continue;
                }
                if(count > max)
                {
                    max = count;
                    result = temp;
                }
                else if (count == max)
                {
                    string firstRef = temp.FirstOrDefault();
                    string firstDiff = result.FirstOrDefault();
                    for (int i = 0; i < firstRef.Length; i++)
                    {
                        if (firstRef[i] == firstDiff[i])
                        {
                            continue;
                        }
                        else if (firstRef[i] > firstDiff[i])
                        {
                            break;
                        }
                        else
                        {
                            result = temp;
                        }
                    }
                }
            }
            List<string> ret = new List<string>();
            foreach(var r in result)
            {
                ret.Add(r);
            }
            return ret;
        }

        private static void TestInternal(List<PairString> itemAssociation, List<string> expected)
        {
            LargestItemAssociation obj = new LargestItemAssociation();
            List<string> ret = obj.largestItemAssociation(itemAssociation);
            if(ret.Equals(expected))
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
        public static void Test()
        {
            List<PairString> itemAssociation = new List<PairString>{
                new PairString("item1", "item2"),
                new PairString("item2", "item3"),
                new PairString("item4", "item5"),
                new PairString("item6", "item7"),
                new PairString("item5", "item6"),
                new PairString("item3", "item7")};
            //List<PairString> itemAssociation = {new PairString("item1","item2"), new PairString("item3","item4"), new PairString("item4","item5")};
            //List<PairString> itemAssociation = {new PairString("item1","item2"), new PairString("item3","item4"), new PairString("item5", "item6")};
            //List<PairString> itemAssociation = {new PairString("item1","item2"), new PairString("item2","item3"), new PairString("item4", "item5"), new PairString("item5","item6")};
            TestInternal(itemAssociation, new List<string> { "item1", "item2", "item3", "item7"});

        }
    }
    public class PairString
    {
        public String first { get; set; }
        public String second { get; set; }

        public PairString(String first, String second)
        {
            this.first = first;
            this.second = second;
        }
    }

    
}
