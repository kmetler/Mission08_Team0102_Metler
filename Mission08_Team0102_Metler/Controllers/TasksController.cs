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

        public IActionResult Edit()
        {
            return View();
        }
    }
}
