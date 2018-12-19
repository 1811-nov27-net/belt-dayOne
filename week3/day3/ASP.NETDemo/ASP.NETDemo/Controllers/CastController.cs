using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETDemo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETDemo.Controllers
{
    public class CastController : Controller
    {
        public IMovieRepo repo { get; set; }
        public CastController (IMovieRepo Repo)
        {
            repo = Repo;
        }
        [Route("MoviesWithActor/{name}", Name = "cast_attr")]
        public IActionResult Index(string name)
        {
            var movies = repo.GetAllByCastMember(name).ToList();
            return View(movies);
        }
    }
}