using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.Models;

namespace Survey.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index() {
            return View();
        }
        public IActionResult Create() {
            return View();
        }
        public IActionResult Edit(int id) {
            return View();
        }
        public IActionResult Delete(int id) {
            return RedirectToAction(nameof(Index));
        }
    }
}