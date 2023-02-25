using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var tasks = _taskFormContext.Responses
                .Where(x => x.Completed == false)
                .Include(x => x.Category)
                .OrderBy(x => x.Category)
                .ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = _taskFormContext.Categories.ToList();

            var application = _taskFormContext.Responses.Single(x => x.TaskId == taskid);

            return View("AddTask", application);
        }
        [HttpPost]
        public IActionResult Edit(TaskForm blah)
        {
            _taskFormContext.Update(blah);
            _taskFormContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }
        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var application = _taskFormContext.Responses.Single(x => x.TaskId == taskid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(TaskForm tf)
        {
            _taskFormContext.Responses.Remove(tf);
            _taskFormContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

    }
}
