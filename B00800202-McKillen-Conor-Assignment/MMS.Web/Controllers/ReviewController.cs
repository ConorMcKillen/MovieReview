using Microsoft.AspNetCore.Mvc;
using MMS.Data.Models;
using MMS.Data.Services;

namespace MMS.Web.Controllers
{
    public class ReviewController : BaseController
    {
        private IMovieService svc;

        public ReviewController()
        {
            svc = new MovieServiceDb();
        }

        // GET /review/index
        public IActionResult Index()
        {
            // retrieve all movies
            var r = svc.GetAllReviews();

            return View(r);
        }

        public IActionResult Details(int id)
        {
            // retrieve the review with specified id from the service
            var r = svc.GetReviewById(id);

            // Check if r is null
            if (r == null)
            {
                Alert("Review not found", AlertType.Warning);
                return RedirectToAction(nameof(Index));
            }

            // pass review as parameter to the view

            return View(r);
        }

        // GET: /review/create
        public IActionResult Create()
        {
            // display blank form to create a review
            var r = new Review();
            return View(r);
        }

        // POST /review/create
        [HttpPost]
        public IActionResult Create(Review r)
        {
            if (ModelState.IsValid)
            {
                // pass data to service to store
                svc.AddReview(r);

                Alert("Review created successfully", AlertType.Info);
                return RedirectToAction(nameof(Index));
            }

            //redisplay the form for editing as there are validation errors
            return View(r);
        }

        // GET /review/delete/{id}
        public IActionResult Delete(int id)
        {
            // load the review using the service
            var r = svc.GetReviewById(id);

            // check the returned review is not null
            if (r == null)
            {
                Alert("Review not found", AlertType.Warning);
                return RedirectToAction(nameof(Index));
            }
            // pass review to view for deletion confirmation
            return View(r);
        }

        // POST /review/delete/{id}
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            // delete review via service
            svc.DeleteReview(id);

            Alert($"Review {id} deleted successfully", AlertType.Success);

            // redirect to index view

            return RedirectToAction(nameof(Index));
        }
    }
}