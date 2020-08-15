using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_of_Online_Product_Management_System.Data;
using Project_of_Online_Product_Management_System.Models;
using Project_of_Online_Product_Management_System.ViewModels;
using System.Linq;

namespace Project_of_Online_Product_Management_System.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        // GET: Users


        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList(_context.Actors.ToList(), "Id", "UserType");
            return View();

        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Users users)
        {
            try
            {
                _context.Users.Add(users);
                _context.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View(users);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user == null)
                {

                    return View(model);
                }

                HttpContext.Session.SetString("ID", user.Id.ToString());
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetString("ActorId", user.ActorId.ToString());
                var actor = _context.Actors.Find(user.ActorId);
                HttpContext.Session.SetString("ActorName", actor.UserType);

                if (HttpContext.Session.GetString("ActorName") == "Seller")
                {
                    return RedirectToAction("Index", "Products");
                }
                else if (HttpContext.Session.GetString("ActorName") == "Buyer")
                {
                    return RedirectToAction("Index", "Home");
                }


            }
            return View(model);
        }


        public IActionResult LogOut()
        {

            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Users");
        }
    }
}