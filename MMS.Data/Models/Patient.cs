using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // required for validation annotations
using System.Text.Json.Serialization;        // required for custom json serialization options
using MMS.Data.Validators;

namespace MMS.Data.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range (18, 99)]
        public int Age { get; set; }

        // 1-N Relationship 
        public IList<Medicine> Medicines { get; set; } = new List<Medicine>();

        public override string ToString()
        {
            return $"{Id}-{Name}";
        }


    }
}
