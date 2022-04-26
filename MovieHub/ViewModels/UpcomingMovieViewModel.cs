using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieHub.ViewModels
{
    public class UpcomingMovieViewModel
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string ReleaseDate { get; set; }
        public int RunningTime { get; set; }
        public string Director { get; set; }
        public byte MovieGenreId { get; set; }
        public IEnumerable<MovieGenres> MovieGenres { get; set; }
    }
}