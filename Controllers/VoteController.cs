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
using Microsoft.AspNetCore.Http;
using Survey.Extensions;
using Survey.Data;

namespace Survey.Controllers
{
    public class VoteController : Controller
    {
        SurveyDbContext _context;
        public VoteController(SurveyDbContext context)
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
            ViewData["Title"] = "Kết quả đánh giá";
            return View(_context.Tickets.ToList());
        }

        [HttpPost]
        public IActionResult Create(Vote vote) {
            var isExist = _context.Statisticals.Any(x => x.TicketId == vote.TicketId && x.UserId == vote.UserId);
            if (isExist) {
                return Redirect("/vote/exist");
            }
            var statistical = new Statistical();

            // 1
            for (int i = 0; i < vote.LevelA.Length; i++)
            {
                switch (vote.LevelA[i])
                {
                    case 0: statistical.Vote0++; break;
                    case 1: statistical.Vote1++; break;
                    case 2: statistical.Vote2++; break;
                    case 3: statistical.Vote3++; break;
                }
            }
            statistical.UserId = vote.UserId;
            statistical.TicketId = vote.TicketId;
            statistical.QuizType = QuizType.Content1;
            statistical.TotalQuiz = +vote.LevelA.Length;
            statistical.DateSubmited = DateTime.Now;
            _context.Statisticals.Add(statistical);
            // 2
            if(vote.LevelB?.Length > 0) {
                
                var statistical2 = new Statistical();
                for (int i = 0; i < vote.LevelB.Length; i++)
                {
                    switch (vote.LevelB[i])
                    {
                        case 0: statistical2.Vote0++; break;
                        case 1: statistical2.Vote1++; break;
                        case 2: statistical2.Vote2++; break;
                        case 3: statistical2.Vote3++; break;
                    }
                }
                statistical2.UserId = vote.UserId;
                statistical2.TicketId = vote.TicketId;
                statistical2.QuizType = QuizType.Content2;
                statistical2.TotalQuiz = +vote.LevelB.Length;
                _context.Statisticals.Add(statistical2);
            }
            // 3
            if(vote.LevelC?.Length > 0) {
                var statistical3 = new Statistical();
                for (int i = 0; i < vote.LevelC?.Length; i++)
            {
                switch (vote.LevelC[i])
                {
                    case 0: statistical3.Vote0++; break;
                    case 1: statistical3.Vote1++; break;
                    case 2: statistical3.Vote2++; break;
                    case 3: statistical3.Vote3++; break;
                }
            }
            statistical3.UserId = vote.UserId;
            statistical3.TicketId = vote.TicketId;
            statistical3.QuizType = QuizType.Content3;
            statistical3.TotalQuiz += vote.LevelC.Length;
            statistical.DateSubmited = DateTime.Now;
            _context.Statisticals.Add(statistical3);
            }
            // 4
            if(vote.LevelD?.Length > 0) {
                var statistical4 = new Statistical();
                statistical4.Vote0 = 0;
                statistical4.Vote1 = 0;
                statistical4.Vote2 = 0;
                statistical4.Vote3 = 0;
                for (int i = 0; i < vote.LevelD?.Length; i++)
            {
                switch (vote.LevelD[i])
                {
                    case 0: statistical4.Vote0++; break;
                    case 1: statistical4.Vote1++; break;
                    case 2: statistical4.Vote2++; break;
                    case 3: statistical4.Vote3++; break;
                }
            }
            statistical4.UserId = vote.UserId;
            statistical4.TicketId = vote.TicketId;
            statistical4.QuizType = QuizType.Content4;
            statistical4.TotalQuiz = +vote.LevelD.Length;
            statistical.DateSubmited = DateTime.Now;
            _context.Statisticals.Add(statistical4);
            }
            // 5
            if(vote.LevelE?.Length > 0) {
                var statistical5 = new Statistical();
                for (int i = 0; i < vote.LevelE.Length; i++)
            {
                switch (vote.LevelE[i])
                {
                    case 0: statistical5.Vote0++; break;
                    case 1: statistical5.Vote1++; break;
                    case 2: statistical5.Vote2++; break;
                    case 3: statistical5.Vote3++; break;
                }
            }
            statistical5.UserId = vote.UserId;
            statistical5.TicketId = vote.TicketId;
            statistical5.QuizType = QuizType.Content5;
            statistical5.TotalQuiz += vote.LevelE.Length;
            statistical.DateSubmited = DateTime.Now;
            _context.Statisticals.Add(statistical5);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Thank));
        }

        public IActionResult Thank() {
            return View();
        }
        public IActionResult Exist() {
            return View();
        }

        public IActionResult Details(int id) {
            ViewBag.Total1 = _context.Quizzes.Count(x => x.QuizType == QuizType.Content1);
            ViewBag.Total2 = _context.Quizzes.Count(x => x.QuizType == QuizType.Content2);
            ViewBag.Total3 = _context.Quizzes.Count(x => x.QuizType == QuizType.Content3);
            ViewBag.Total4 = _context.Quizzes.Count(x => x.QuizType == QuizType.Content4);
            ViewBag.Total5 = _context.Quizzes.Count(x => x.QuizType == QuizType.Content5);
            var statisticals = _context.Statisticals.Where(x => x.TicketId == id).ToList();
            return View(statisticals);
        }
    }
}