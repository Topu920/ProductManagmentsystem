using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_of_Online_Product_Management_System.Data;
using Project_of_Online_Product_Management_System.Models;
using Project_of_Online_Product_Management_System.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;

namespace Project_of_Online_Product_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var allProduct = _context.Products.Where(u => u.FreezeProduct != 1).ToList();
            return View(allProduct);
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var allProduct = _context.Products.Find(id);
            var product = new ProductsViewModels()
            {
                Id = allProduct.Id,
                ProductCode = allProduct.ProductCode,
                ProductName = allProduct.ProductName,
                ProductDetails = allProduct.ProductDetails,

                PhotoPathOfProduct = allProduct.PhotoPathOfProduct




            };
            return View(product);
        }
        [HttpPost]
        public IActionResult Details(ProductsViewModels model)
        {
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var data = new CommentTable()
            {
                ProductId = model.Id,
                UserId = Convert.ToInt32(HttpContext.Session.GetString("ID")),
                Comments = model.Comments
            };
            _context.Comments.Add(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Order(int id)
        {
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var product = _context.Products.Find(id);
            var order = new OrderandComment()
            {
                ProductId = product.Id,
                UserId = Convert.ToInt32(HttpContext.Session.GetString("ID"))
            };
            _context.OrderandComments.Add(order);
            _context.SaveChanges();
            // return RedirectToAction("details", new { id = newProduct.Id });
            return RedirectToAction("Index");
        }
    }
}
