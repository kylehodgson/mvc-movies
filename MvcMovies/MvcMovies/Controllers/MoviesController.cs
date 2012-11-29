using System;
using System.Collections.Generic;
using System.Linq;
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

    [HttpPost]
    public ViewResult Search(MovieSearchViewModel searchViewModel)
    {
      if (!ModelState.IsValid)
      {
        return View(new MovieSearchResultViewModel{PageTitle = "Please Try Again"});
      }

      var searchTerm = searchViewModel.SearchRequest.SearchTerm;
      var movies = _movieCatalogue.SearchMovies(searchTerm).ToList().Take(searchViewModel.SearchRequest.NumRows);
      var viewModel = new MovieSearchResultViewModel { PageTitle = "Search Results", Movies = movies };
      return View(viewModel);
    }
  }
}