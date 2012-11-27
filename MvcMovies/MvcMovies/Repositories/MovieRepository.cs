using System.Collections.Generic;
using System.Data.Entity;
using MvcMovies.Models;

namespace MvcMovies.Repositories
{
  public class MovieRepository
  {
    private MoviesContext MovieContext;

    public MovieRepository(MoviesContext moviesContext = null)
    {
      MovieContext = moviesContext ?? new MoviesContext();
    }


    public IEnumerable<Movie> SearchMovies(string movieTitle)
    {
      return new List<Movie> {new Movie {Title = movieTitle}};
    }

    public int Count()
    {
      return MovieContext.GetNumberOfMovies();
    }

    public void AddMovie(Movie movie)
    {
      MovieContext.AddMovie(movie);
    }
  }
}