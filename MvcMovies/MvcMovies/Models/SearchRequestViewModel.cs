using System.ComponentModel.DataAnnotations;

namespace MvcMovies.Models
{
  public class SearchRequestViewModel
  {
    public int NumRows { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "{0} must be between {2} and {1} characters long", MinimumLength = 3)]
    public string SearchTerm { get; set; }

    public int StartAt{ get; set; }
  }
}