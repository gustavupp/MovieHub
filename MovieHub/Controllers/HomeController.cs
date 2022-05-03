using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MovieHub.ViewModels;
using Microsoft.AspNet.Identity;

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

            var userId = User.Identity.GetUserId();
            var moviesIdIamGoing = _context.Attendances
                .Where(e => e.AttendeeId == userId)
                .Select(e => e.UpcomingMovieId)
                .ToList();

            var followers = _context.Followings.Where(f => f.FollowerId == userId).Select(f => f.FolloweeId).ToList();

            var homeViewModel = new UpcomingMoviesViewModel()
            {
                UpcomingMovies = upcomingMoviesList,
                ShowActions = User.Identity.IsAuthenticated,
                PageHeading = "All Upcoming Movies",
                MoviesIdIamGoing = moviesIdIamGoing,
                MyFollowers = followers,
            };

            return View("UpcomingMovies", homeViewModel);
        }

    }
}