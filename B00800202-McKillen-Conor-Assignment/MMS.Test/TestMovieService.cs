
using System;
using System.Linq;
using Xunit;

using MMS.Data.Models;
using MMS.Data.Services;

namespace MMS.Test
{
    public class TestMovieService 
    {
        private readonly IMovieService _svc;
              
        public TestMovieService()
        {
            // create and initialise MovieServiceDb service

            // general arrangement
            _svc = new MovieServiceDb();

            // ensure data source is empty before each test 
            _svc.Initialise();
        }

        // add tests here - test should ensure your service implementation works
        [Fact]
        public void Movie_GetMoviesWhenNone_ShouldReturnNone() 
        {
            // arrange

            // act
            var movies = _svc.GetAllMovies();
            var count = movies.Count;

            // assert
            Assert.Equal(0, count);
        }

        [Fact]
        public void Movie_AddMovieWhenUnique_ShouldSetAllProperties()
        {
            // arrange
            var m = new Movie()
            {
                Title = "Rocky",
                Budget = 1000000,
                Year = 1976,
                Cast = "Stallone",
                Director = "John G. Avildsen",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Boxing",
                PosterUrl = "https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg"
            };

            // act
            var o =_svc.AddMovie(m);

            var s = _svc.GetMovieById(o.Id); // retrieve movie saved

            // assert - that movie is not null
            Assert.NotNull(s);
            Assert.Equal(s.Id, s.Id);
            Assert.Equal("Rocky", s.Title);
            Assert.Equal(1000000, s.Budget);
            Assert.Equal(1976, s.Year);
            Assert.Equal("Stallone", s.Cast);
            Assert.Equal("John G. Avildsen", s.Director);
            Assert.Equal(136, s.Duration);
            Assert.Equal(Genre.Action, s.Genre);
            Assert.Equal("Boxing", s.Plot);
            Assert.Equal("https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg", s.PosterUrl);
        }

        
        [Fact]
        public void Movie_UpdateWhenExists_ShouldSetAllProperties()
        {
            // arrange - create test movie

            var m = new Movie()
            {
                Title = "Rocky",
                Budget = 1000000,
                Year = 1976,
                Cast = "Stallone",
                Director = "John G. Avildsen",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Boxing",
                PosterUrl = "https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg"
            };


            var o =_svc.AddMovie(m);

            // act - update test movie
            o.Title = "The Death of Stalin";
            o.Budget = 13000000;
            o.Year = 2017;
            o.Cast = "Steve Buscemi, Simon Russel Beale, Paddy Considine";
            o.Director = "Armando Iannucci";
            o.Duration = 117;
            o.Genre = Genre.Comedy;
            o.Plot = "When the tyrannical ruler Stalin dies, his hapless inner circle scrambles to come up with the next evolution of the revolution ? but it's clear everyone is really out for themselves.";
            o.PosterUrl = "https://www.themoviedb.org/t/p/original/66nL9hKPerEZMOeCQuWD322Nm8g.jpg";

            _svc.UpdateMovie(o);

            // assert
            Assert.NotNull(o);
            Assert.Equal("The Death of Stalin", o.Title);
            Assert.Equal(13000000, o.Budget);
            Assert.Equal(2017, o.Year);
            Assert.Equal("Steve Buscemi, Simon Russel Beale, Paddy Considine", o.Cast);
            Assert.Equal("Armando Iannucci", o.Director);
            Assert.Equal(117, o.Duration);
            Assert.Equal(Genre.Comedy, o.Genre);
            Assert.Equal("When the tyrannical ruler Stalin dies, his hapless inner circle scrambles to come up with the next evolution of the revolution ? but it's clear everyone is really out for themselves.", o.Plot);
            Assert.Equal("https://www.themoviedb.org/t/p/original/66nL9hKPerEZMOeCQuWD322Nm8g.jpg", o.PosterUrl);

        }

        [Fact]
        public void Movie_GetMoviesWhenTwoAdded_ShouldReturnTwo()
        {
            // arrange
            var m = new Movie()
            {
                Title = "Rocky",
                Budget = 1000000,
                Year = 1976,
                Cast = "Stallone",
                Director = "John G. Avildsen",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Boxing",
                PosterUrl = "https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg"
            };


            var o = new Movie()
            {
                Title = "The Death of Stalin",
                Budget = 13000000,
                Year = 2017,
                Cast = "Steve Buscemi, Simon Russel Beale, Paddy Considine",
                Director = "Armando Iannucci",
                Duration = 117,
                Genre = Genre.Comedy,
                Plot = "When the tyrannical ruler Stalin dies, his hapless inner circle scrambles to come up with the next evolution of the revolution ? but it's clear everyone is really out for themselves.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/66nL9hKPerEZMOeCQuWD322Nm8g.jpg"
            };

            var s1 = _svc.AddMovie(m);
            var s2 = _svc.AddMovie(o);

            // act
            var movies = _svc.GetAllMovies();
            var count = movies.Count;

            // assert
            Assert.Equal(2, count);
        }

