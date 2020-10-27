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

namespace Survey.Controllers
{
    public class VoteController : Controller
    {
        public IActionResult Index() {
            ViewData["Title"] = "Kết quả đánh giá";
            return View();
        }
    }
}