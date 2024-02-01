using Microsoft.AspNetCore.Mvc;
using RentACar.Entities;
using RentACar.Extentions;
using RentACar.Repositories;
using RentACar.ViewModels.Home;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string url)
        {
            LoginVM model = new LoginVM();
            model.Url = url;

            return View(model);
        }
        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
          
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ManagersRepository repo = new ManagersRepository();
            Manager loggedManager = repo.FirstOrDefault(u =>
                                                u.Username == model.Username &&
                                                u.Password == model.Password);

            if (loggedManager == null)
            {
                ModelState.AddModelError("authFailed", "Authentication failed!");
                return View(model);
            }

            this.HttpContext.Session.SetObject("loggedManager", loggedManager);

            if (!string.IsNullOrEmpty(model.Url))
                return new RedirectResult(model.Url);

            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove("loggedManager");

            return RedirectToAction("Index", "Home");
        }
    }
}
