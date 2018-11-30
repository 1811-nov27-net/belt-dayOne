using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            LINQ();
            var player = new MoviePlayer
            {
                CurrentMovie = "Lord of the Rings: Fellowship of the Ring Extended Edition"
            };

            MoviePlayer.MovieFinishedHandler handler = EjectDisc;

            player.MovieFinished += EjectDisc;
            // player.MovieFinished -= EjectDisc;

            Action<string> handler2 = EjectDisc;

            player.MovieFinished2 += handler2;

            player.MovieFinished += s => Console.WriteLine("Lambda Subscribe");

            player.PlayMovie();

            Func<int, string, bool> func = (n, s) => true;

            Func<bool> func2 = () => false;

            Action<int, string, bool> func3 = (num, str, b) =>
            {
                if (b)
                {
                    Console.WriteLine(num);
                    Console.WriteLine(str);
                }
            };

            Action<bool> func4 = b => { return;};
        }

        static void EjectDisc()
        {
            Console.WriteLine("Ejecting Disc");
        }

        static void EjectDisc(string title)
        {
            Console.WriteLine("Ejecting Disc");
        }

        static void LINQ()
        {
            var x = new List<string>();

            x.Max(s => s.Length);

            var firstCharacters = x.Select(s => s[0]);

            bool allShorterThan5Chars = x.All(s => s.Length < 5);

            var onlyTheLongElements = x.Where(s => s.Length > 20);

            bool b = x.Where(s => s.Length > 20).Select(s => s[0]).All(c => c == 'a' || c == 'b');

            List<char> listOfChars = firstCharacters.ToList();
        }
        
        static void Finally()
        {
            try
            {
                Console.WriteLine("try");
            }
            catch (ArgumentException e)
            {
                // runs in case of exception
                // case specific clean up here
            }
            finally
            {
                // runs no matter what: caught exception, uncaught exception, no exception
                // general cleanup here
            }
        }
    }
}
