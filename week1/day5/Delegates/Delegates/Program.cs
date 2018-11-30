using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
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
    }
}
