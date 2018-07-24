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
            DateTime time = new DateTime(2011, 6, 10);
            Sighting newSighting = new Sighting("New description", "type", time, "Address", "city", "state", "zip");
            List<Sighting> allSightings = Sighting.GetSightings();
            newSighting.ConvertToLatLongAsync(Sighting.GetLastAddress());
            return View(allSightings);
        }
    }
}
