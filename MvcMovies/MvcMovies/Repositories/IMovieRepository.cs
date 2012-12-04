using System.Collections.Generic;
using MvcMovies.Models;

namespace MvcMovies.Repositories
{
  public interface IMovieRepository
  {
    IEnumerable<Movie> SearchMovies(string movieTitle);
    int Count();
    Movie AddMovie(Movie movie);
  }
}