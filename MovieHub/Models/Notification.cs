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

        public DateTime DateTime { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }

        [Required]
        public UpcomingMovie UpcomingMovie { get; set; }

        public Notification()
        {
        }

        public Notification(UpcomingMovie upcomingMovie, NotificationType notificationType)
        {
            if(upcomingMovie == null)
                throw new ArgumentNullException(nameof(upcomingMovie));

            this.UpcomingMovie = upcomingMovie;
            this.NotificationType = notificationType;
            this.DateTime = DateTime.Now;
        }
    }
}