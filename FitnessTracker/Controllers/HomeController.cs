using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]

<<<<<<< HEAD
        public ActionResult bongo()
=======
        public ActionResult SignIn()
>>>>>>> 128b423c124062c82160122fd7d094caab617c0b

        {
            return View();
        }
    }
}
