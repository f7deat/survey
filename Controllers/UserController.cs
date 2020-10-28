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
        private List<User> Users = new List<User>();
        public IActionResult Index(UserType id)
        {
            if (id == UserType.Trainees)
            {
                ViewData["Title"] = "Học viên";
                ViewBag.Disabled = "disabled";
            }
            else
            {
                ViewData["Title"] = "Giảng viên";
            }
            return View(DataExample.Users.Where(x => x.UserType == id).ToList());
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string id, string password) {
            var user = DataExample.Users.FirstOrDefault(x => x.Id == id.ToUpper() && x.Password == password);
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
            DataExample.Users.Add(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string id) {
            return View(DataExample.Users.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(User user) {
            var item = DataExample.Users.FirstOrDefault(x => x.Id == user.Id);
            item.Name = user.Name;
            item.Department = user.Department;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout() {
            HttpContext.Session.Remove("Survey");
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}