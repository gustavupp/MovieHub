using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace MovieHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingMoviesList = _context.UpcomingMovies.Include(m => m.AppUser).Where(m => m.ReleaseDate > DateTime.Now).ToList();
            return View(upcomingMoviesList);
        }

    }
}