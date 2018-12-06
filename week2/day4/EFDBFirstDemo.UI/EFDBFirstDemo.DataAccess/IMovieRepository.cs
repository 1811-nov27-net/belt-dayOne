using System;
using System.Collections.Generic;
using System.Text;

namespace EFDBFirstDemo.DataAccess
{
    public interface IMovieRepository
    {
        IList<Movie> GetAllMovies();
        IList<Movie> GetAllMoviesWithGenre();
        Movie GetMovieById(int id);
        Movie GetMovieByName(string name);
        void CreateMovie(Movie movie, string withGenre);
        void DeleteMovie(Movie movie);
        void EditMovie(Movie movie);
        void SaveChanges();
    }
}
