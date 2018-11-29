using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Arrays();
            Lists();
            Sets();
            StringEquality();
            Dictionaries();
        }

        static void Arrays()
        {
            int[] intArray = new int[10];
            Console.WriteLine(intArray[5]);

            for (int i = 0; i < intArray.Length; i++)
                Console.Write(intArray[i]);
            Console.WriteLine();

            foreach (var item in intArray)
                Console.Write(item);
            Console.WriteLine();
            // foreach works for anything implementing IEnumerable(also used with LINQ)

            int[][] arrayOfArrays = new int[4][];
            arrayOfArrays[0] = new int[3];
            Console.WriteLine(arrayOfArrays[0][0]);

            int[,] trueMultiDArrary = new int[5,5];
            trueMultiDArrary[3, 4] = 5;

            // use generic collection classes for everything !performance critical
            // write first, optimize later

            int[] array = new int[]
            {
                4, 8, 3, 2, 1, 2
            };
        }
        static void Lists()
        {
            var list = new List<bool>();

            list.Add(true);
            list.Add(true);
            list.Add(false);

            //dynamic size, use instead of arrays

            var list2 = new List<bool>() { false, false, false };
            list2.AddRange(list);

            var x = list2[2];
            list[1] = true;
        }
        static void Sets()
        {
            var set = new HashSet<string>();
            // Sets are unordered and do not allow duplicates
            set.Add("abc");
            set.Add("abc");
            set.Add("def");

            Console.WriteLine(set.Count);

            // union, intersection, difference
            // sets are fast to search (HashTable)
            // slightly slower to iterate
        }

        static void Dictionaries()
        {
            var dict = new Dictionary<string, string>
            {
                { "Germany", "Berlin" },
                { "USA", "Washington D.C." }
            };

            Console.WriteLine(dict["USA"]);

            dict["Mexico"] = "Mexico City";
            foreach (var key in dict.Keys)
            {

            }
            foreach (var value in dict.Values)
            {

            }
            foreach (KeyValuePair<string, string> pair in dict)
            {

            }
        }

        static void StringEquality()
        {
            bool stringsEqual = "abc" == "abc";
            Console.WriteLine(stringsEqual);

            //strings compare value !reference
        }
    }
}
