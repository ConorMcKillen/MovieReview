using Microsoft.AspNetCore.Mvc;
using MMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMS.Web.Models
{
    public class MedicineSearchViewModel 
    {
        // result set
        public IList<Medicine> Medicines { get; set; } = new List<Medicine>();

        // search options
        public string Query { get; set; } = "";
        public MedicineRange Range { get; set; } = MedicineRange.OPEN;
    }
}
