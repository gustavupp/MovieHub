using Microsoft.AspNet.Identity;
using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieHub.Controllers
{
    public class FollowingController : Controller
    {

        private ApplicationDbContext _context { get; set; }

        public FollowingController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        [HttpGet]
        public ActionResult MyFollowers()
        {
            var userId = User.Identity.GetUserId();
            var myFollowers = _context.Followings.Where(f => f.FollowerId == userId).Select(f => f.Followee).ToList();

            return View(myFollowers);
        }
    }
}