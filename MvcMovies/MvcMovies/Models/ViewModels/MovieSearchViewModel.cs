namespace MvcMovies.Models.ViewModels
{
  public class MovieSearchViewModel
  {
    public string PageTitle { get; set; }

    public string Heading { get; set; }

    public SearchRequest SearchRequest { get; set; }
  }
}