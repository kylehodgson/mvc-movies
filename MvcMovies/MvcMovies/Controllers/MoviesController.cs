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

    public ViewResult Index()
    {
      return View();
    }

    public ActionResult SearchForm()
    {
      return PartialView();
    }

    [HttpPost]
    public ViewResult SearchPage(SearchRequestViewModel searchRequestViewModel)
    {
      if (!ModelState.IsValid)
      {
        return View(new SearchResultViewModel{PageTitle = "Please Try Again"});
      }

      var searchTerm = searchRequestViewModel.SearchTerm;
      var movies = _movieCatalogue.SearchMovies(searchTerm).ToList().Take(searchRequestViewModel.NumRows);
      var viewModel = new SearchResultViewModel { PageTitle = "Search Results", Movies = movies };
      return View(viewModel);
    }
  }
}