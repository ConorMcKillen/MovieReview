using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MMS.Data.Models;

namespace MMS.Rest.Models
{
    public class CreateMedicineDto
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        public string Request { get; set; }
    }
}
