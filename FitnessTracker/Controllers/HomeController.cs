using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]

        public ActionResult Index()

        {
             List<PersonInfo> allPersonInfos = PersonInfo.GetAllInfo();
       PersonInfo newperson= PersonInfo.Find(1);
            return View(newperson);
        }
    }
}
