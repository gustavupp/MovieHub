using Microsoft.AspNet.Identity;
using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using MovieHub.Dtos;

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

            //FIX THIS
            return notifications.Select(n => new NotificationDto()
            {
                DateTime = n.DateTime,
                Id = n.Id,
                ModificationDate = n.ModificationDate,
                NotificationType = n.NotificationType,
                UpcomingMovie = new UpcomingMovieDto 
                {
                    MovieName = n.UpcomingMovie.MovieName,
                    MovieGenre = new MovieGenresDto
                    {
                        Id = n.UpcomingMovie.MovieGenre.Id,
                        Name = n.UpcomingMovie.MovieGenre.Name,
                    },
                    Director = n.UpcomingMovie.Director,
                    Id = n.UpcomingMovie.Id,
                    IsCanceled = n.UpcomingMovie.IsCanceled,
                    ReleaseDate = n.UpcomingMovie.ReleaseDate,
                    RunningTime = n.UpcomingMovie.RunningTime,
                    AppUser = new UserDto
                    {
                        Id = n.UpcomingMovie.AppUser.Id,
                        Name = n.UpcomingMovie.AppUser.Name
                    }
                },

            });
        }
    }
}