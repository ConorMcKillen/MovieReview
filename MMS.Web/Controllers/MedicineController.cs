using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class MedicineController : BaseController
    {
        private readonly IPatientService svc;

        // configured via DI
        public MedicineController(IPatientService ps)
        {
            svc = ps;
        }

        public IActionResult Search()
        {
            return View("LitSearch");
        }

        // GET /medicine/index
        public IActionResult Index()
        {
            // retrieve all open medicine requests
            var search = new MedicineSearchViewModel
            {
                Medicines = svc.SearchMedicineRequests(MedicineRange.OPEN, "")
            };

            return View(search);
        }

        // POST /medicine/index
        [HttpPost]
        public IActionResult Index(MedicineSearchViewModel search)
        {
            // perform search query and assign results to viewmodel Medicines property
            search.Medicines = svc.SearchMedicineRequests(search.Range, search.Query);

            // build custom alert message if post
            var alert = $"{search.Medicines.Count} results(s) found searching '{search.Range}' medicine requests.";
            if (search.Query != null && search.Query != "")
            {
                alert += $" for '{search.Query}'";
            }

            // display custom info alert
            Alert(alert, AlertType.Info);

            return View("Index", search);
        }

        // GET /medicine/{id}
        public IActionResult Details(int id)
        {
            var medicine = svc.GetMedicine(id);
            if (medicine == null)
            {
                Alert("Medicine request not found.", AlertType.Warning);
                return RedirectToAction(nameof(Index));
            }

            return View(medicine);
        }

        // POST /medicine/close/{id}
        [HttpPost]
        [Authorize(Roles="admin, manager")]
        public IActionResult Close([Bind("Id, Resolution")] Medicine m)
        {
            // close medicine request via service
            var medicine = svc.CloseRequest(m.Id, m.Resolution);
            if (medicine == null)
            {
                Alert("Medicine request not found", AlertType.Warning);
            }
            else
            {
                Alert($"Medicine request {m.Id} closed", AlertType.Info);
            }

            // redirect to the index view

            return RedirectToAction(nameof(Index));
        }

        // GET /medicine/create
        [Authorize(Roles="admin, manager")]
        public IActionResult Create()
        {
            var patients = svc.GetPatients();
            // populate viewmodel select list property
            var mvm = new MedicineCreateViewModel
            {
                Patients = new SelectList(patients, "Id", "Name")
            };

            // render blank form
            return View(mvm);
        }

        // POST /medicine/create
        [HttpPost]
        [Authorize(Roles="admin, manager")]
        public IActionResult Create(MedicineCreateViewModel mvm)
        {
            if (ModelState.IsValid)
            {
                svc.CreateMedicine(mvm.PatientId, mvm.Request);
                Alert($"Medicine request created", AlertType.Info);
                return RedirectToAction(nameof(Index));
            }

            // redisplay the form for editing
            return View(mvm);
        }


    }
}
