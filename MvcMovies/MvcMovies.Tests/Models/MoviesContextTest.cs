using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcMovies.Models;

namespace MvcMovies.Tests.Models
{
  [TestClass]
  public class MoviesContextTest
  {
    [TestMethod]
    public void It_Should_Count_Movies()
    {
      var movieContext = new MoviesContextMock(new List<Movie> { new Movie(), new Movie() });
      const int expectedCount = 2;

      var actualCount = movieContext.GetNumberOfMovies();

      Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void It_Should_Search_Movies_By_Title()
    {
      var movieTitle = "Title";
      var expectedMovie = new Movie {Title = movieTitle};
      var movieContext = new MoviesContextMock(new List<Movie> {expectedMovie});


      var result = movieContext.SearchMovie(movieTitle);

      Assert.AreEqual(expectedMovie, result.ToList()[0]);
    }

    [TestMethod]
    public void It_Should_Add_Movies()
    {
      var movieToAdd = new Movie {Title = "robocop"};
      var movieContextMock = new MoviesContextMock(new List<Movie>());
            
      movieContextMock.AddMovie(movieToAdd);
      int actualCount = movieContextMock.GetNumberOfMovies();

      Assert.AreEqual(1, actualCount);
      Assert.AreEqual("robocop",movieContextMock.Movies.ToList()[0].Title);
    }
  }
}
