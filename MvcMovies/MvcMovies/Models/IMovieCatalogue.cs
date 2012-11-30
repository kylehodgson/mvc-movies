using System.Collections.Generic;

namespace MvcMovies.Models
{
  public interface IMovieCatalogue
  {
    IEnumerable<Movie> SearchMovies(string title);
  }
}