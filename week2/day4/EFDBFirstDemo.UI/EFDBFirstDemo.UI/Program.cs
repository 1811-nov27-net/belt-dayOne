using EFDBFirstDemo.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFDBFirstDemo.UI
{
    class Program
    {
        static DbContextOptions<adventureworksContext> options = null;
        static void Main(string[] args)
        {
            var connectionString = SecretConfiguration.connectionString;

            var optionsBuilder = new DbContextOptionsBuilder<adventureworksContext>();
            optionsBuilder.UseSqlServer(connectionString);
            options = optionsBuilder.Options;

            //PrintMovies();
            //AddAMovie();
            //PrintMovies();
            //EditSomething();
            //PrintMovies();
            AccessWithRepo();
        }

        static void PrintMovies()
        {
            var movies = new List<Movie>();
            using (var db = new adventureworksContext(options))
            {
                movies = db.Movie.ToList();

                movies = db.Movie.Include(m => m.Genre).ToList();
            }

            foreach (var item in movies)
            {
                Console.WriteLine($"movie ID {item.Id}, name {item.Name}, genre {item.Genre.Name}");
            }
        }

        static void AddAMovie()
        {
            using (var db = new adventureworksContext(options))
            {
                var firstMovieQuery = db.Movie.Include(m => m.Genre).OrderBy(m => m.Name);

                Movie movie = firstMovieQuery.First();

                Movie newMovie = new Movie { Name = movie.Name + " 2", Genre = movie.Genre };

                db.Add(newMovie);
                //db.Movie.Add(newMovie);
                //movie.Genre.Movie.Add(newMovie)

                db.SaveChanges();
            }
        }

        static void EditSomething()
        {
            using (var db = new adventureworksContext(options))
            {
                var actionGenre = db.Genre.First(g => g.Name == "Action");
                if (actionGenre != null)
                {
                    actionGenre.Name = "Action/Adventure";

                    db.SaveChanges();
                }
            }
        }

        static void AccessWithRepo()
        {
            using (var db = new adventureworksContext(options))
            {
                IMovieRepository movieRepo = new MovieRepository(db);

                movieRepo.CreateMovie(new Movie { Name = "Harry Potter" }, "Action/Adventure");

                movieRepo.SaveChanges();

                foreach(var movie in movieRepo.GetAllMoviesWithGenre())
                {
                    Console.WriteLine(movie.Name);
                }
            }
        }
    }
}