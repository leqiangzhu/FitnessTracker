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
       List<PersonInfo> allPersonInfos = PersonInfo.GetAllInfo();
       PersonInfo newperson= PersonInfo.Find(1);
            return View("App",newperson);
        }

     
        





        



    }
}
