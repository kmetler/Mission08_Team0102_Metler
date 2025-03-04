using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0102_Metler.Models;

namespace Mission08_Team0102_Metler.Controllers
{
    public class TasksController : Controller
    {
        //Initialize the session through the interface
        private readonly ITaskRepository _context;

        public TasksController(ITaskRepository context)
        {
            _context = context;
        }

        //Create action
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(
                            _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName
                    })
                    .ToList(), "Value", "Text");


            return View();
        }

        //Create post action
        [HttpPost]
        public IActionResult Create(Models.Task data)
        {
            _context.AddTask(data);

            return RedirectToAction("Index", "Home");
        }

        //Edit to pull up the edit field
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);

            ViewBag.CategoryId = new SelectList(
                            _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName
                    })
                    .ToList(), "Value", "Text");

            return View(task);
        }


        //edit to update db
        [HttpPost]
        public IActionResult Edit(Models.Task data)
        {
            _context.UpdateTask(data);
            

            return RedirectToAction("Quadrant");
        }


        //to pull up quadrant view
        public IActionResult Quadrant()
        {
            var tasks = _context.Tasks.ToList();

            return View(tasks);
        }


        //To pull up delete page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);

            return View(task);
        }


        //To actually delete from db
        [HttpPost]
        public IActionResult DeleteForm(int TaskId)
        {
            _context.DeleteTask(TaskId);

            return RedirectToAction("Quadrant"); // Redirect to the Index (or another page)
        }

    }
}
