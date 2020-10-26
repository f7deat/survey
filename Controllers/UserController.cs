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

namespace Survey.Controllers
{
    public class UserController : Controller
    {
        private List<User> Users = new List<User>();
        public UserController()
        {
            Users.Add(new User {
                Id = 1, Name = "TanDC", Email = "tandc@defzone.net", Gender = true, DateOfBirth = DateTime.Now, UserType = UserType.Lecturer
            });
            Users.Add(new User {
                Id = 2, Name = "LinhLP", Email = "linhlp@defzone.net", Gender = true, DateOfBirth = DateTime.Now, UserType = UserType.Trainees
            });
            Users.Add(new User {
                Id = 3, Name = "HungNV", Email = "hungnv@defzone.net", Gender = true, DateOfBirth = DateTime.Now, UserType = UserType.Trainees
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
    }
}