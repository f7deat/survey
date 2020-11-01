using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.Models;
using Survey.Entities;
using Microsoft.AspNetCore.Http;
using Survey.Extensions;
using Survey.Data;

namespace Survey.Controllers
{
    public class DepartmentController : Controller
    {
        SurveyDbContext _context;
        public DepartmentController(SurveyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index() {
            
            return View(_context.Departments.ToList());
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department) {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id) {
            return View(_context.Departments.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Department department) {
            var item = _context.Departments.Find(department.Id);
            item.Name = department.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delele(int id) {
            var department = _context.Departments.Find(id);
            _context.Departments.Remove(department);
            return RedirectToAction(nameof(Index));
        }
    }
}