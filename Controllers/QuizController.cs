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
    public class QuizController : Controller
    {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Create(int id) {
            return View();
        }
    }
}