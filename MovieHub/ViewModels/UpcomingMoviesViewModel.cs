using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieHub.ViewModels
{
    public class UpcomingMoviesViewModel
    {
       public IEnumerable<Models.UpcomingMovie> UpcomingMovies { get; set; }
       public bool ShowActions { get; set; }
       public string PageHeading { get; set; }
       public List<int> MoviesIdIamGoing { get; set; }
       public List<string> MyFollowers { get; set; }

    }
}