using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IceTracker.Models;


namespace IceTracker.Controllers
{
    public class UsersController : Controller
    {

        [HttpGet("/users/sign-up")]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost("/users/sign-up")]
        public IActionResult CreateAccountForm(bool anony, string firstName, string lastName, string phoneNumber)
        {
            if(anony == true)
            {
                firstName = "Anonymous";
                lastName = "Anonymous";
                User anonyUser = new User(firstName, lastName, phoneNumber);
                anonyUser.SaveUser();

            }
            User newUser = new User(firstName, lastName, phoneNumber);
            newUser.SaveUser();
            return RedirectToAction("UserAccount", new { id = newUser.Id });
        }

        [HttpGet("/users/{id}/delete")]
        public IActionResult DeleteUser(int id)
        {
            IceTracker.Models.User.Delete(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("/users/{id}/updateAccount/")]
        public IActionResult UpdateForm(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            User newUser = IceTracker.Models.User.FindAUserById(id);
            string allSightings = Sighting.GetSightings();
            List<Sighting> sightingsList = Sighting.GetSightingsList();
            model.Add("user", newUser);
            model.Add("sightings", allSightings);
            model.Add("sightingsList", sightingsList);
        
            return View(model);
        }

        [HttpPost("/users/{userId}/updateAccount")]
        public IActionResult Update(string firstName, string lastName, string phone, int userId)
        {
            IceTracker.Models.User.Update(firstName, lastName, phone, userId);
            return RedirectToAction("UserAccount", new { id = userId });
        }
        
        [HttpPost("/users/login")]
        public IActionResult AccountLogin(string phoneNumber)
        {
            User newUser = IceTracker.Models.User.FindAUser(phoneNumber);
            if(newUser.Id == 0)
            {
                return View("CreateAccount");
            }
            return RedirectToAction("UserAccount", new { id = newUser.Id });
        }

        [HttpGet("/users/{id}")]
        public IActionResult UserAccount(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            User newUser = IceTracker.Models.User.FindAUserById(id);
            string allSightings = Sighting.GetSightings();
            List<Sighting> sightingsList = Sighting.GetSightingsList();
            model.Add("user", newUser);
            model.Add("sightings", allSightings);
            model.Add("sightingsList", sightingsList);
            return View(model);
        }
    }
}