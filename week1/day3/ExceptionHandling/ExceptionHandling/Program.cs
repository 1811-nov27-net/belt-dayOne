using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BadCode();
                //never runs
                var x = 4;
                var y = x / 0;
                Console.WriteLine("Never prints due to exception");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Don't Divide by Zero");
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Handled Bad Cast");
            }
            Console.WriteLine("Program continues");
            
        }

        static void BadCode()
        {
            try
            {
                object o = true;
                string s = (string)o;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Doesn't Print");
            }
        }
    }
}
