using System;
using System.ComponentModel.DataAnnotations;

namespace MovieHub.Models
{
    public class UpcomingMovie
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Movie { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int RunningTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Director { get; set; }

        [Required]
        public MovieGenres MovieGenre { get; set; }
    }
}