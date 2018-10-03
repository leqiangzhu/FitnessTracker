using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]

        public ActionResult SignIn()

        {
            return View();
        }
    }
}
