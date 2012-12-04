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
  }
}