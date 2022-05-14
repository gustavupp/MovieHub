using Microsoft.AspNet.Identity;
using MovieHub.Dtos;
using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieHub.Controllers
{
    [Authorize]
    public class FollowingApiController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingApiController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followeeDto)
        {
            var userId = User.Identity.GetUserId();

            if (followeeDto.FolloweeId == userId)
                return BadRequest("You cannot follow yourself");

            if (_context.Followings.Any(f => 
            f.FollowerId == userId &&
            f.FolloweeId == followeeDto.FolloweeId))
            {
                var unfollow = _context.Followings
                    .FirstOrDefault(f => 
                    f.FollowerId == userId &&
                    f.FolloweeId == followeeDto.FolloweeId);
                
                _context.Followings.Remove(unfollow);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                var following = new Following()
                {
                    FollowerId = userId,
                    FolloweeId = followeeDto.FolloweeId
                };

                _context.Followings.Add(following);
                _context.SaveChanges();

                return Ok();
            }
        }
    }
}
