using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMS.Web.Models
{
    public class MedicineViewModel 
    {
        public int Id { get; set; }

        public string Request { get; set; }
        public string Resolution { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ResolvedOn { get; set; } = DateTime.MinValue;

        public bool Active { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
    }
}
