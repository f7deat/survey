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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Quiz> Quizzes = new List<Quiz>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            UserSession user = HttpContext.Session.Get<UserSession>("Survey");
            if(user == null) {
                ViewBag.User = "Khách";
                ViewBag.Disabled = "disabled";
            }
            else
            {
                ViewBag.User = user.Name;
            }
            var ticket = DataExample.Tickets.FirstOrDefault(x => x.Status == Enums.ETicketStatus.Publish);
            if (ticket == null) {
                return View();
            }
            var votes = new Vote();
            votes.Quizzes = DataExample.Quizzes.Where(x => x.TicketId == ticket.Id).GroupBy(x => x.QuizType).ToList();
            votes.TicketId = ticket.Id;
            votes.Name = ticket.Name;
            return View(votes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
