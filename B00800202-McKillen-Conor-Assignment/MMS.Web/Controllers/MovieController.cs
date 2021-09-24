using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMS.Data.Models;
using MMS.Data.Services;
using MMS.Web.Models;

namespace MMS.Web.Controllers
{

    public class MovieController : BaseController
    {
        private IMovieService svc;

        public MovieController()
        {
            svc = new MovieServiceDb();
        }

        //GET /movie
        public IActionResult Index()
        {
            // retrieve all movies
            var movies = svc.GetAllMovies();

            return View(movies);
        }

        public IActionResult Directors()
        {
            // retrieve all movies
            var movies = svc.GetAllMovies();

            return View(movies);
        }

        public IActionResult Titles()
        {
            // retrieve all movies
            var movies = svc.GetAllMovies();

            return View(movies);
        }

        public IActionResult Years()
        {
            // retrieve all movies
            var movies = svc.GetAllMovies();

            return View(movies);
        }

        public IActionResult Details(int id)
        {
            // retrieve the movie with specified id from the service
            var m = svc.GetMovieById(id);

            // Check if m is null and return NotFound()
            if (m == null)
            {
                Alert("Movie not found", AlertType.Warning);
                return RedirectToAction(nameof(Index));
            }

            // pass movie as parameter to the view

            return View(m);
        }

        // GET /movie/create
        public IActionResult Create()
        {
            // display blank form to create a movie
            var m = new Movie();

            if (m == null)
            {
                Alert("Movie not found", AlertType.Info);
                return RedirectToAction(nameof(Index));
            }

            return View(m);
        }

        // POST /movie/create
        [HttpPost]
        public IActionResult Create(Movie m)
        {
            // verify the model is valid
            if (ModelState.IsValid)
            {
                // pass data to service to store
                svc.AddMovie(m);

                Alert("Movie was created", AlertType.Success);

                return RedirectToAction(nameof(Index));
            }

            // redisplay the form for editing and there are validation errors

            return View(m);
        }

        // GET /movie/edit/{id}
        public IActionResult Edit(int id)
        {
            // load the movie using the service 
            var m = svc.GetMovieById(id);

            // check if m is null and return NotFound()
            if (m == null)
            {
                Alert("Movie not found", AlertType.Warning);
                return RedirectToAction(nameof(Index));
            }

            // pass movie to view for editing
            return View(m);
        }

        // POST /movie/edit/{id}
        [HttpPost]
        public IActionResult Edit(int id, Movie m)
        {
            // verify movie model is valid
            if (ModelState.IsValid)
            {
                // pass data to service to update
                var updated = svc.UpdateMovie(m);

                Alert("Movie was updated", AlertType.Success);

                return RedirectToAction(nameof(Index));
            }

            // redisplay the form for editing as validation errors
            return View(m);
        }

        // GET /movie/delete/{id}
        public IActionResult Delete(int id)
        {
            // load the movie using the service
            var m = svc.GetMovieById(id);

            // check the returned movie is not null and if so return NotFound()
            if (m == null)
            {
                Alert("Movie not found", AlertType.Warning);

                return RedirectToAction(nameof(Index));
            }

            // pass movie to view for deletion confirmation
            return View(m);
        }

        // POST /movie/delete/{id}
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            // delete movie via service
            svc.DeleteMovie(id);

            // redirect to the index view
            Alert("Movie was deleted", AlertType.Success);
            return RedirectToAction(nameof(Index));
        }

        // GET /movies/createreview
        public IActionResult CreateReview(int id)
        {
            var m = svc.GetMovieById(id);

            // check the returned movie is not null and if so alert
            if (m == null)
            {
                Alert($"No such movie {id}", AlertType.Warning);
                return RedirectToAction(nameof(Index));
            }

            // create the review and populate the MovieId property
            var r = new Review()
            {
                MovieId = id
            };

            return View(r);
        }

        
        // POST /movie/createreview
        [HttpPost]
        public IActionResult CreateReview(Review r)
        {
           
            // check the returned movie is not null
            if (r == null)
            {
                Alert($"No such movie {r.MovieId}", AlertType.Warning);
                return RedirectToAction(nameof(Index));
            }

            // create the review and populate the MovieId property
            svc.AddReview(r);
            Alert($"Review created successfully", AlertType.Success);

            return RedirectToAction("Details", new {Id = r.MovieId});
        }
        


    }


}