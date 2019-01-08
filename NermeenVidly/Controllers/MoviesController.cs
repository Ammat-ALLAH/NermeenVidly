using NermeenVidly.Models;
using NermeenVidly.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace NermeenVidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Movies
        public ActionResult Index()
        {
            MoviesViewModel _movieModel = new MoviesViewModel();
            _movieModel.MoviesList = _context.Movies.Include(G => G.Genre).ToList();
            return View(_movieModel);
        }

       
        public ActionResult Edit(int Id)
        {
            MovieFormViewModel _movieForm = new MovieFormViewModel();
            //View Existing Movie object
            if (Id != 0)
            {
                //UpdateExisting 
                Movie movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(C => C.Id == Id);
                _movieForm.Movie = movie;
            }
            _movieForm.Genres = _context.Genres.ToList();
            return View("New", _movieForm);
        }

        public ActionResult New()
        {
            MovieFormViewModel _movieForm = new MovieFormViewModel();
            
            _movieForm.Genres = _context.Genres.ToList();
            return View(_movieForm);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id != 0)
            {
                Movie movieToEdit = _context.Movies.SingleOrDefault(C => C.Id == movie.Id);
                movieToEdit.Name = movie.Name;
                movieToEdit.GenreId = movie.GenreId;
                //movieToEdit.ReleaseDate = movie.ReleaseDate;
                movieToEdit.NumberInStock = movie.NumberInStock;

            }
            else
            {
                _context.Movies.Add(movie);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Details(int Id)
        {

            Movie movie = new Movie();

            movie = _context.Movies.Include(G => G.Genre).SingleOrDefault(m => m.Id == Id);


            return View(movie);
        }
    }

}