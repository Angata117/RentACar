using Microsoft.AspNetCore.Mvc;
using RentACar.Entities;
using RentACar.Filters;
using RentACar.Repositories;
using RentACar.ViewModels.Cars;
using System.Linq.Expressions;

namespace RentACar.Controllers
{
    public class CarsController : Controller
    {
        [AuthenticationFilter]
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            CarsRepository repo = new CarsRepository();
            Car carToAdd = new Car();

            carToAdd.Brand = model.Brand;
            carToAdd.Model = model.Model;
            carToAdd.LicensePlate = model.LicensePlate;
            carToAdd.Mileage = model.Mileage;
            carToAdd.Damage = model.Damage;
            carToAdd.PricePerDay = model.PricePerDay;

            repo.Save(carToAdd);

            return RedirectToAction("Index", "Cars");
        }
    }
}
