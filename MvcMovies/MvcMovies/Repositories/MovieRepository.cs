using System;
using System.Collections.Generic;
using System.Data.Entity;
using MvcMovies.Models;

namespace MvcMovies.Repositories
{
  public class MovieRepository
  {
    private MoviesContext MovieContext;

    public MovieRepository()
    {
      MovieContext = new MoviesContext();
    }

    public MovieRepository(MoviesContext moviesContext = null)
    {
      MovieContext = moviesContext ?? new MoviesContext();
    }

    public virtual IEnumerable<Movie> SearchMovies(string movieTitle)
    {
      return MovieContext.SearchMovie(movieTitle);
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