using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MMS.Data.Models;

namespace MMS.Rest.Models
{
    public class MedicineDto
    {
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }
        [Required]
        public string Request { get; set; }

        public string Resolution { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ResolvedOn { get; set; }
        public bool Active { get; set; }

        public static Medicine ToMedicine(MedicineDto m)
        {
            return new Medicine
            {
                Id = m.Id,
                PatientId = m.PatientId,
                MedicineName = m.Request,
                CreatedOn = m.CreatedOn,
                Active = m.Active
            };
        }

        public static MedicineDto FromMedicine(Medicine m)
        {
            return new MedicineDto
            {
                Id = m.Id,
                PatientId = m.PatientId,
                Request = m.MedicineName,
                CreatedOn = m.CreatedOn,
                Active = m.Active
            };
        }
    }
}
