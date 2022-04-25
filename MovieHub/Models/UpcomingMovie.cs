using System;
using System.ComponentModel.DataAnnotations;

namespace MovieHub.Models
{
    public class UpcomingMovie
    {
        public int Id { get; set; }

        public ApplicationUser AppUser { get; set; }

        [Required]
        public string AppUserId { get; set; }

        [Required]
        public string MovieName { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int RunningTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Director { get; set; }

        public MovieGenres MovieGenre { get; set; }

        [Required]
        public byte MovieGenreId { get; set; }
    }
}