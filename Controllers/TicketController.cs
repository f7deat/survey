using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.Models;
using Survey.Entities;

namespace Survey.Controllers
{
    public class TicketController : Controller
    {
        public List<Ticket> Tickets = new List<Ticket>();
        public TicketController()
        {
            Tickets.Add(new Ticket{
                Id = 1,
                CreateDate = DateTime.Now,
                Name = "Đánh giá kết quả cuối năm"
            });
            Tickets.Add(new Ticket{
                Id = 2,
                CreateDate = DateTime.Now,
                Name = "Đánh giá kết quả cuối quý"
            });
        }
        public IActionResult Index() {
            return View(Tickets);
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