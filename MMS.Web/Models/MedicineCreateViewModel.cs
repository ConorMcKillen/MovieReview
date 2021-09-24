using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace MMS.Web.Models
{
    public class MedicineCreateViewModel
    {
        // selectlist of patients (id, name)
        public SelectList Patients { get; set; }

        // Collecting PatientId and issue in form
        [Required]
        [Display(Name = "Select Patient")]
        public int PatientId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Request { get; set; }
    }
}
