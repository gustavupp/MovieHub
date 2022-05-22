using Microsoft.AspNet.Identity;
using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieHub.apis
{

    public class UpcomingMoviesApiController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public UpcomingMoviesApiController()
        {
            this._context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult CancelUpcomingMovie(int id)
        {
            var userId = User.Identity.GetUserId();
            var upcomingMovie = _context.UpcomingMovies
                .Single(um => um.Id == id && um.AppUserId == userId);

            upcomingMovie.IsCanceled = true;

            var notification = new Notification()
            {
                DateTime = DateTime.Now,
                NotificationType = NotificationType.UpcomingMovieCanceled,
                UpcomingMovie = upcomingMovie,
            };

            var usersAttendingMovie = _context.Attendances
                .Where(a => a.UpcomingMovieId == upcomingMovie.Id)
                .Select(a => a.Attendee)
                .ToList();

            foreach(var user in usersAttendingMovie)
            {
                user.Notify(notification);
            }

            _context.SaveChanges();

            return Ok();

        }
    }
}