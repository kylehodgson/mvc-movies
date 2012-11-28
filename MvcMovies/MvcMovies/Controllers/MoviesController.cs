using System.Web.Mvc;
using MvcMovies.Models;
using MvcMovies.Models.ViewModels;

namespace MvcMovies.Controllers
{
  public class MoviesController : Controller
  {
    private MovieCatalogue _movieCatalogue;

    public MoviesController()
    {
      _movieCatalogue = new MovieCatalogue();
    }

    public MoviesController(MovieCatalogue movie = null)
    {
      _movieCatalogue = movie ?? new MovieCatalogue();
    }

    public ActionResult Index()
    {
      var viewModel = new MovieSearchViewModel {PageTitle = "Search Movies", Heading = "Title"};
      return View(viewModel);
    }

    public ViewResult Search(string title)
    {
      var movies = _movieCatalogue.SearchMovies(title);
      var viewModel = new MovieSearchResultViewModel {Title = "Search Results", Movies = movies};
      return View(viewModel);
    }
  }
}