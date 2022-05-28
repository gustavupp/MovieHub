using Microsoft.AspNet.Identity;
using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;

namespace MovieHub.Apis
{
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Notification> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId)
                .Select(n => n.Notification)
                .Include(n => n.UpcomingMovie.AppUser)
                .ToList();

            return notifications;
        }
    }
}