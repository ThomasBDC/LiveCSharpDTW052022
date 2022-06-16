using DTW.Repository.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LiveCSharpDTW052022.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            List<UserModel> allUsers = _userRepository.GetAllUsers();
            return View(allUsers);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            List<UserModel> allUsers = _userRepository.GetAllUsers();
            var monUser = allUsers.FirstOrDefault(user => user.IdUser == id);
            return View("DetailsUser", monUser);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View("CreateUser");
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            List<UserModel> allUsers = _userRepository.GetAllUsers();
            var monUser = allUsers.FirstOrDefault(user => user.IdUser == id);
            return View("EditUser", monUser);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            List<UserModel> allUsers = _userRepository.GetAllUsers();
            var monUser = allUsers.FirstOrDefault(user => user.IdUser == id);
            return View("DeleteUser", monUser);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
