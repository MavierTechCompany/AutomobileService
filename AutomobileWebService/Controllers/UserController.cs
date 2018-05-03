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
                return View(); // return to register view with information about wrong parameters
            }

            try
            {
                await _userService.CreateAsync(command);
                return View(); // go to user profile view
            }
            catch (NullResponseException)
            {
                return View(); //register view with info about user existance
            }
            catch (ForbiddenValueException)
            {
                return View(); //register view with info about wrong parameters
            }
        }
    }
}