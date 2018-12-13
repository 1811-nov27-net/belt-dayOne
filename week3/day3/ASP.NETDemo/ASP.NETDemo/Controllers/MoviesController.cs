using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETDemo.Models;
using ASP.NETDemo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETDemo.Controllers
{
    public class MoviesController : Controller
    {
        //public static MovieRepo repo = new MovieRepo();
        public IMovieRepo repo;

        public MoviesController(IMovieRepo Repo)
        {
            repo = Repo;
        }
        // GET: Movies
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetById(id));
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie newMovie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.CreateMovie(newMovie);
                }
                else
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch(ArgumentException ex)
            {
                ModelState.AddModelError("Id", ex.Message);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = repo.GetById(id);
            if (movie != null)
            {
                return View(movie);
            }
            return View();
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                if(id != movie.Id)
                {
                    ModelState.AddModelError("id", "doesn't match movie id");
                    return View();
                }
                if(ModelState.IsValid)
                {
                    repo.EditMovie(movie);
                }
                else
                {
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = repo.GetById(id);
            if (movie != null)
            {
                return View(movie);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var success = repo.DeleteMovie(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}