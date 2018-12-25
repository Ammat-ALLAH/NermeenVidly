using NermeenVidly.Models;
using NermeenVidly.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NermeenVidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            Movie _movieModel = new Movie() { Name = "Shrek!" };

            RandomMovieViewModel randomMovie = new RandomMovieViewModel()
            {
                movie = _movieModel,
                customers = new List<Customer>()
                {
                    new Customer(){Name = "Customer 1"},
                    new Customer(){Name = "Customer 2"}
        }
            };
            
            
            return View(randomMovie);
        }

        public ActionResult GetMovies()
        {
            MoviesViewModel moviesVM = new MoviesViewModel();

            List<Movie> _moviesList = new List<Movie>()
            {
                new Movie() {Name = "Shrek!"},
                new Movie() {Name = "Home Alone"},
            };
            moviesVM.MoviesList = _moviesList;


            return View(moviesVM);
        }
    }
}