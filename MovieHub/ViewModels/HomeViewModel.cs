using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieHub.ViewModels
{
    public class HomeViewModel
    {
       public IEnumerable<Models.UpcomingMovie> UpcomingMovies { get; set; }
       public bool ShowActions { get; set; }

    }
}