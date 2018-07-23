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
            DateTime thisDate1 = new DateTime(2011, 6, 10);
            Sighting newSighting = new Sighting("New description", thisDate1, "Address", "city", "state", "zip");
            List<Sighting> allSightings = Sighting.GetSightings();
            newSighting.ConvertToLatLongAsync(Sighting.GetLastAddress());
            return View(allSightings);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
