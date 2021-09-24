using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMS.Data.Models;
using MMS.Data.Services;


namespace MMS.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineController : ControllerBase
    {
        private IPatientService _service;

        public MedicineController()
        {
            this._service = new PatientServiceDb();
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var patients = _service.GetAllMedicines();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var m = _service.GetMedicine(id);
            if (m == null)
            {
                return NotFound();
            }

            return Ok(m);
        }

        [HttpPost]
        [Authorize(Roles="Admin")]
        public IActionResult create(int patientId, string request)
        {
            if(ModelState.IsValid)
            {
                var result = _service.CreateMedicine(patientId, request);
                if (result != null)
                {
                    return CreatedAtAction(nameof(Get), new { Id = result.Id }, result);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Admin")]
        public IActionResult delete(int id)
        {
            var ok = _service.DeleteMedicine(id);
            if (ok)
            {
                return Ok();
            }
            return NotFound();
        }

    }
}
