using System.Collections.Generic;

namespace MvcMovies.Models.ViewModels
{
  public class MovieSearchResultViewModel
  {
    public string Title { get; set;  }
    public IEnumerable<Movie> Movies { get; set; }
  }
}