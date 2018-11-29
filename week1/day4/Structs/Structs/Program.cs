using System;

namespace Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = new int();
            Int32 xyz = 4;

            // value types => seperate copies
            // structs and enums == value types
            int a = 1;
            int b = a;

            //reference types => seperate references to one copy
            string c = "asdf";
            string d = c;

            string s = 123.ToString();
            
            Console.WriteLine(s);

            // Don't Repeat Yourself, use methods/classes
            // Comment: inline, multiline & XML
            // XML for all classes & public/protected members (public API)
            // In VS ^k ^c to comment, ^k ^u to uncomment
            // Keep It Simple Stupid

        }
    }
}
