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
            Dictionary<string, object> model = new Dictionary<string, object>();
            string allSightings = Sighting.GetSightings();
            List<Sighting> sightingsList = Sighting.GetSightingsList();
            model.Add("sightings", allSightings);
            model.Add("sightingsList", sightingsList);
            return View(model);
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