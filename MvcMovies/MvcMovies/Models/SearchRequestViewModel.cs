using System.ComponentModel.DataAnnotations;

namespace MvcMovies.Models
{
  public class SearchRequestViewModel
  {
    public int NumRows { get; set; }

    [Required]
    [MinLength(3)]
    public string SearchTerm { get; set; }

    public int StartAt{ get; set; }
  }
}