using MovieHub.Models;
using MovieHub.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MovieHub.Controllers
{
    public class UpcomingMoviesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public UpcomingMoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var viewModel = new UpcomingMovieViewModel()
            {
                MovieGenres = _context.MovieGenres.ToList()
            };

            return View(viewModel);
        }
    }
}