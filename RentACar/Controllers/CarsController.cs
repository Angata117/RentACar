using Microsoft.AspNetCore.Mvc;
using RentACar.Entities;
using RentACar.Extentions;
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
        public IActionResult Create(CreateVM modelVM)
        {
            if (!ModelState.IsValid)
            {
                return View(modelVM);
            }

            CarsRepository repo = new CarsRepository();
            Car carToAdd = new Car();

            carToAdd.Brand = modelVM.Brand;
            carToAdd.Model = modelVM.Model;
            carToAdd.LicensePlate = modelVM.LicensePlate;
            carToAdd.Mileage = modelVM.Mileage;
            carToAdd.Damage = modelVM.Damage;
            carToAdd.PricePerDay = modelVM.PricePerDay;

            repo.Save(carToAdd);

            return RedirectToAction("Index", "Cars");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            CarsRepository repo = new CarsRepository();
            Car carEdit = repo.GetById(Id);

            if (carEdit == null)
            {
                return RedirectToAction("Index", "Cars");
            }

            EditVM model = new EditVM();

            model.Id = carEdit.Id;
            model.Mileage = carEdit.Mileage;
            model.Damage = carEdit.Damage;
            model.PricePerDay = carEdit.PricePerDay;

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EditVM modelVM)
        {
            if (!ModelState.IsValid)
            {
                return View(modelVM);
            }

            CarsRepository repo = new CarsRepository();
            Car carEdit = repo.GetById(modelVM.Id);

            if (carEdit == null)
            {
                return RedirectToAction("Index", "Cars");
            }

            carEdit.Id = modelVM.Id;
            carEdit.Mileage = modelVM.Mileage;
            carEdit.Damage = modelVM.Damage;
            carEdit.PricePerDay = modelVM.PricePerDay;

            repo.Save(carEdit);
            return RedirectToAction("Index", "Cars");
        }
        [HttpGet]
        public IActionResult Rent(int Id)
        {
            Manager loggedManager = HttpContext.Session.GetObject<Manager>("loggedManager");
            CarsRepository repo = new CarsRepository();
            Car carToRent = repo.GetById(Id);

            if (carToRent == null)
            {
                return RedirectToAction("Index", "Cars");
            }
            RentCarVM modelVM = new RentCarVM();
            modelVM.CarId = carToRent.Id;
            modelVM.ManagerId = loggedManager.Id;

            return View(modelVM);
        }
        [HttpPost]
        public IActionResult Rent(RentCarVM modelVM)
        {
            if (!ModelState.IsValid)
            {
                return View(modelVM);
            }

            RentedCarsRepository repo = new RentedCarsRepository();
            RentedCars carToAdd = new RentedCars();

            CarsRepository carRepo = new CarsRepository();
            Car currentCar = carRepo.GetById(modelVM.CarId);
            Manager RentingManager = HttpContext.Session.GetObject<Manager>("loggedManager");
            UsersRepository usersRepo = new UsersRepository(); 
            User renter = usersRepo.GetById(modelVM.UserId);

            carToAdd.Manager = RentingManager;
            carToAdd.RentedDateTime = DateTime.Now;
            carToAdd.DaysRentedFor = modelVM.DaysRentedFor;
            carToAdd.UserId = modelVM.UserId;
            carToAdd.ManagerId = modelVM.ManagerId;
            carToAdd.CarId = modelVM.CarId;
            carToAdd.User = renter;

            repo.Save(carToAdd);
            return RedirectToAction("Index", "Cars");
        }
    }
}