        [Fact]
        public void Movie_GetMovieWhenNone_ShouldReturnNull()
        {
            // arrange

            // act
            var movie = _svc.GetMovieById(1);

            // assert
            Assert.Null(movie);
        }

        [Fact]
        public void Movie_GetMovieThatExists_ShouldReturnMovie()
        {
            // arrange
            var m = new Movie()
            {
                Title = "Rocky",
                Budget = 1000000,
                Year = 1976,
                Cast = "Stallone",
                Director = "John G. Avildsen",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Boxing",
                PosterUrl = "https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg"
            };

            var s = _svc.AddMovie(m);

            // act
            var ns = _svc.GetMovieById(s.Id);

            // assert
            Assert.NotNull(ns);
            Assert.Equal(s.Id, ns.Id);
        }

        [Fact]
        public void Movie_DeleteMovieThatExists_ShouldReturnTrue()
        {
            // arrange
            var m = new Movie()
            {
                Title = "Rocky",
                Budget = 1000000,
                Year = 1976,
                Cast = "Stallone",
                Director = "John G. Avildsen",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Boxing",
                PosterUrl = "https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg"
            };

            var s = _svc.AddMovie(m);

            // act

            var deleted = _svc.DeleteMovie(s.Id);
            var s1 = _svc.GetMovieById(s.Id); // try to retrieve deleted movie

            // assert

            Assert.True(deleted); // delete movie should return true
            Assert.Null(s1); // m1 should be null
        }

        [Fact]
        public void Movie_DeleteMovieThatExists_ShouldReduceMovieCountByOne()
        {
            // arrange
            var m = new Movie()
            {
                Title = "Rocky",
                Budget = 1000000,
                Year = 1976,
                Cast = "Stallone",
                Director = "John G. Avildsen",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Boxing",
                PosterUrl = "https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg"
            };

            var s =_svc.AddMovie(m);

            // act

            _svc.DeleteMovie(s.Id);
            var movies = _svc.GetAllMovies();

            // assert

            Assert.Equal(0, movies.Count); // should be 0 movies
        }

        [Fact]
        public void Movie_DeleteMovieThatDoesntExist_ShouldNotChangeMovieCount()
        {
            // arrange
            var m = new Movie()
            {
                Title = "Rocky",
                Budget = 1000000,
                Year = 1976,
                Cast = "Stallone",
                Director = "John G. Avildsen",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Boxing",
                PosterUrl = "https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg"
            };

            _svc.AddMovie(m);

            // act
            _svc.DeleteMovie(0); // delete non existant movie
            var movies = _svc.GetAllMovies(); // retrieve list of movies

            // assert
            Assert.Equal(1, movies.Count); // should be 1 student

        }

        // ------------------------------------ REVIEW TESTS -------------------------------------------------------

        [Fact]
        public void Review_GetReviewsWhenNone_ShouldReturnNone()
        {
            // arrange

            // act
            var reviews = _svc.GetAllReviews();
            var count = reviews.Count();

            // assert

            Assert.Equal(0, count);
        }

        [Fact]
        public void Review_AddReviewWhenUnique_ShouldSetAllProperties()
        {
            // arrange

            var m = new Movie()
            {
                Title = "Rocky",
                Budget = 1000000,
                Year = 1976,
                Cast = "Stallone",
                Director = "John G. Avildsen",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Boxing",
                PosterUrl = "https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg"
            };

            _svc.AddMovie(m);

            var r = new Review()
            {
         
                MovieId = m.Id,
                Name = "Joe Rogan",
                CreatedOn = new DateTime(2019, 11, 06),
                Comment = "Amazing",
                Rating = 9
            };

            var o = _svc.AddReview(r);

            var s = _svc.GetReviewById(o.Id); // retrieve review saved

            // assert - that the review is not null
            Assert.NotNull(s);
            Assert.Equal(s.Id, s.Id);
            Assert.Equal("Joe Rogan", s.Name);
            Assert.Equal(s.CreatedOn, s.CreatedOn);
            Assert.Equal("Amazing", s.Comment);
            Assert.Equal(9, s.Rating);
        }

