using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MMS.Data.Models;

namespace MMS.Web.Models
{
    public class UserLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
