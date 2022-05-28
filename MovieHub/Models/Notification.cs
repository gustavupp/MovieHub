using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; set; }
        public NotificationType NotificationType { get; private set; }
        public DateTime? ModificationDate { get; private set; }

        [Required]
        public UpcomingMovie UpcomingMovie { get; private set; }

        protected Notification()
        {
        }

        private Notification(UpcomingMovie upcomingMovie, NotificationType notificationType)
        {
            if(upcomingMovie == null)
                throw new ArgumentNullException(nameof(upcomingMovie));

            UpcomingMovie = upcomingMovie;
            NotificationType = notificationType;
            DateTime = DateTime.Now;
        }

        public static Notification UpcomingMovieCreated(UpcomingMovie upcomingMovie)
        {
            return new Notification(upcomingMovie, NotificationType.UpcomingMovieCreated);
        }

        public static Notification UpcomingMovieUpdated(UpcomingMovie upcomingMovie, DateTime newDateTime, DateTime modificationDate)
        {
            var notification = new Notification(upcomingMovie, NotificationType.UpcomingMovieUpdated);
            notification.ModificationDate = modificationDate;
            notification.DateTime = newDateTime;

            return notification;
        }

        public static Notification UpcomingMovieCanceled(UpcomingMovie upcomingMovie)
        {
            return new Notification(upcomingMovie, NotificationType.UpcomingMovieCanceled);
        }
    }
}