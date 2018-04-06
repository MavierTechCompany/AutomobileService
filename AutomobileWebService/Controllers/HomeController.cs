using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileWebService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("WorkInProgress");
        }

        [Route("regulations")]
        public IActionResult Regulations()
        {
            return View();
        }

        [Route("registration")]
        public IActionResult Registration()
        {
            return View();
        }
    }
}