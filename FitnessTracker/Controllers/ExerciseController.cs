using System.Collections.Generic;
using System; 
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class   ExerciseController : Controller
    {
      [HttpGet("/ex")]
        public ActionResult Index()
        {
          List<Exercise> allExercises = Exercise.GetAll();
            return View(allExercises);
        }

      [HttpGet("/APP/APP")]
        public ActionResult XS()
        {
            return View("APP");
        }
        





        



    }
}
