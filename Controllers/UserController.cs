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
    public class UserController : Controller
    {
        SurveyDbContext _context;
        public UserController(SurveyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(UserType id)
        {
            var user = HttpContext.Session.Get<UserSession>("Survey");
            if(user == null) {
                return RedirectToAction("login", "user");
            }
            if(user.UserType != UserType.Admin) {
                return RedirectToAction("authorized", "user");
            }
            if (id == UserType.Trainees)
            {
                ViewData["Title"] = "Học viên";
                ViewBag.Disabled = "disabled";
            }
            else
            {
                ViewData["Title"] = "Giảng viên";
            }
            return View(_context.Users.Where(x => x.UserType == id).ToList());
        }

        public IActionResult Delete(string id) {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            _context.Remove(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string id, string password) {
            var user = _context.Users.FirstOrDefault(x => x.Id.ToUpper() == id.ToUpper() && x.Password == password);
            if (user != null)
            {
                var userSession = new UserSession {
                    Id = id,
                    Name = user.Name,
                    UserType = user.UserType
                };

                HttpContext.Session.Set("Survey", userSession);

                return RedirectToAction(nameof(Index), "Home");
            }
            ViewBag.Error = "Sai ID hoặc mật khẩu!";
            return View();
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user) {
            user.UserType = UserType.Trainees;
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string id) {
            return View(_context.Users.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(User user) {
            var item = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            item.Name = user.Name;
            item.Department = user.Department;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout() {
            HttpContext.Session.Remove("Survey");
            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult Authorized() {
            return View();
        }

        public IActionResult Start() {
            ViewBag.Department = _context.Departments.ToList();
            ViewBag.Ticket = _context.Tickets.ToList();
            return View();
        }

        public IActionResult GetTicket(int id) {
            var ticket = _context.Tickets.Where(x=>x.DeparmentId == id).ToList();
            if(ticket.Count() == 0) {
                return Ok();
            }
            return Ok(ticket);
        }

        [HttpPost]
        public IActionResult GetUser(string id) {
            if(string.IsNullOrEmpty(id)){
                return Ok();
            }
            var user = _context.Users.FirstOrDefault(x => x.Id.ToLower() == id.ToLower());
            return Ok(user);
        }
    }
}