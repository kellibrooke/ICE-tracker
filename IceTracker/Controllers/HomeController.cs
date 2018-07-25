using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IceTracker.Models;

namespace IceTracker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string model = Sighting.GetSightings();
            return View("Index", model);
        }

        [HttpGet("/about")]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet("/about/{id}")]
        public IActionResult About_LoggedIn(int id)
        {
            User thisUser = IceTracker.Models.User.FindAUserById(id);
            return View(thisUser);
        }
    }
}