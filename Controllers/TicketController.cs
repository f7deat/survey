using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.Models;
using Survey.Entities;
using Survey.Enums;
using Survey.Data;
using Survey.Extensions;

namespace Survey.Controllers
{
    public class TicketController : Controller
    {
        SurveyDbContext _context;
        public List<Ticket> Tickets = new List<Ticket>();
        public TicketController(SurveyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index() {
            var user = HttpContext.Session.Get<UserSession>("Survey");
            if(user == null) {
                return RedirectToAction("login", "user");
            }
            if(user.UserType != UserType.Admin) {
                return RedirectToAction("authorized", "user");
            }
            return View(_context.Tickets.OrderByDescending(x => x.CreateDate));
        }
        public IActionResult Create() {
            ViewBag.Department = _context.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ticket ticket) {
            ticket.CreateDate = DateTime.Now;
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id) {
            
            ViewBag.Department = _context.Departments.ToList();
            var ticket = _context.Tickets.FirstOrDefault(x => x.Id == id);
            return View(ticket);
        }
        [HttpPost]
        public IActionResult Edit(Ticket ticket) {
            var item = _context.Tickets.FirstOrDefault(x => x.Id == ticket.Id);
            item.Name = ticket.Name;
            item.Status = ticket.Status;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id) {
            var ticket = _context.Tickets.FirstOrDefault(x => x.Id == id);
            ViewData["Title"] = ticket.Name;
            ViewBag.Id = id;
            return View(_context.Quizzes.ToList());
        }
        public IActionResult Delete(int id) {
            var ticket = _context.Tickets.FirstOrDefault(x => x.Id == id);
            if(ticket != null) {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Take(int id, string userId) {
            var vote = new Vote();
            vote.Quizzes1 = _context.Quizzes.Where(x => x.QuizType == QuizType.Content1).ToList();
            vote.Quizzes2 = _context.Quizzes.Where(x => x.QuizType == QuizType.Content2).ToList();
            vote.Quizzes3 = _context.Quizzes.Where(x => x.QuizType == QuizType.Content3).ToList();
            vote.Quizzes4 = _context.Quizzes.Where(x => x.QuizType == QuizType.Content4).ToList();
            vote.Quizzes5 = _context.Quizzes.Where(x => x.QuizType == QuizType.Content5).ToList();
            vote.TicketId = id;
            vote.UserId = userId;
            return View(vote);
        }
    }
}