using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileWebService.Business_Logic.Commands.User;
using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileWebService.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("registration")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(CreateCommand command)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowErrorMessage = true;
                ViewBag.ErrorMessage = "Coś poszło nie tak.";
                return View();
            }

            try
            {
                await _userService.CreateAsync(command);
                return View(); // go to user profile view
            }
            catch (NullResponseException)
            {
                ViewBag.ShowErrorMessage = true;
                ViewBag.ErrorMessage = "Podany użytkownik już istnieje!";
                return View(); //register view with info about user existance
            }
            catch (ForbiddenValueException)
            {
                ViewBag.ShowErrorMessage = true;
                ViewBag.ErrorMessage = "Podano nieprawidłowe dane!";
                return View(); //register view with info about wrong parameters
            }
        }

        [HttpGet("../user/profile")]
        private async Task<IActionResult> UserProfile(User user)
        {
            return View(user);
        }
    }
}