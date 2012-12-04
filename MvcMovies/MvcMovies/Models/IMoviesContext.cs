using System.Collections.Generic;

namespace MvcMovies.Models
{
  public interface IMoviesContext
  {
    int GetNumberOfMovies();
    Movie AddMovie(Movie movie);
    IEnumerable<Movie> SearchMovie(string title);
  }
}