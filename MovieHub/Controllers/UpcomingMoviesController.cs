using Microsoft.AspNet.Identity;
using MovieHub.Models;
using MovieHub.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MovieHub.Controllers
{
    public class UpcomingMoviesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public UpcomingMoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new UpcomingMovieViewModel()
            {
                MovieGenres = _context.MovieGenres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(UpcomingMovieViewModel upcomingMovie)
        {
            var currentUserId = User.Identity.GetUserId();
            var user = _context.Users.Single(u => u.Id == currentUserId);
            var genre = _context.MovieGenres.FirstOrDefault(g => g.Id == upcomingMovie.MovieGenre);

            var newUpcomingMovie = new UpcomingMovie()
            {
                AppUser = user,
                MovieName = upcomingMovie.MovieName,
                Director = upcomingMovie.Director,
                MovieGenre = genre,
                ReleaseDate = DateTime.Parse(upcomingMovie.ReleaseDate),
                RunningTime = upcomingMovie.RunningTime,
            };

            _context.UpcomingMovies.Add(newUpcomingMovie);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}