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
    public void It_Should_Let_The_User_Enter_A_Search_Term()
    {
      //arrange
      var moviesController = new MoviesController();

      //act
      var result = (ViewResult) moviesController.Index();

      //assert
      var searchViewModel = (MovieSearchViewModel) result.Model;
      Assert.AreEqual("Search Movies", searchViewModel.Title);
    }

    [TestMethod]
    public void It_Should_Search_Movies_By_Title()
    {
      //arrange
      var movieRepo = new Mock<MovieRepository>();
      var title = "Robocop";
      var movie = new Movie {Title = title};
      movieRepo.Setup(repository => repository.SearchMovies(title)).Returns(new List<Movie> { movie });
      var moviesController = new MoviesController(movieRepo.Object);

      //act
      var result = (ViewResult)moviesController.Search(title);

      var viewModel = (MovieSearchResultViewModel) result.Model;

      //assert
      Assert.AreEqual(1, viewModel.Movies.Count());
    }
  }
}