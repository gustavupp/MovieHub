using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieHub.Dtos
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public NotificationType NotificationType { get; set; }
        public DateTime? ModificationDate { get; set; }
        public UpcomingMovieDto UpcomingMovie { get; set; }
    }
}