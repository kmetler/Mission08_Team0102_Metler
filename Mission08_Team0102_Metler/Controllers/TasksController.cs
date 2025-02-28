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
        private readonly TaskDbContext _context;

        public TasksController(TaskDbContext context)
        {
            _context = context;
        }

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

        [HttpPost]
        public IActionResult Create(Models.Task data)
        {
            _context.Tasks.Add(data);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
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

        [HttpPost]
        public IActionResult Edit(Models.Task data)
        {
            _context.Tasks.Update(data);
            _context.SaveChanges();

            return RedirectToAction("Quadrant");
        }

        public IActionResult Quadrant()
        {
            var tasks = _context.Tasks.ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);

            return View(task);
        }

        [HttpPost]
        public IActionResult DeleteForm(int TaskId)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == TaskId);

            if (task == null)
            {
                return RedirectToAction("Index", "Home"); // Or another appropriate page
            }

            _context.Tasks.Remove(task); // Remove task from the database
            _context.SaveChanges(); // Commit the changes to the database

            return RedirectToAction("Quadrant"); // Redirect to the Index (or another page)
        }

    }
}
