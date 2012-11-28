using System;
using System.Collections.Generic;
using MvcMovies.Repositories;

namespace MvcMovies.Models
{
  public class MovieCatalogue
  {
    private MovieRepository _movieRepository;

    public MovieCatalogue()
    {
      _movieRepository = new MovieRepository();
    }

    public MovieCatalogue(MovieRepository movieRepository = null)
    {
      _movieRepository = movieRepository ?? new MovieRepository();
    }

    public virtual IEnumerable<Movie> SearchMovies(string title)
    {
      return _movieRepository.SearchMovies(title);
    }
  }
}