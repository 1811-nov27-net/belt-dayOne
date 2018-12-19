using ASP.NETDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETDemo.Repositories
{
    public class MovieRepo : IMovieRepo
    {
        private List<Movie> _movies = new List<Movie>()
        {new Movie(){Id = 1, Title = "Star Wars", ReleaseDate = new DateTime(1977, 3, 17) },
        new Movie(){Id = 2, Title = "Lord of the Rings", ReleaseDate = new DateTime(2003, 3, 17), Cast = new List<string>{"Orlando Bloom", "Elijah Wood"} }};

        public IEnumerable<Movie> GetAll()
        {
            return _movies;
        }

        public Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public bool DeleteMovie(int id)
        {
            var movie = GetById(id);
            return _movies.Remove(movie);
        }

        public void CreateMovie(Movie movie)
        {
            if (_movies.Any(m=>m.Id == movie.Id))
            {
                throw new ArgumentException($"Duplicate ID {movie.Id}");
            }
            _movies.Add(movie);
        }

        public void EditMovie(Movie movie)
        {
            DeleteMovie(movie.Id);
            CreateMovie(movie);
        }

        public IEnumerable<Movie> GetAllByCastMember(string cast)
        {
            throw new NotImplementedException();
        }
    }
}
