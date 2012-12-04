using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcMovies.Models;
using MvcMovies.Repositories;

namespace MvcMovies.Tests.Models
{
  [TestClass]
  public class MovieTest
  {
    [TestMethod]
    public void It_Should_Be_Marked_As_Checked_Out()
    {
      var movie = new Movie {Title = "Title", Id = 4};

      movie.Checkout();

      Assert.IsTrue(movie.CheckedOut);
    }

    [TestMethod,ExpectedException(typeof(MovieNotAvailableException))]
    public void It_Cannot_Be_Checked_Out_Again()
    {
      var movie = new Movie {Id = 100, Title = "Hotel Transylvania"};

      movie.Checkout();

      movie.Checkout(); // throws
    }

    [TestMethod]
    public void Can_Fetch_A_Movie()
    {
      var movie = new Movie {Title = "Title", Id = 4};
      var mockRepo = new Mock<MovieRepository>();
      mockRepo.Setup(repo => repo.GetMovie(movie.Id)).Returns(movie);

      Movie fetchedMovie = Movie.Get(mockRepo.Object, movie.Id);

      Assert.AreEqual(movie, fetchedMovie);
    }

    [TestMethod]
    public void Can_Create_A_Movie()
    {
      var movie = new Movie {Title = "Teen Wolf", Id = 4};
      var mockRepo = new Mock<MovieRepository>();
      mockRepo.Setup(repo => repo.AddMovie(movie)).Returns(movie);

      Movie createdMovie = Movie.Create(mockRepo.Object, movie);

      Assert.AreEqual(movie, createdMovie);
    }
  }
}