        [Fact]
        public void Review_GetReviewsWhenTwoAdded_ShouldReturnTwo()
        {
            // arrange

            var m = new Movie()
            {
                Title = "Rocky",
                Budget = 1000000,
                Year = 1976,
                Cast = "Stallone",
                Director = "John G. Avildsen",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Boxing",
                PosterUrl = "https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg"
            };

            _svc.AddMovie(m);

            var o = new Movie()
            {
                Title = "The Death of Stalin",
                Budget = 13000000,
                Year = 2017,
                Cast = "Steve Buscemi, Simon Russel Beale, Paddy Considine",
                Director = "Armando Iannucci",
                Duration = 117,
                Genre = Genre.Comedy,
                Plot = "When the tyrannical ruler Stalin dies, his hapless inner circle scrambles to come up with the next evolution of the revolution ? but it's clear everyone is really out for themselves.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/66nL9hKPerEZMOeCQuWD322Nm8g.jpg"
            };

            _svc.AddMovie(o);
           
            var r1 = new Review()
            {
                
                Name = "Joe Rogan",
                CreatedOn = new DateTime(2019, 11, 06),
                Comment = "Amazing",
                Rating = 9
            };

            var s1 = _svc.AddReview(r1);

            var r2 = new Review()
            {
               
                Name = "Shayne",
                CreatedOn = new DateTime(2018, 01, 12),
                Comment = "Awful",
                Rating = 2
            };

            var s2 =_svc.AddReview(r2);

            // act

            var reviews = _svc.GetAllReviews();
            var count = reviews.Count;

            // assert
            Assert.Equal(2, count);
        }

        [Fact]
        public void Review_GetReviewWhenNone_ShouldReturnNull()
        {
            // arrange

            // act
            var review = _svc.GetReviewById(1); // non existent review

            // assert
            Assert.Null(review);
        }

        [Fact]
        public void Review_GetReviewThatExists_ShouldReturnReview()
        {
            // arrange
            var m = new Movie()
            {
                Title = "Rocky",
                Budget = 1000000,
                Year = 1976,
                Cast = "Stallone",
                Director = "John G. Avildsen",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Boxing",
                PosterUrl = "https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg"
            };

            _svc.AddMovie(m);

            var r = new Review()
            {
                
                Name = "Joe Rogan",
                CreatedOn = new DateTime(2019, 11, 06),
                Comment = "Amazing",
                Rating = 9
            };

            var s =_svc.AddReview(r);

            // act
            var ns = _svc.GetReviewById(r.Id);

            // assert
            Assert.NotNull(ns);
            Assert.Equal(s.Id, ns.Id);
        }

        [Fact]
        public void Review_DeleteReviewThatExists_ShouldReturnTrue()
        {
            // arrange

            var m = new Movie()
            {
                Title = "Rocky",
                Budget = 1000000,
                Year = 1976,
                Cast = "Stallone",
                Director = "John G. Avildsen",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Boxing",
                PosterUrl = "https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg"
            };

            _svc.AddMovie(m);

            var r = new Review()
            {
               
                Name = "Joe Rogan",
                CreatedOn = new DateTime(2019, 11, 06),
                Comment = "Amazing",
                Rating = 9
            };

            var s = _svc.AddReview(r);

            // act
            var deleted = _svc.DeleteReview(s.Id);
            var s1 = _svc.GetReviewById(s.Id);

            // assert
            Assert.True(deleted); // delete student should return true
            Assert.Null(s1); // r1 should be null
        }

        [Fact]
        public void Review_DeleteReviewThatExists_ShouldReduceReviewCountByOne()
        {
            // arrange
            var m = new Movie()
            {
                Title = "Rocky",
                Budget = 1000000,
                Year = 1976,
                Cast = "Stallone",
                Director = "John G. Avildsen",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Boxing",
                PosterUrl = "https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg"
            };

            _svc.AddMovie(m);

            var r = new Review()
            {
                MovieId = m.Id,
                Name = "Joe Rogan",
                CreatedOn = new DateTime(2019, 11, 06),
                Comment = "Amazing",
                Rating = 9
            };

            var s = _svc.AddReview(r);

            // act
            var deleted = _svc.DeleteReview(s.Id);
            var reviews = _svc.GetAllReviews();

            // assert
            Assert.Equal(0, reviews.Count); // should be 0 reviews
        }

        [Fact]
        public void Review_DeleteReviewThatDoesntExist_ShouldNotChangeReviewCount()
        {
            // arrange
            var m = new Movie()
            {
                Title = "Rocky",
                Budget = 1000000,
                Year = 1976,
                Cast = "Stallone",
                Director = "John G. Avildsen",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Boxing",
                PosterUrl = "https://www.themoviedb.org/t/p/original/i5xiwdSsrecBvO7mIfAJixeEDSg.jpg"
            };

            _svc.AddMovie(m);

            var r = new Review()
            {
                MovieId = m.Id,
                Name = "Joe Rogan",
                CreatedOn = new DateTime(2019, 11, 06),
                Comment = "Amazing",
                Rating = 9
            };

            var s = _svc.AddReview(r);


            // act
            _svc.DeleteReview(0); // delete non existent review
            var reviews = _svc.GetAllReviews(); // retrieve list of reviews

            // assert
            Assert.Equal(1, reviews.Count); // should be 1 review

        }


    }
}
