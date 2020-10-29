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
        public List<Ticket> Tickets = new List<Ticket>();
        public TicketController()
        {
            Tickets = DataExample.Tickets;
        }
        public IActionResult Index() {
            var user = HttpContext.Session.Get<UserSession>("Survey");
            if(user == null) {
                return RedirectToAction("login", "user");
            }
            if(user.UserType != UserType.Admin) {
                return RedirectToAction("authorized", "user");
            }
            return View(Tickets.Where(x => x.Status != ETicketStatus.Delete).OrderByDescending(x => x.CreateDate));
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ticket ticket) {
            ticket.CreateDate = DateTime.Now;
            ticket.Id = new Random().Next();
            Tickets.Add(ticket);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id) {
            var ticket = Tickets.FirstOrDefault(x => x.Id == id);
            return View(ticket);
        }
        [HttpPost]
        public IActionResult Edit(Ticket ticket) {
            var item = Tickets.FirstOrDefault(x => x.Id == ticket.Id);
            item.Name = ticket.Name;
            item.Status = ticket.Status;
            item.Description = ticket.Description;
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id) {
            var ticket = Tickets.FirstOrDefault(x => x.Id == id);
            ViewData["Title"] = ticket.Name;
            ViewBag.Id = id;
            return View(DataExample.Quizzes.Where(x => x.TicketId == id).ToList());
        }
        public IActionResult Delete(int id) {
            var ticket = Tickets.FirstOrDefault(x => x.Id == id);
            if(ticket != null) {
                Tickets.Remove(ticket);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}