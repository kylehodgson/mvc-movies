using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MvcMovies.Models
{
  public class MoviesContext : DbContext
  {
//    public DbSet<Movie> Movies { get; set; }
    public List<Movie> Movies =
      Enumerable.Range(1, 10).Select(i => new Movie
                                            {
                                              Title = String.Format("Halloween {0}", i)
                                            }
        ).ToList();


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
      return Movies.Where(movie => movie.Title.ToLower().Contains(title.ToLower()));
    }
  }
}