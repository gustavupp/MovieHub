using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieHub.Dtos
{
    public class UpcomingMovieDto
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunningTime { get; set; }
        public string Director { get; set; }
        public bool IsCanceled { get; set; }
        public MovieGenresDto MovieGenre { get; set; }
        public UserDto AppUser { get; set; }
    }
}