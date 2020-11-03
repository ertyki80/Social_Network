using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.Concrete;

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
            UserManagerModel user = new UserManagerModel();
            if (user.Login(l.UserName, l.Password))
            {
                TempData["User"] = user.UserId;
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
            UserManagerModel user = new UserManagerModel();
            UsersManagerModel manager = new UsersManagerModel();

            if (manager.CreateUser(u))
            {
                TempData["User"] = manager.GetUserByLogin(u.UserLogin).UserId;
                return RedirectToRoute(new { controller = "RegisteredUser", action = "Index" });
            }
            return new HttpUnauthorizedResult();
        }

    }
}