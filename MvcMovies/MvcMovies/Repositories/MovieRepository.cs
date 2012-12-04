using System;
using System.Collections.Generic;
using System.Data.Entity;
using MvcMovies.Models;

namespace MvcMovies.Repositories
{
  public class MovieRepository : IMovieRepository
  {
    private MoviesContext _movieContext;

    public MovieRepository()
    {
      _movieContext = new MoviesContext();
    }

    public MovieRepository(MoviesContext moviesContext = null)
    {
      _movieContext = moviesContext ?? new MoviesContext();
    }

    public virtual IEnumerable<Movie> SearchMovies(string movieTitle)
    {
      return _movieContext.SearchMovie(movieTitle);
    }

    public int Count()
    {
      return _movieContext.GetNumberOfMovies();
    }

    public virtual Movie AddMovie(Movie movie)
    {
      return _movieContext.AddMovie(movie);
    }

    public virtual Movie GetMovie(int id)
    {
      return _movieContext.GetMovie(id);
    }
  }
}