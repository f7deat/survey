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
        public IActionResult Index() {
            ViewData["Title"] = "Kết quả đánh giá";
            return View(DataExample.Tickets);
        }

        [HttpPost]
        public IActionResult Create(Vote vote) {
            var user = HttpContext.Session.Get<UserSession>("Survey");
            var isExist = DataExample.Statisticals.Any(x => x.TicketId == vote.TicketId && x.UserId == user.Id);
            if (isExist) {
                return Redirect("/vote/exist");
            }
            var statistical = new Statistical();

            // 1
            for (int i = 1; i <= vote.Level1.Length; i++)
            {
                switch (vote.Level1[i])
                {
                    case 0: statistical.Vote0++; break;
                    case 1: statistical.Vote1++; break;
                    case 2: statistical.Vote2++; break;
                    case 3: statistical.Vote3++; break;
                }
            }
            statistical.UserId = user.Id;
            statistical.TicketId = vote.TicketId;
            statistical.QuizType = QuizType.Content1;
            statistical.TotalQuiz = vote.Level1.Length;
            statistical.Name = user.Name;
            DataExample.Statisticals.Add(statistical);
            // 2
            if(vote.Level2?.Length > 0) {
                for (int i = 1; i <= vote.Level2.Length; i++)
            {
                switch (vote.Level2[i])
                {
                    case 0: statistical.Vote0++; break;
                    case 1: statistical.Vote1++; break;
                    case 2: statistical.Vote2++; break;
                    case 3: statistical.Vote3++; break;
                }
            }
            statistical.UserId = user.Id;
            statistical.TicketId = vote.TicketId;
            statistical.QuizType = QuizType.Content2;
            statistical.TotalQuiz = vote.Level2.Length;
            statistical.Name = user.Name;
            DataExample.Statisticals.Add(statistical);
            }
            // 3
            if(vote.Level3?.Length > 0) {
                for (int i = 1; i <= vote.Level3?.Length; i++)
            {
                switch (vote.Level3[i])
                {
                    case 0: statistical.Vote0++; break;
                    case 1: statistical.Vote1++; break;
                    case 2: statistical.Vote2++; break;
                    case 3: statistical.Vote3++; break;
                }
            }
            statistical.UserId = user.Id;
            statistical.TicketId = vote.TicketId;
            statistical.QuizType = QuizType.Content3;
            statistical.TotalQuiz = vote.Level3.Length;
            statistical.Name = user.Name;
            DataExample.Statisticals.Add(statistical);
            }
            // 4
            if(vote.Level4?.Length > 0) {
                for (int i = 1; i <= vote.Level4?.Length; i++)
            {
                switch (vote.Level4[i])
                {
                    case 0: statistical.Vote0++; break;
                    case 1: statistical.Vote1++; break;
                    case 2: statistical.Vote2++; break;
                    case 3: statistical.Vote3++; break;
                }
            }
            statistical.UserId = user.Id;
            statistical.TicketId = vote.TicketId;
            statistical.QuizType = QuizType.Content4;
            statistical.TotalQuiz = vote.Level4.Length;
            statistical.Name = user.Name;
            DataExample.Statisticals.Add(statistical);
            }
            // 5
            if(vote.Level5?.Length > 0) {
                for (int i = 1; i <= vote.Level5.Length; i++)
            {
                switch (vote.Level5[i])
                {
                    case 0: statistical.Vote0++; break;
                    case 1: statistical.Vote1++; break;
                    case 2: statistical.Vote2++; break;
                    case 3: statistical.Vote3++; break;
                }
            }
            statistical.UserId = user.Id;
            statistical.TicketId = vote.TicketId;
            statistical.QuizType = QuizType.Content5;
            statistical.TotalQuiz = vote.Level5.Length;
            statistical.Name = user.Name;
            DataExample.Statisticals.Add(statistical);
            }
            return RedirectToAction(nameof(Thank));
        }

        public IActionResult Thank() {
            return View();
        }
        public IActionResult Exist() {
            return View();
        }

        public IActionResult Details(int id) {
            var statisticals = DataExample.Statisticals.Where(x => x.TicketId == id).ToList();
            return View(statisticals);
        }
    }
}