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

        public ActionResult Details(int Id)
        {

            Movie movie = new Movie();

            movie = _context.Movies.Include(G => G.Genre).SingleOrDefault(m => m.Id == Id);


            return View(movie);
        }
    }
}