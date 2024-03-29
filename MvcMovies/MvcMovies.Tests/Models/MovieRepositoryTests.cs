﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcMovies.Models;
using MvcMovies.Repositories;

namespace MvcMovies.Tests
{
  [TestClass]
  public class MovieRepositoryTests
  {
    private const string movieTitle = "Lord of the flies";

    [TestMethod]
    public void It_Should_Be_Able_To_Search_Movies()
    {
      // arrange
      Mock<MoviesContext> mockContext = new Mock<MoviesContext>();
      var movie = new Movie {Title = movieTitle};
      mockContext.Setup(context => context.SearchMovie(movieTitle)).Returns(new List<Movie> {movie});
      var repo = new MovieRepository(mockContext.Object);

      // act
      var testMovie = new Movie { Title = movieTitle };
      repo.AddMovie(testMovie);
      int expectedCount = 1;

      // act
      IEnumerable<Movie> result = repo.SearchMovies(movieTitle);

      // assert
      Assert.AreEqual(expectedCount, result.Count());
      Assert.AreEqual(movieTitle, result.ToList()[0].Title);
    }

    [TestMethod]
    public void It_Should_Be_Able_To_Count_Movies_In_The_Repository()
    {
      Mock<MoviesContext> mockContext = new Mock<MoviesContext>();
      mockContext.Setup(context => context.GetNumberOfMovies()).Returns(1);

      var repo = new MovieRepository(mockContext.Object);
      int expected = 1;
      int count = repo.Count();

      Assert.AreEqual(expected, count);
    }

    [TestMethod]
    public void It_Should_Be_Able_To_Add_Movies()
    {
     // arrange
      var testMovie = new Movie { Title = movieTitle };
      Mock<MoviesContext> mockContext = new Mock<MoviesContext>();
      mockContext.Setup(ctx => ctx.AddMovie(testMovie)).Returns(testMovie);
      var repo = new MovieRepository(mockContext.Object);

      // act
      
      var result = repo.AddMovie(testMovie);

      // assert
      mockContext.Verify(m => m.AddMovie(testMovie),Times.Once());
      Assert.AreEqual(testMovie, result);
    }

    [TestMethod]
    public void It_Should_Get_Individual_Movies()
    {
      var movie = new Movie {Id = 123, Title = "The Best Tiotle Ever"};
      var mockContext = new Mock<MoviesContext>();
      mockContext.Setup(it => it.GetMovie(movie.Id)).Returns(movie);
      var repo = new MovieRepository(mockContext.Object);

      var result = repo.GetMovie(movie.Id);

      Assert.AreEqual(movie, result);
    }
  }

}
