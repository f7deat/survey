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
    public class UserController : Controller
    {
        private List<User> Users = new List<User>();
        public UserController()
        {
            Users.Add(new User {
                Id = "12AB001", Name = "TanDC", Email = "tandc@defzone.net", Gender = true, DateOfBirth = DateTime.Now, UserType = UserType.Lecturer, Password = "123"
            });
            Users.Add(new User {
                Id = "12AB002", Name = "LinhLP", Email = "linhlp@defzone.net", Gender = true, DateOfBirth = DateTime.Now, UserType = UserType.Trainees, Password = "123"
            });
            Users.Add(new User {
                Id = "12AB003", Name = "HungNV", Email = "hungnv@defzone.net", Gender = true, DateOfBirth = DateTime.Now, UserType = UserType.Trainees, Password = "123"
            });
        }
        public IActionResult Index(UserType id)
        {
            if (id == UserType.Trainees)
            {
                ViewData["Title"] = "Học viên";
            }
            else
            {
                ViewData["Title"] = "Giảng viên";
            }
            return View(Users.Where(x => x.UserType == id));
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string id, string password) {
            var user = Users.FirstOrDefault(x => x.Id == id.ToUpper() && x.Password == password);
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
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout() {
            HttpContext.Session.Remove("Survey");
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}