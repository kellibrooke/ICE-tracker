using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IceTracker.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IceTracker.Controllers
{
    public class SightingsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/sightings/{id}/save")]
        public IActionResult CreateForm(int id)
        {
            User newUser = IceTracker.Models.User.FindAUserById(id); 
            return View(newUser);
        }

        [HttpPost("/sightings/{idUser}/save")]
        public IActionResult CreateSighting(string description, int idUser)
        {
            Sighting newSighting = new Sighting(description);
            newSighting.Save();
            newSighting.Alert();
            return RedirectToAction("UserAccount", "Users", new { id = idUser});          
        }
    }
}
 