
using System;
using System.Collections.Generic;
using MMS.Data.Models;

namespace MMS.Data.Services
{
    public interface IMovieService
    {
        void Initialise();
        IList<Movie> GetAllMovies(string order=null);
        Movie GetMovieById(int id);
        bool DeleteMovie(int id);
        bool UpdateMovie(Movie m);
        Movie AddMovie(Movie m);

        // Review management

        Review GetReviewById(int id);
        Review AddReview(Review r);
        bool DeleteReview(int id);
        
        IList<Review> GetAllReviews();


    }
}