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

namespace Survey.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Quiz> Quizzes = new List<Quiz>();

        public HomeController(ILogger<HomeController> logger)
        {
            Quizzes.Add(new Quiz {
                Id = 1, Title = "Bạn có hài lòng về chương trình giảng dạy hiện tại", TicketId = 1, ChoiceA = "Rất hài lòng", ChoiceB = "Hài lòng", ChoiceC = "Không hài lòng", ChoiceD = "Rất tệ"
            });
            Quizzes.Add(new Quiz {
                Id = 2, Title = "Bạn có hài lòng về cơ sở vật chất hiện tại", TicketId = 1, ChoiceA = "Rất hài lòng", ChoiceB = "Hài lòng", ChoiceC = "Không hài lòng", ChoiceD = "Rất tệ"
            });
            _logger = logger;
        }

        public IActionResult Index()
        {
            UserSession user = HttpContext.Session.Get<UserSession>("Survey");
            if(user == null) {
                ViewBag.User = "Khách";
            }
            else
            {
                ViewBag.User = user.Name;
            }
            return View(Quizzes);
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
