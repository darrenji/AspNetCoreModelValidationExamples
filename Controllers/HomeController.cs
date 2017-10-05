using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreModelValidationExamples.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreModelValidationExamples.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("MakeBooking", new Appointment { Date = DateTime.Now });
        }

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            return View("Completed", appt);
        }
    }
}
