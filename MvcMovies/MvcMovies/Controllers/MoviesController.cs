using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcMovies.Models;
using MvcMovies.Models.ViewModels;
using MvcMovies.Repositories;

namespace MvcMovies.Controllers
{
  public class MoviesController : Controller
  {
    private MovieCatalogue _movieCatalogue;
    private MovieRepository _movieRepository;

    public MoviesController()
    {
      _movieCatalogue = new MovieCatalogue();
      _movieRepository = new MovieRepository();
    }

    public MoviesController(MovieCatalogue catalog = null, MovieRepository repository = null)
    {
      _movieCatalogue = catalog ?? new MovieCatalogue();
      _movieRepository = repository ?? new MovieRepository();
    }

    public ViewResult Index()
    {
      return View();
    }
    
    public ActionResult SearchForm()
    {
      return View("SearchForm", "_PartialWithValidation");
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


    public ViewResult Details(int id)
    {
      var movie =  _movieRepository.GetMovie(id);
      return View(movie);
    }
  }
}