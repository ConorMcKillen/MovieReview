using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace MMS.Data.Models
{
    public class Medicine
    {
        public int Id { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string MedicineName { get; set; }

        [StringLength(500)]
        public string Resolution { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ResolvedOn { get; set; } = DateTime.MinValue;

        public bool Active { get; set; }

        // Foreign key relating to Patient ticket owner
        public int PatientId { get; set; }


        // Required to stop cyclical Json parse error in web api
        [JsonIgnore]
        public Patient Patient { get; set; } // navigation property 
        
    }
}
