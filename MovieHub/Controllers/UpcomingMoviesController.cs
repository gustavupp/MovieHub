using Microsoft.AspNet.Identity;
using MovieHub.Models;
using MovieHub.ViewModels;
using System;
using System.Data.Entity;
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
                MovieGenres = _context.MovieGenres.ToList(),
                Heading = "Add Upcoming Movie"
            };

            return View(viewModel);
        }


        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var upcomingMovie = _context.UpcomingMovies.Single(um => um.Id == id && um.AppUserId == userId);

            var viewModel = new UpcomingMovieViewModel()
            {
                Id = upcomingMovie.Id,
                MovieGenres = _context.MovieGenres.ToList(),
                MovieName = upcomingMovie.MovieName,
                Director   = upcomingMovie.Director,
                MovieGenreId = upcomingMovie.MovieGenreId,
                ReleaseDate = upcomingMovie.ReleaseDate,   
                RunningTime = upcomingMovie.RunningTime,
                Heading = "Edit Upcoming Movie",
                
            };

            return View("Create",viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UpcomingMovieViewModel upcomingMovie)
        {
            if (!ModelState.IsValid)
            {
                upcomingMovie.MovieGenres = _context.MovieGenres.ToList();
                return View("Create", upcomingMovie);
            }

            var newUpcomingMovie = new UpcomingMovie()
            {
                AppUserId = User.Identity.GetUserId(),
                MovieName = upcomingMovie.MovieName,
                Director = upcomingMovie.Director,
                MovieGenreId = upcomingMovie.MovieGenreId,
                ReleaseDate = upcomingMovie.ReleaseDate,
                RunningTime = upcomingMovie.RunningTime,
            };

            _context.UpcomingMovies.Add(newUpcomingMovie);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpcomingMovieViewModel upcomingMovieViewModel)
        {
            if (!ModelState.IsValid)
            {
                upcomingMovieViewModel.MovieGenres = _context.MovieGenres.ToList();
                return View("Create", upcomingMovieViewModel);
            }

            var userId = User.Identity.GetUserId();

            var updatingMovieGig = _context.UpcomingMovies
                .Include(um => um.Attendances.Select(a => a.Attendee))
                .Single(um => um.Id == upcomingMovieViewModel.Id && um.AppUserId == userId);

            updatingMovieGig.MovieName = upcomingMovieViewModel.MovieName;
            updatingMovieGig.Director = upcomingMovieViewModel.Director;
            updatingMovieGig.ReleaseDate = upcomingMovieViewModel.ReleaseDate;
            updatingMovieGig.RunningTime = upcomingMovieViewModel.RunningTime;
            updatingMovieGig.MovieGenreId = upcomingMovieViewModel.MovieGenreId;

            updatingMovieGig.Update();

            _context.SaveChanges();

            return RedirectToAction("MyUpcomingMovies");
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var upcomingMovies = _context.Attendances
                .Where(a => a.AttendeeId == userId && a.UpcomingMovie.ReleaseDate > DateTime.Now)
                .Select(um => um.UpcomingMovie)
                .Include(um => um.AppUser)
                .Include(um => um.MovieGenre)
                .ToList();

            var moviesIdIamGoing = _context.Attendances
                .Where(e => e.AttendeeId == userId)
                .Select(e => e.UpcomingMovieId)
                .ToList();

            var followers = _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.FolloweeId)
                .ToList();

            var viewModel = new UpcomingMoviesViewModel()
            {
                UpcomingMovies = upcomingMovies,
                ShowActions = User.Identity.IsAuthenticated,
                PageHeading = "Movies I'm Attending",
                MoviesIdIamGoing = moviesIdIamGoing,
                MyFollowers = followers,
            };

            return View("UpcomingMovies", viewModel);
        }

        public ActionResult MyUpcomingMovies()
        {
            var userId = User.Identity.GetUserId();
            var myUpcomingGigs = _context.UpcomingMovies
                .Where(um => um.AppUserId == userId &&
                um.ReleaseDate > DateTime.Now &&
                !um.IsCanceled)
                .Include(g => g.MovieGenre)
                .ToList();

            return View(myUpcomingGigs);
        }



    }
}