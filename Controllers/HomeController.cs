using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreModelValidationExamples.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
            //if(string.IsNullOrEmpty(appt.ClientName))
            //{
            //    ModelState.AddModelError(nameof(appt.ClientName), "Please enter your name");
            //}

            ////通过GetValidationSate("")获取ModelValidationState枚举类型
            //if(ModelState.GetValidationState("Date")==ModelValidationState.Valid && DateTime.Now > appt.Date)
            //{
            //    ModelState.AddModelError(nameof(appt.Date), "Please enter a date in the future");
            //}

            //if (!appt.TermsAccepted)
            //{
            //    ModelState.AddModelError(nameof(appt.TermsAccepted), "Your must accept the terms");
            //}

            if(ModelState.GetFieldValidationState(nameof(appt.Date)) == ModelValidationState.Valid
                && ModelState.GetValidationState(nameof(appt.ClientName))== ModelValidationState.Valid
                && appt.ClientName.Equals("Joe", StringComparison.OrdinalIgnoreCase)
                && appt.Date.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("", "Joe cannt book appontments on Mondays");
            }

            if (ModelState.IsValid)
            {
                return View("Completed", appt);
            }
            else
            {
                return View();
            }
            
        }

        public JsonResult ValidateDate(string Date)
        {
            DateTime parseDate;

            if(!DateTime.TryParse(Date, out parseDate))
            {
                return Json("Please enter a valid date");
            } else if(DateTime.Now > parseDate)
            {
                return Json("Please enter a date in the future");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
