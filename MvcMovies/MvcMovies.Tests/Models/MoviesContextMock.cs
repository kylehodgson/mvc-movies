using System.Collections.Generic;
using MvcMovies.Models;

namespace MvcMovies.Tests.Models
{
  internal class MoviesContextMock : MoviesContext
  {
    public MoviesContextMock(List<Movie> movies)
    {
      Movies = movies;
    }

    
  }
}