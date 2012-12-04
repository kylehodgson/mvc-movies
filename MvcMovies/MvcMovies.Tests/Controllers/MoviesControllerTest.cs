using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcMovies.Controllers;
using MvcMovies.Models;
using MvcMovies.Models.ViewModels;
using MvcMovies.Repositories;

namespace MvcMovies.Tests.Controllers
{
  [TestClass]
  public class MoviesControllerTest
  {
    [TestMethod]
    public void It_Should_Search_Movies_By_Title()
    {
      //arrange
      var movieCatalogue = new Mock<MovieCatalogue>();
      string title = "Robocop";
      var searchRequest = new SearchRequestViewModel {NumRows = 5, SearchTerm = title, StartAt = 0};
      
      var movie = new Movie {Title = title};

      movieCatalogue.Setup(it => it.SearchMovies(title)).Returns(new List<Movie> {movie});
      var moviesController = new MoviesController(movieCatalogue.Object);

      //act
      ViewResult result = moviesController.SearchPage(searchRequest);

      var viewModel = (SearchResultViewModel) result.Model;

      //assert
      Assert.AreEqual(1, viewModel.Movies.Count());
      Assert.AreEqual(title, viewModel.Movies.ToList()[0].Title);
      Assert.AreEqual("Search Results", viewModel.PageTitle);
    }

    [TestMethod]
    public void Searching_Movies_Should_Return_Specified_Number_Of_Movies()
    {
      //arrange
      int expectedNumberOfRows = 3;
      var movieCatalogue = new Mock<MovieCatalogue>();
      string title = "Robocop";

      List<Movie> movies =
        Enumerable.Range(1, 7).Select(i => new Movie {Title = String.Format("Movie {0}", i)}).ToList();

      movieCatalogue.Setup(it => it.SearchMovies(title)).Returns(movies);
      var moviesController = new MoviesController(movieCatalogue.Object);

      var searchRequest = new SearchRequestViewModel {NumRows = expectedNumberOfRows, SearchTerm = title, StartAt = 0};

      //act
      ViewResult result = moviesController.SearchPage(searchRequest);
      var viewModel = (SearchResultViewModel) result.Model;

      Assert.AreEqual(expectedNumberOfRows, viewModel.Movies.Count());
    }

    [TestMethod]
    public void Search_Term_Must_Follow_Validation_Rules()
    {
      // Arrange
      var controller = new MoviesController();
      controller.ModelState.AddModelError("SearchTerm","mock error message");
      var searchRequest = new SearchRequestViewModel{SearchTerm = ""};

      // Act
      var result = (SearchResultViewModel)controller.SearchPage(searchRequest).Model;

      // Assert
      Assert.AreEqual("Please Try Again", result.PageTitle);
      Assert.IsNotNull(result.Movies);
    }

    [TestMethod]
    public void It_Should_Provide_Details_Page()
    {
      
      var movieRepo = new Mock<MovieRepository>();
      var movie = new Movie {Id = 1, Title = "Title"};
      movieRepo.Setup(it => it.GetMovie(movie.Id)).Returns(movie);

      var controller = new MoviesController(repository: movieRepo.Object);

      var model = controller.Details(movie.Id).Model;
      var resultModel = (Movie)model;

      Assert.IsNotNull(movie);
      Assert.IsNotNull(resultModel);
      Assert.AreEqual(movie.Id, resultModel.Id);
    }
  }
}