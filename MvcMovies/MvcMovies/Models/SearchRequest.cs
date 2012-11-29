﻿using System.ComponentModel.DataAnnotations;

namespace MvcMovies.Models
{
  public class SearchRequest
  {
    public int NumRows { get; set; }

    [Required]
    [MinLength(3)]
    public string SearchTerm { get; set; }

    public int StartAt{ get; set; }
  }
}