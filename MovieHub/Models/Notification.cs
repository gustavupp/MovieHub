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
        public DateTime? ModificationDate { get; set; }

        [Required]
        public UpcomingMovie UpcomingMovie { get; private set; }

        protected Notification()
        {
        }

        public Notification(UpcomingMovie upcomingMovie, NotificationType notificationType)
        {
            if(upcomingMovie == null)
                throw new ArgumentNullException(nameof(upcomingMovie));

            UpcomingMovie = upcomingMovie;
            NotificationType = notificationType;
            DateTime = DateTime.Now;
        }
    }
}