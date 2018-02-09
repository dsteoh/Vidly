using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult MovieForm()
        {
            //We have 2 constructor in MovieFormViewModel () will initialize id == 0 and DateAdded to the current date
            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            //Check if the form is in New state or edit state
            if(movie.Id == 0)
                _context.Movies.Add(movie);
            //If Form is in edit state we update the database with new data in the form
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            //Return us to the list of movies
            var movieList = _context.Movies.Include(c => c.Genre).ToList();
            return View("List", movieList);
        }
        // GET: Movie
        public ActionResult Index()
        {
            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
        
    }
}