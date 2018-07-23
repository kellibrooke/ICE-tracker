using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace IceTracker.Controllers
{
    public class UsersController : Controller
    {

        [HttpGet("/users/register")]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost("/users/register")]
        public IActionResult CreateAccountForm(string firstname, string lastname, string phonenumber)
        {
            User newUser = new User(firstname, lastname, phonenumber);
        }
    }
}
