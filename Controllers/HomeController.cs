using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission8_Group14.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group14.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTask()
        {
            return View();
        }

        public IActionResult Quadrants()
        {
            return View();
        }
    }
}
