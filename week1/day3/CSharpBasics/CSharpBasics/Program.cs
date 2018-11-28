using System;
using System.Collections.Generic;

namespace CSharpBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int x = 0;
            double y = 4.58;
            decimal z = 5.001m;

            string s = "string";
            bool b = true;
            b = false;

            object o = true; //can be ANY type

            var v = "Hello";
            //v = false; Error, type !dynamic

            //control structures
            //loops
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            while(false)
            {
                //while loop
            }

            do
            {
                //do while loop
            } while (false);
            if(false)
            {
                //if
            }
            else if (false)
            {
                //else if
            }
            else
            {
                //else
            }
            List<string> list = new List<string>();
            list.Add("List contents");
            list.
            foreach(var item in list)
            {
                //snippet: cw
                Console.WriteLine(item);
            }
            // C#
            // object-oriented
            // part of .NET platform
            // strongly typed (statically typed)
            // unified type system (primitives inherit from class object)
            // garbage collected ("managed" language)
            // functions !first class, but close enough in practice
            // C# somewhat functional, especially with LINQ
            // asynchronous programming support with Task Prcessing Library
            // exception handling
        }
    }
}
