using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using MMS.Data.Models;

namespace MMS.Data.Services
{
    public class MovieServiceList : IMovieService
    {
        private readonly string STORE = "movies.json";

        private IList<Movie> Movies;
        private IList<Review> Reviews;


        public MovieServiceList()
        {
            Load();
        }

        // load data from local json store 
        private void Load()
        {
            try
            {
                string json = File.ReadAllText(STORE);
                Movies = JsonSerializer.Deserialize<List<Movie>>(json);
            }
            catch (Exception)
            {
                Movies = new List<Movie>();
            }
        }

        private void Store()
        {
            var json = JsonSerializer.Serialize(Movies);
            File.WriteAllText(STORE, json);
        }

        public void Initialise()
        {
            Movies.Clear();
        }

        public IList<Movie> GetAllMovies(string order = null)
        {
            return Movies.ToList();
        }


        // Retrieve movie by ID
        public Movie GetMovieById(int id)
        {
            return Movies.FirstOrDefault(m => m.Id == id);
        }

        // Add new movie
        public Movie AddMovie(Movie m)
        {
            // check if id already in use
            var existing = GetMovieById(m.Id);
            if (existing != null)
            {
                return null;
            }

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
            Movies.Add(m);
            Store();
            return m;
        }


        public bool DeleteMovie(int id)
        {
            var m = GetMovieById(id);
            if (m == null)
            {
                return false;
            }

            Movies.Remove(m);
            Store();

            return true;
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

            Store();

            return true;
        }

        public Review GetReviewById(int id)
        {
            return Reviews.FirstOrDefault(r => r.Id == id);
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

            Reviews.Add(r);
            Store(); // write to database

            return r;
        }

        public bool DeleteReview(int id)
        {
            var r = GetReviewById(id);
            if (r == null)
            {
                return false;
            }

            Reviews.Remove(r);
            Store(); // write to database

            return true;
        }

        public IList<Review> GetAllReviews()
        {
            return Reviews.ToList();
        }

    }
}
