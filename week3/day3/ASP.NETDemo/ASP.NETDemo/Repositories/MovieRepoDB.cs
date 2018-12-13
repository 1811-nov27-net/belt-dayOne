using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETDemo.Models;
using Microsoft.EntityFrameworkCore;
using Data = MVCDemo.DataAccess;

namespace ASP.NETDemo.Repositories
{
    public class MovieRepoDB : IMovieRepo
    {
        private readonly Data.MovieDBContext _db;

        public MovieRepoDB(Data.MovieDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            db.Database.EnsureCreated();
        }
        public void CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public void EditMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _db.Movie.Include(m => m.CastMembers).Select(m => new Movie
            {
                Id = m.Id,
                Title = m.Title,
                Cast = m.CastMembers.Select(c => c.Name).ToList()
            });
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
