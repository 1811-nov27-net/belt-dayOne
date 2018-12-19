using ASP.NETDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETDemo.Repositories
{
    public interface IMovieRepo
    {
        void CreateMovie(Movie movie);
        bool DeleteMovie(int id);
        void EditMovie(Movie movie);
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        IEnumerable<Movie> GetAllByCastMember(string cast);
    }
}
