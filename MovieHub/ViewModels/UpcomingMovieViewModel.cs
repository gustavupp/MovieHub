using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieHub.ViewModels
{
    public class UpcomingMovieViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        [FutureDate]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int RunningTime { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public byte MovieGenreId { get; set; }

        public IEnumerable<MovieGenres> MovieGenres { get; set; }


    }
}