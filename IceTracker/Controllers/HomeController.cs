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
    }
}