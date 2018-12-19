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
            var Movie = new Movie { Title = movie.Title, ReleaseDate = movie.ReleaseDate };
            _db.Add(Movie);
            _db.SaveChanges();
        }

        public bool DeleteMovie(int id)
        {
            Data.Movie movie = _db.Movie.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _db.Remove(movie);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public void EditMovie(Movie movie)
        {
            DeleteMovie(movie.Id);
            CreateMovie(movie);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _db.Movie.Include(m => m.CastMemberJunctions).ThenInclude(j => j.CastMember).Select(Map);
        }

        public Movie GetById(int id)
        {
            Movie movie = Map(_db.Movie.FirstOrDefault(m => m.Id == id));
            if(movie != null)
            {
                return movie;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Movie> GetAllByCastMember(string cast)
        {
            return _db.CastMember
                .Include(c => c.MovieJunctions)
                    .ThenInclude(j => j.Movie)  // fills in navigation property OF a navigation property
                        .ThenInclude(m => m.CastMemberJunctions)
                            .ThenInclude(j => j.CastMember)
                .Where(c => c.Name == cast)
                .ToList() // faced issue inside next call with null properties if ToList was not called here
                .SelectMany(c => c.MovieJunctions.Select(j => Map(j.Movie)));
        }
        public static Movie Map(Data.Movie data)
        {
            return new Movie
            {
                Id = data.Id,
                Title = data.Title,
                ReleaseDate = data.ReleaseDate,
                Cast = data.CastMemberJunctions.Select(j => j.CastMember.Name).ToList()
            };
        }
    }
}
