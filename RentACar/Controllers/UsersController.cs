using Microsoft.AspNetCore.Mvc;
using RentACar.Entities;
using RentACar.Filters;
using RentACar.Repositories;
using RentACar.ViewModels.Users;
using System.Linq.Expressions;

namespace RentACar.Controllers
{
    public class UsersController : Controller
    {
        [AuthenticationFilter]
        public IActionResult Index(IndexVM model)
        {
            model.Page = model.Page <= 0 ? 1 : model.Page;

            model.ItemsPerPage = model.ItemsPerPage <=0 ?10 : model.ItemsPerPage;

            Expression<Func<User,bool>> filter =
                                            u => (string.IsNullOrEmpty(model.FirstName) || (u.FirstName.Contains(model.FirstName))) &&
                                                 (string.IsNullOrEmpty(model.LastName) || (u.LastName.Contains(model.LastName))) &&
                                                 (string.IsNullOrEmpty(model.EGN) || (u.EGN.Contains(model.EGN)));
            UsersRepository repo = new UsersRepository();

            model.PagesCount = (int)Math.Ceiling(repo.Count(filter) / (double)model.ItemsPerPage);
            model.Items = repo.GetAll(filter,model.Page,model.ItemsPerPage);

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
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            UsersRepository repo = new UsersRepository();
            User user = new User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.EGN = model.EGN;
            user.PhoneNumber = model.PhoneNumber;

            repo.Save(user);
            return RedirectToAction("Index", "Users");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            UsersRepository repo = new UsersRepository();
            User editUser = repo.GetById(Id);

            if(editUser == null)
            {
                RedirectToAction("Index", "Users");
            }

            EditVM model = new EditVM();
            model.Id = editUser.Id;
            model.FirstName = editUser.FirstName;
            model.LastName = editUser.LastName;
            model.EGN = editUser.EGN;
            model.PhoneNumber = editUser.PhoneNumber;

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            UsersRepository repo = new UsersRepository();
            User editUser = repo.GetById(model.Id);

            if(editUser == null)
            {
                return RedirectToAction("Index", "Users");
            }

            editUser.FirstName = model.FirstName;
            editUser.LastName = model.LastName;
            editUser.EGN = model.EGN;
            editUser.PhoneNumber = model.PhoneNumber;
            
            repo.Save(editUser);

            return RedirectToAction("Index", "Users");
        }
        public IActionResult Delete(int id)
        {
            UsersRepository repo = new UsersRepository();

            User userToDelete = repo.GetById(id);

            if (userToDelete != null)
                repo.Delete(userToDelete);

            return RedirectToAction("Index", "Users");
        }
    }
}
