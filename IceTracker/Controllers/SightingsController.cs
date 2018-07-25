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
        [HttpGet("/sightings")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/{id}/newsighting")]
        public IActionResult CreateForm(int id)
        {
            User newUser = IceTracker.Models.User.FindAUserById(id);
            return View(newUser);
        }

        [HttpPost("/{idUser}/newsighting")]
        public IActionResult CreateSighting(string description, string type, DateTime time, string address, string city, string state, string zip, int id, int idUser)
        {

            Sighting newSighting = new Sighting(description, type, time, address, city, state, zip, idUser);
            newSighting.Save(idUser);
            newSighting.ConvertToLatLongAsync(Sighting.GetLastAddress());
            newSighting.Alert();
            User selectedUser = IceTracker.Models.User.FindAUserById(idUser);
            return RedirectToAction("UserAccount", "Users", selectedUser);
        }

    }
}
 