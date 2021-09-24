using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MMS.Web.Models
{
    public class ReviewViewModel 
    {
       // selectList of reviews
       public SelectList Reviews { get; set; }

    }
}
