using System.Collections.Generic;
using MvcMovies.Repositories;

namespace MvcMovies.Models
{
  public class Movie
  {
    public string Title { get; set; }
    public int Id { get; set;  }

    public bool CheckedOut { get; private set; }

    public void Checkout()
    {
      if (CheckedOut)
      {
        throw new MovieNotAvailableException();
      }
      
      CheckedOut = true;
    }

    public static Movie Get(MovieRepository movieRepository, int id)
    {
      return movieRepository.GetMovie(id);
    }

    public static Movie Create(MovieRepository movieRepository, Movie movie)
    {
      return movieRepository.AddMovie(movie);
    }
  }
}