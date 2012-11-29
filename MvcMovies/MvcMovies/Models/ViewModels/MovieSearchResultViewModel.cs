using System.Collections.Generic;

namespace MvcMovies.Models.ViewModels
{
  public class MovieSearchResultViewModel
  {
    public MovieSearchResultViewModel()
    {
      Movies = new List<Movie>();
    }

    public IEnumerable<Movie> Movies { get; set; }

    public string PageTitle { get; set;  }
  }
}