namespace MvcMovies.Controllers
{
  public class SearchRequest
  {
    public int NumRows { get; set; }

    public string SearchTerm { get; set; }

    public int StartAt{ get; set; }
  }
}