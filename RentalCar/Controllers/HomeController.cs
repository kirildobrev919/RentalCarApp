using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Contracts;
using RentalCar.Models.AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;

namespace RentalCar.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {            
            return RedirectToAction("AllCars", "Cars");
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewData.Values.Add("Your application description page.");

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewData.Values.Add("Your contact page.");
            return View();
        }
    }
}