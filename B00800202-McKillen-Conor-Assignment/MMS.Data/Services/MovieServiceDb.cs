using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using MMS.Data.Models;
using MMS.Data.Repositories;
using System.Text.Json;
using System.IO;
using System.Runtime.CompilerServices;


namespace MMS.Data.Services
{
    public class MovieServiceDb : IMovieService
    {
        private readonly MovieDbContext db;
       

        public MovieServiceDb()
        {
            db = new MovieDbContext();
        }

        public Movie AddMovie(Movie m)
        {
            // Check if movie id actually exists
            var existing = GetMovieById(m.Id);
            if (existing != null)
            {
                return null; // Movie id exists so it cannot be created
            }

            // Movie is unique so go ahead and create a movie
            m = new Movie()
            {
                Title = m.Title,
                Director = m.Director,
                Year = m.Year,
                Duration = m.Duration,
                Budget = m.Budget,
                PosterUrl = m.PosterUrl,
                Genre = m.Genre,
                Cast = m.Cast,
                Plot = m.Plot
            };

            db.Movies.Add(m);
            db.SaveChanges(); // write to databases

            return m;
        }

        public Review AddReview(Review r)
        {
            var existing = GetReviewById(r.Id);
            if (existing != null)
            {
                return null; // Review id exists so it cannot be created
            }

            // Review is unique so go ahead and create review
            r = new Review()
            {
                Id = r.Id,
                Name = r.Name,
                CreatedOn = r.CreatedOn,
                Comment = r.Comment,
                Rating = r.Rating,
                MovieId = r.MovieId,
                Movie = r.Movie
            };

            db.Reviews.Add(r);
            db.SaveChanges(); // write to database

            return r;
        }

        public bool DeleteMovie(int id)
        {
            // Check if the movie exists
            // If null then there is nothing to delete
            var m = GetMovieById(id);
            if (m == null)
            {
                return false;
            }

            db.Movies.Remove(m);
            db.SaveChanges(); // write to database

            return true;
        }


        public Review GetReview(int id)
        {
            var review = db.Movies.SelectMany(m => m.Reviews).FirstOrDefault(r => r.Id == id);
            return review;
        }

        public bool DeleteReview(int id)
        {
            // find review
            // Check if the review exists
            // If null then there is nothing to delete
            var review = GetReviewById(id);
            if (review == null) return false;

            // remove review
            db.Reviews.Remove(review);

            db.SaveChanges();

            return true;
        }

        // Retrieve all reviews and movies associated with the ticket
        public IList<Review> GetAllReviews()
        {
            return db.Reviews
                .Include(r => r.Movie)
                .ToList();
        }


        public IList<Movie> GetAllMovies(string order = null)
        {
            return db.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return db.Movies.Include(m => m.Reviews).FirstOrDefault(m => m.Id == id);
        }

        public Review GetReviewById(int id)
        {
            return db.Reviews.FirstOrDefault(r => r.Id == id);
        }

        public void Initialise()
        {
            db.Initialise();
        }

        public bool UpdateMovie(Movie m)
        {
            //verify the movie exists
            var movie = GetMovieById(m.Id);
            if (movie == null)
            {
                return false;
            }

            // updated the details of the student retrieved and save
            movie.Title = m.Title;
            movie.Director = m.Director;
            movie.Year = m.Year;
            movie.Duration = m.Duration;
            movie.Budget = m.Budget;
            movie.PosterUrl = m.PosterUrl;
            movie.Genre = m.Genre;
            movie.Cast = m.Cast;
            movie.Plot = m.Plot;

            db.SaveChanges(); // write to database

            return true;
        }
    }

 
}