﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel l)
        {
            AppUser user = new AppUser();
            if (user.Login(l.UserName, l.Password))
            {
                TempData["User"] = user.User_Id;
                return RedirectToRoute(new { controller = "RegisteredUser", action = "Index" });
            }
            return new HttpUnauthorizedResult();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel u)
        {
            AppUser user = new AppUser();
            IAppUserManager manager = new AppUserManager();

            if (manager.CreateUser(u))
            {
                TempData["User"] = manager.GetUserByLogin(u.User_Login).User_Id;
                return RedirectToRoute(new { controller = "RegisteredUser", action = "Index" });
            }
            return new HttpUnauthorizedResult();
        }

    }
}