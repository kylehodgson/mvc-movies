using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcMovies.Models;

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
  }
}
