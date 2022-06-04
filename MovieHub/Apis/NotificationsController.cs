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
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDto> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId)
                .Select(n => n.Notification)
                .Include(n => n.UpcomingMovie.AppUser)
                .ToList();

            return notifications.Select(n => new NotificationDto()
            {
                DateTime = n.DateTime,
                Id = n.Id,
                ModificationDate = n.ModificationDate,
                NotificationType = n.NotificationType,
                UpcomingMovie = new UpcomingMovieDto
                {
                    MovieName = n.UpcomingMovie.MovieName,
                    Director = n.UpcomingMovie.Director,
                    Id = n.UpcomingMovie.Id,
                    IsCanceled = n.UpcomingMovie.IsCanceled,
                    ReleaseDate = n.UpcomingMovie.ReleaseDate,
                    RunningTime = n.UpcomingMovie.RunningTime,
                    MovieGenre = new MovieGenresDto
                    {
                        Id = n.UpcomingMovie.MovieGenreId,
                    },
                    AppUser = new UserDto
                    {
                        Id = n.UpcomingMovie.AppUser.Id,
                        Name = n.UpcomingMovie.AppUser.Name
                    }
                }
            });
        }
    }
}
