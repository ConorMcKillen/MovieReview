using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMS.Web.Controllers
{
    public enum AlertType { Success, Danger, Warning, Info }

    public class BaseController : Controller
    {
        // Store Alert in TempData Storage
        // Where alert will only be accessible in next request
        public void Alert(string message, AlertType type = AlertType.Info)
        {
            TempData["Alert.Message"] = message;
            TempData["Alert.Type"] = type.ToString();
        }
    }
}
