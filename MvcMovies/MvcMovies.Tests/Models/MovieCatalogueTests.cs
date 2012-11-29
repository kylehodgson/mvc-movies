using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcMovies.Models;
using MvcMovies.Repositories;

namespace MvcMovies.Tests.Models
{
  [TestClass]
  public class MovieCatalogueTests
  {
    [TestMethod]
    public void ItShouldSearchForMoviesByTitle()
    {
      var searchTerm = "Robocop";
      int expectedCount = 1;
      var movieRepo = new Mock<MovieRepository>();
      var movie = new Movie {Title = searchTerm};
      movieRepo.Setup(it => it.SearchMovies(searchTerm)).Returns(new List<Movie> {movie});

      var movieCatalogue = new MovieCatalogue(movieRepo.Object);
      var result = movieCatalogue.SearchMovies(searchTerm).ToList();

      Assert.AreEqual(expectedCount, result.Count());
      Assert.AreEqual(searchTerm, result[0].Title);
    }
  }
}