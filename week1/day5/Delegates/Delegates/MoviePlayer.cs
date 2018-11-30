using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Delegates
{
    public class MoviePlayer
    {
        public string CurrentMovie { get; set; }

        public delegate void MovieFinishedHandler();

        public delegate void MovieFinishedStringHandler(string title);

        public event MovieFinishedStringHandler MovieFinished;

        public event Action<string> MovieFinished2;

        public void PlayMovie()
        {
            Thread.Sleep(3000);

            Console.WriteLine($"Finished movie {CurrentMovie}");

            //MovieFinished?.Invoke();
            if (MovieFinished != null)
            {
                MovieFinished(CurrentMovie);
            }

        }
    }
}
