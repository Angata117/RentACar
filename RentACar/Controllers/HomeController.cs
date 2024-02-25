using Microsoft.AspNetCore.Mvc;
using RentACar.Entities;
using RentACar.Extentions;
using RentACar.Repositories;
using RentACar.ViewModels.Home;
using System.Linq.Expressions;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(IndexVM model)
        {
            model.Page = model.Page <= 0 ? 1 : model.Page;
            model.ItemsPerPage = model.ItemsPerPage <= 0 ? 10 : model.ItemsPerPage;

            Expression<Func<Car, bool>> filter =
                u =>
                    (string.IsNullOrEmpty(model.Brand) || (u.Brand.Contains(model.Brand))) &&
                    (string.IsNullOrEmpty(model.LicensePlate) || (u.LicensePlate.Contains(model.LicensePlate))) &&
                    (string.IsNullOrEmpty(model.Model) || (u.Model.Contains(model.Model)));

            CarsRepository repo = new CarsRepository();

            model.PagesCount = (int)Math.Ceiling(repo.Count(filter) / (double)model.ItemsPerPage);
            model.Items = repo.GetAll(filter, model.Page, model.ItemsPerPage);

            return View(model);
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
