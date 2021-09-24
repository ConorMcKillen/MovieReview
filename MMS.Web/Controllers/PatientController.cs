using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MMS.Data.Models;
using MMS.Data.Services;
using MMS.Web.Models;

namespace MMS.Web.Controllers
{
    [Authorize]
    public class PatientController : BaseController
    {
        private IPatientService svc;

        // Configured via DI
        public PatientController(IPatientService ps)
        {
            svc = ps;
        }

        // GET /patient/index
        public IActionResult Index()
        {
            var patients = svc.GetPatients();

            return View(patients);
        }

        // GET /patient/details/{id}
        public IActionResult Details(int id)
        {
            // retrieve the patient with the specified id from the service
            var p = svc.GetPatient(id);

            // check if p is null and return NotFound()
            if(p == null)
            {
                Alert("Patient not found!", AlertType.Warning);
                return RedirectToAction(nameof(Index));
            }

            // pass patient as parameter to the view
            return View(p);
        }

        // GET /patient/create
        [Authorize(Roles ="admin")]
        public IActionResult Create()
        {
            // display blank form to create patient
            var p = new Patient();
            return View(p);
        }

        // POST /patient/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create([Bind("Name, Email, Age")] Patient p)
        {
            // check email is unique for this patient
            if (svc.IsDuplicateEmail(p.Email, p.Id))
            {
                // add manual validation error
                ModelState.AddModelError(nameof(p.Email), "The email address is already in use");
            }

            // validate patient
            if(ModelState.IsValid)
            {
                // pass data to service to store
                var added = svc.AddPatient(p.Name, p.Email, p.Age);
                Alert("Patient created successfully", AlertType.Info);

                return RedirectToAction(nameof(Index));
            }

            // redisplay the form for editing as there are validation errors
            return View(p);
        }

        // GET /patient/edit/{id}
        [Authorize(Roles="admin,manager")]
        public IActionResult Edit(int id)
        {
            // load the patient using the service
            var p = svc.GetPatient(id);

            // check if p is null and return NotFound()
            if (p == null)
            {
                Alert($"No such patient {id}", AlertType.Warning);
                return RedirectToAction(nameof(Index));
            }

            // Pass patient to view for editing

            return View(p);
        }

        // POST /patient/edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin,manager")]
        public IActionResult Edit(int id, [Bind("Id, Name, Email, Age")] Patient p)
        {
            // check email is unique for this patient
            if (svc.IsDuplicateEmail(p.Email, p.Id))
            {
                // add manual validation error
                ModelState.AddModelError(nameof(p.Email), "The email address is already in use.");
            }

            // validate patient
            if (ModelState.IsValid)
            {
                // pass data to service to update
                svc.UpdatePatient(p);
                Alert("Patient details saved", AlertType.Info);

                return RedirectToAction(nameof(Index));
            }

            // redisplay the form for editing as validation errors
            return View(p);
        }

        // GET /patient/delete/{id}
        [Authorize(Roles="admin")]
        public IActionResult Delete(int id)
        {
            // load the patient using the service
            var p = svc.GetPatient(id);

            // check the returned patient is not null and if so return NotFound()
            if (p == null)
            {
                Alert("Patient not found!", AlertType.Warning);
                return RedirectToAction(nameof(Index));
            }

            // pass patient to view for deletion confirmation
            return View(p);
        }

        // POST /patient/delete/{id}
        [HttpPost]
        [Authorize(Roles="admin")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            // delete patient via service
            svc.DeletePatient(id);

            Alert($"Patient {id} deleted successfully", AlertType.Success);

            // Redirect to index view

            return RedirectToAction(nameof(Index));
        }

        // GET /patient/createmedicine
        [Authorize(Roles="admin, manager")]
        public IActionResult CreateMedicine(int id)
        {
            var p = svc.GetPatient(id);
            // check the returned patient is not null and if so alert
            if (p == null)
            {
                Alert($"No such patient {id}", AlertType.Warning);
                return RedirectToAction(nameof(Index));
            }

            // create the medicine view model and populate the PatientId property
            var m = new MedicineCreateViewModel
            {
                PatientId = id
            };

            return View("CreateMedicine", m);
        }

        // POST /patient/createmedicine
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="admin, manager")]
        public IActionResult CreateMedicine([Bind("PatientId, Request")] MedicineCreateViewModel m)
        {
            var p = svc.GetPatient(m.PatientId);

            // check the returned patient is not null and if so return NotFound()
            if (p == null)
            {
                Alert($"No such patient {m.PatientId}", AlertType.Warning);
                return RedirectToAction(nameof(Index));
            }

            // create Medicine view model and populate the PatientId property
            svc.CreateMedicine(m.PatientId, m.Request);
            Alert($"Medicine request submitted successfully", AlertType.Success);

            return RedirectToAction("Details", new { Id = m.PatientId });
        }

        // GET /patient/search/{query}
        public IActionResult Search(string query)
        {
            var results = svc.GetPatientsScript(p => p.Name != null && p.Name.ToLower().Contains(query.ToLower()));
            return View("Index", results);
        }

    }
}
