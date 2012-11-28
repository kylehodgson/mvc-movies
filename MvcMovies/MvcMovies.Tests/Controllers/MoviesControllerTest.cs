using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcMovies.Controllers;
using MvcMovies.Models;
using MvcMovies.Models.ViewModels;

namespace MvcMovies.Tests.Controllers
{
  [TestClass]
  public class MoviesControllerTest
  {
    [TestMethod]
    public void It_Should_Let_The_User_Enter_A_Search_Term()
    {
      //arrange
      var moviesController = new MoviesController();

      //act
      var result = (ViewResult) moviesController.Index();

      //assert
      var searchViewModel = (MovieSearchViewModel) result.Model;
      Assert.AreEqual("Search Movies", searchViewModel.PageTitle);
      Assert.AreEqual("Title", searchViewModel.Heading);
    }

    [TestMethod]
    public void It_Should_Search_Movies_By_Title()
    {
      //arrange
      var movieCatalogue = new Mock<MovieCatalogue>();
      string title = "Robocop";
      var searchRequest = new SearchRequest{ NumRows = 5, SearchTerm = title, StartAt = 0 };

      var movie = new Movie {Title = title};

      movieCatalogue.Setup(it => it.SearchMovies(title)).Returns(new List<Movie> { movie });
      var moviesController = new MoviesController(movieCatalogue.Object);

      //act
      ViewResult result = moviesController.Search(searchRequest);

      var viewModel = (MovieSearchResultViewModel) result.Model;

      //assert
      Assert.AreEqual(1, viewModel.Movies.Count());
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
      
      var searchRequest = new SearchRequest { NumRows = expectedNumberOfRows, SearchTerm = title, StartAt = 0 };

      //act
      ViewResult result = moviesController.Search(searchRequest);
      var viewModel = (MovieSearchResultViewModel)result.Model;

      Assert.AreEqual(expectedNumberOfRows, viewModel.Movies.Count());
    }
  }
}