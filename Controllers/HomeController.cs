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
        
        private TaskFormContext _taskFormContext { get; set; }
        public HomeController(TaskFormContext someName)
        {
            
            _taskFormContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _taskFormContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(TaskForm tf)
        {
            if(ModelState.IsValid)
            {
            _taskFormContext.Add(tf);
            _taskFormContext.SaveChanges();
            
            return View("Quadrants", tf);
            }

            else
            {
                ViewBag.Categories = _taskFormContext.Categories.ToList();
                return View();
            }

        }

        public IActionResult Quadrants()
        {
            return View();
        }
    }
}
