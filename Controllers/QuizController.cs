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
        SurveyDbContext _context;
        public QuizController(SurveyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index() {
            return View(_context.Quizzes.ToList());
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Quiz quiz) {
            _context.Quizzes.Add(quiz);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id) {
            var quiz = _context.Quizzes.FirstOrDefault(x => x.Id == id);
            return View(quiz);
        }

        [HttpPost]
        public IActionResult Edit(Quiz quiz) {
            var item = _context.Quizzes.FirstOrDefault(x => x.Id == quiz.Id);
            item.Title = quiz.Title;
            item.QuizType = quiz.QuizType;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        } 

        public IActionResult Delete(int id) {
            var quiz = _context.Quizzes.FirstOrDefault(x => x.Id == id);
            if(quiz != null) {
                _context.Quizzes.Remove(quiz);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}