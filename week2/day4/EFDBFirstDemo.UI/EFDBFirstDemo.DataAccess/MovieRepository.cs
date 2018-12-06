using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFDBFirstDemo.DataAccess
{
    public class MovieRepository : IMovieRepository
    {
        adventureworksContext Db { get; }

        public MovieRepository(adventureworksContext db)
        {
            Db = db ?? throw new ArgumentNullException();
        }
        public void CreateMovie(Movie movie, string withGenre)
        {
            Genre trackedGenre = Db.Genre.First(g => g.Name == withGenre);
            movie.Genre = trackedGenre;
            Db.Add(movie);
        }

        public void DeleteMovie(Movie movie)
        {
            Movie trackedMovie = Db.Movie.Find(movie.Id);

            if (trackedMovie != null)
                Db.Movie.Remove(trackedMovie);
        }

        public void EditMovie(Movie movie)
        {
            Movie trackedMovie = Db.Movie.Find(movie.Id);
            Db.Entry(trackedMovie).CurrentValues.SetValues(movie);
        }

        public IList<Movie> GetAllMovies()
        {
            return Db.Movie.AsNoTracking().ToList();
        }

        public IList<Movie> GetAllMoviesWithGenre()
        {
            return Db.Movie.Include(m => m.Genre).AsNoTracking().ToList();
        }

        public Movie GetMovieById(int id)
        {
            return Db.Movie.Find(id);
        }

        public Movie GetMovieByName(string name)
        {
            return Db.Movie.First(m => m.Name == name);
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }
    }
}
