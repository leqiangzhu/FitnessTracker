using System.Collections.Generic;
using System; 
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class PersonInfoController : Controller
    {
      [HttpGet("/infos")]
        public ActionResult Index()
        {
          List<PersonInfo> allPersonInfos = PersonInfo.GetAllInfo();
            return View(allPersonInfos);
        }

      [HttpGet("/infos/new")]
        public ActionResult CreateForm()
        {
          return View();
        }

      [HttpPost("/infos")]
        public ActionResult Create()
        {
          PersonInfo newPersonInfo = new PersonInfo(
          Request.Form["new-firstname"],
          Request.Form["new-lastname"],
          Request.Form["new-phone-number"],
          Request.Form["new-email"],
          double.Parse(Request.Form["new-height"]),
          double.Parse(Request.Form["new-weight"]),
          DateTime.Parse(Request.Form["new-birthday"]),
          Request.Form["new-gender"]);
          newPersonInfo.Save();
          return RedirectToAction("Index");
        }

        [HttpPost("/infos/{id}")]
        public ActionResult AddExerciseToUser()
        {
          PersonInfo foundPerson = PersonInfo.Find(id);
          
        }
    }
}
