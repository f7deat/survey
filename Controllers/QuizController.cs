using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.Data;
using Survey.Entities;
using Survey.Models;

namespace Survey.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Create(int id) {
            ViewBag.TicketId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Quiz quiz) {
            quiz.Id = new Random().Next();
            DataExample.Quizzes.Add(quiz);
            return RedirectToAction("Details", "Ticket", new { id = quiz.TicketId });
        }

        public IActionResult Edit(int id) {
            var quiz = DataExample.Quizzes.FirstOrDefault(x => x.Id == id);
            return View(quiz);
        }

        [HttpPost]
        public IActionResult Edit(Quiz quiz) {
            return RedirectToAction("Details", "Ticket", new { id = quiz.TicketId });
        } 

        public IActionResult Delete(int id) {
            var quiz = DataExample.Quizzes.FirstOrDefault(x => x.Id == id);
            if(quiz != null) {
                DataExample.Quizzes.Remove(quiz);
            }
            return RedirectToAction("Details", "Ticket", new { id = quiz.TicketId });
        }
    }
}