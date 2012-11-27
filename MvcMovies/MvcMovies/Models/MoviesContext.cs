using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMovies.Models
{
  public class MoviesContext : DbContext
  {
    public DbSet<Movie> Movies { get; set; }

    public virtual int GetNumberOfMovies()
    {
      return Movies.Count();
    }

    public virtual void AddMovie(Movie movie)
    {
      Movies.Add(movie);
    }

    public virtual IEnumerable<Movie> SearchMovie(string title)
    {
      return Movies.Where(movie => movie.Title == title);
    }

  }
}