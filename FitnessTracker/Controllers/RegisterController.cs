using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class RegisterController : Controller
    {
      [HttpGet("/Register")]
      public ActionResult Index()
      {
        return View();
      }
      [HttpGet("/Register/new")]
      public ActionResult CreateForm()
      {
        return View();
      }
      [HttpPost("/Register")]
      public ActionResult Create()
      {
        Register newRegister = new Register(Request.Form["new-username"], Request.Form["new-password"]);
        newRegister.Save();
        return RedirectToAction("Index");
      }

    }
}
