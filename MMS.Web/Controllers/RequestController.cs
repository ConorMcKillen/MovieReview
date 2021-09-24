using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using MMS.Data.Models;
using MMS.Data.Services;
using MMS.Web.Models;


namespace MMS.Web.Controllers
{
    [ApiController]
    [Route("api")]
    public class RequestController : ControllerBase
    {
        private IPatientService svc;
        private readonly string secret; // jwt secret

        public RequestController(IPatientService service, IConfiguration config)
        {
            secret = config.GetValue<string>("JwtConfig:Secret");
            svc = service;
        }

        // POST api/user/login
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<User> Login(UserLoginViewModel login)
        {
            var user = svc.Authenticate(login.Email, login.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Email or Password is incorrect" });
            }
            // sign jwt token to use in secure api requests
            var userWithToken = AuthBuilder.SignJwtToken(user, secret);
            return Ok(userWithToken);
        }

        [HttpGet("medicine")]
        public ActionResult<IList<Medicine>> GetMedicineRequests()
        {
            var medicine = svc.GetAllMedicines();
            return Ok(medicine);
        }

        [HttpGet("medicine/id/{id}")]
        public ActionResult<Medicine> GetMedicine(int id)
        {
            var medicine = svc.GetMedicine(id);
            if (medicine == null)
            {
                return NotFound();
            }

            var vm = new MedicineViewModel
            {
                Id = medicine.Id,
                Request = medicine.MedicineName,
                CreatedOn = medicine.CreatedOn,
                ResolvedOn = medicine.ResolvedOn,
                Active = medicine.Active,
                PatientId = medicine.PatientId,
                PatientName = medicine.Patient.Name
            };
            return Ok(vm);
        }

        [HttpPost("medicine")]
        public ActionResult<DemoViewModel> Create(MedicineViewModel mvm)
        {
            if (ModelState.IsValid)
            {
                var medicine = svc.CreateMedicine(mvm.PatientId, mvm.Request);

                return CreatedAtAction(nameof(GetMedicine), new { Id = medicine.Id }, medicine);
            }

            return BadRequest("Medicine request could not be submitted.");
        }

        [HttpGet("medicine/search/{range}/{query?}")]
        public ActionResult<MedicineViewModel> RequestTicket(MedicineRange range = MedicineRange.OPEN, string query = "")
        {
            var medicines = svc.SearchMedicineRequests(range, query)
                .Select(m => new MedicineViewModel
                {
                    Id = m.Id,
                    Request = m.MedicineName,
                    Resolution = m.Resolution,
                    CreatedOn = m.CreatedOn,
                    ResolvedOn = m.ResolvedOn,
                    Active = m.Active,
                    PatientId = m.PatientId,
                    PatientName = m.Patient.Name
                }).ToList();

            return Ok(medicines);
        }



    }
}
