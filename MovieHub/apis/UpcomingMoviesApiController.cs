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
            var toBeCanceled = _context.UpcomingMovies
                .Single(um => um.Id == id && um.AppUserId == userId);

            toBeCanceled.IsCanceled = true;

            _context.SaveChanges();

            return Ok();

        }
    }
}