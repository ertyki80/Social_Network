using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Concrete;

namespace WebApp.Controllers
{
    public class RegisterController:Controller
    {
        // GET: RegisteredUser
        private static UserManagerModel user;
        public RegisterController()
        {
        }
        public ActionResult Index()
        {

            if (TempData["User"] != null)
            {
                user = new UserManagerModel((int)TempData["User"]);
            }
            else
            {
                return new HttpUnauthorizedResult();
            }

            return Redirect("~/RegisteredUser/Users");
        }
        public ActionResult MyPage()
        {
            UsersManagerModel manager = new UsersManagerModel();
            ViewBag.User = manager.GetMyUserById(user.UserId);
            return View();
        }
        public ActionResult Users()
        {
            UsersManagerModel manager = new UsersManagerModel();
            var all_users = manager.GetAllUsers();
            ViewBag.Users = all_users;
            return View();
        }
        [HttpGet]
        public ActionResult UserPage(int id)
        {
            UsersManagerModel manager = new UsersManagerModel();
            var userinfo = manager.GetUserById(id);
            var path = manager.GetPathBetweenUsers(user.UserId, id);
            ViewBag.Path = path;
            ViewBag.User = userinfo;
            TempData["User_Id"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult UserPage()
        {
            int id = (int)TempData["UserId"];

            user.Get().AddFriend(id);
            return Redirect("~/RegisteredUser/Users");
        }

        public ActionResult Posts()
        {
            TempData["User"] = user.UserId;
            return RedirectToRoute(new { controller = "Posts", action = "Index" });
        }


    }
}