using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IceTracker.Models;

namespace IceTracker.Controllers
{
    public class SightingsController : Controller
    {

        [HttpGet("/sightings/{id}/save")]
        public IActionResult CreateForm(int id)
        {
            User newUser = IceTracker.Models.User.FindAUserById(id); 
            return View(newUser);
        }

        [HttpPost("/sightings/{idUser}/save")]
        public IActionResult CreateSighting(string description, string type, DateTime time, string address, string city, string state, string zip, int id)
        {
            Sighting newSighting = new Sighting(description, type, time, address, city, state, zip);
            newSighting.Save();
            newSighting.ConvertToLatLongAsync(Sighting.GetLastAddress());
            newSighting.Alert();
            return RedirectToAction("Index", "Home");          
        }
    }
}
 