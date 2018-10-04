using System.Collections.Generic;
using System; 
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class   AppController : Controller
    {
      [HttpGet("App")]
        public ActionResult Index()
        {
            return View("App");
        }

     
        





        



    }
}
