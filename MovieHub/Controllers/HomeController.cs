using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MovieHub.ViewModels;

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
            var upcomingMoviesList = _context.UpcomingMovies
                .Include(m => m.AppUser)
                .Where(m => m.ReleaseDate > DateTime.Now)
                .Include(m => m.MovieGenre)
                .Include(m => m.AppUser)
                .ToList();

            var homeViewModel = new HomeViewModel()
            {
                UpcomingMovies = upcomingMoviesList,
                ShowActions = User.Identity.IsAuthenticated,
                PageHeading = "All Upcoming Movies",
            };

            return View("UpcomingMovies" ,homeViewModel);
        }

    }
}