using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1.Amazon
{
    class CotactNames
    {
        public List<string> Contacts { get; set; }
    }
    class ContactsClass
    {

        /*
         * Complete the contacts function below.
         */
        static int[] contacts(string[][] queries)
        {

            CotactNames[] CotactNames = new CotactNames[128];
            // number of find operations
            int resultLen = 0;
            for (int k = 0; k < queries.Length; k++)
            {
                if (queries[k][0] == "find")
                {
                    resultLen++;
                }
            }

            int[] res = new int[resultLen];
            for (int i = 0, j = 0; i < queries.Length; i++)
            {
                if (queries[i][0] == "add")
                {
                    int key = (int)queries[i][1][0];
                    if (CotactNames[key] ==  null)
                    {
                        CotactNames[key] = new CotactNames();
                    }
                    if (CotactNames[key].Contacts == null)
                    {
                        CotactNames[key].Contacts = new List<string>();
                    }
                    CotactNames[key].Contacts.Add(queries[i][1]);
                }
                else
                {

                    string partialKey = queries[i][1];
                    res[j] = CotactNames[(int)partialKey[0]].Contacts.Count(x => x.IndexOf(partialKey) == 0);
                    j++;
                }
            }
            return res;
        }

        public static void Test()
        {

            int queriesRows = Convert.ToInt32(Console.ReadLine());

            string[][] queries = new string[queriesRows][];

            for (int queriesRowItr = 0; queriesRowItr < queriesRows; queriesRowItr++)
            {
                queries[queriesRowItr] = Console.ReadLine().Split(' ');
            }

            int[] result = contacts(queries);
            
        }
    }
}

