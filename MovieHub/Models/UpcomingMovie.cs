using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MovieHub.Models
{
    public class UpcomingMovie
    {
        public int Id { get; set; }

        //foreignKey property
        [Required]
        public byte MovieGenreId { get; set; }

        //foreignKey property
        [Required]
        public string AppUserId { get; set; }

        [Required]
        public string MovieName { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int RunningTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Director { get; set; }

        public bool IsCanceled { get; private set; }

        //navigation properties
        public MovieGenres MovieGenre { get; set; }

        public ApplicationUser AppUser { get; set; }
        public ICollection<Attendance> Attendances { get; private set; }

        public void Cancel()
        {
            IsCanceled = true;

            var notification = new Notification(this, NotificationType.UpcomingMovieCanceled);

            foreach (var user in Attendances.Select(a => a.Attendee))
            {
                user.Notify(notification);
            }
        }

        public void Update()
        {
            var notification = new Notification(this,NotificationType.UpcomingMovieUpdated);

            foreach(var user in Attendances.Select(a => a.Attendee))
            {
                user.Notify(notification);
            }
        }

        public UpcomingMovie()
        {
            Attendances = new Collection<Attendance>();
        }


    }
}