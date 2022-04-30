﻿using Microsoft.AspNet.Identity;
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
                MovieGenres = _context.MovieGenres.ToList()
            };

            return View(viewModel);
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
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var upcomingMovies = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(um => um.UpcomingMovie)
                .Include(um => um.AppUser)
                .Include(um => um.MovieGenre)
                .ToList();

            var viewModel = new HomeViewModel()
            {
                UpcomingMovies = upcomingMovies,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }

    }
}