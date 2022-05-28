using Microsoft.AspNet.Identity;
using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

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
                .Include(um => um.Attendances.Select(a => a.Attendee))
                .Single(um => um.Id == id && um.AppUserId == userId);

            if(upcomingMovie.IsCanceled)
                return NotFound();

            upcomingMovie.Cancel();

            _context.SaveChanges();

            return Ok();

        }
    }
}