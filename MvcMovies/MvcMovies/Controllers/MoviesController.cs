using System.Web.Mvc;
using MvcMovies.Models.ViewModels;
using MvcMovies.Repositories;

namespace MvcMovies.Controllers
{
  public class MoviesController : Controller
  {
    private MovieRepository MovieRepository;

    public MoviesController()
    {
      MovieRepository = new MovieRepository();
    }

    public MoviesController(MovieRepository movieRepository = null)
    {
      MovieRepository = movieRepository ?? new MovieRepository();
    }

    public ActionResult Index()
    {
      var viewModel = new MovieSearchViewModel {Title = "Search Movies"};
      return View(viewModel);
    }

    public ViewResult Search(string title)
    {
      var movies = MovieRepository.SearchMovies(title);
      var viewModel = new MovieSearchResultViewModel {Title = "Search Results", Movies = movies};
      return View(viewModel);
    }
  }
}