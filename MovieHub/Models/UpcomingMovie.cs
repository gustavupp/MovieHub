using System;
using System.ComponentModel.DataAnnotations;

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

        public bool IsCanceled { get; set; }

        //navigation property
        public MovieGenres MovieGenre { get; set; }

        //navigation property
        public ApplicationUser AppUser { get; set; }

       
    }
}