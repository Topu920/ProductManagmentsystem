using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Project_of_Online_Product_Management_System.Data;
using Project_of_Online_Product_Management_System.Models;
using Project_of_Online_Product_Management_System.ViewModels;
using System;
using System.IO;
using System.Linq;

namespace Project_of_Online_Product_Management_System.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataContext _context;
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(DataContext context, IHostEnvironment hostingEnvironment, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var allProduct = _context.Products.ToList();
            return View(allProduct);
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var allProduct = _context.Products.Find(id);
            if (allProduct.FreezeProduct == 1)
            {
                allProduct.FreezeProduct = 2;
            }
            else
            {
                allProduct.FreezeProduct = 1;
            }
            var updated = _context.Products.Attach(allProduct);
            updated.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var allProduct = _context.Products.Find(id);
            return View(allProduct);
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                var newProduct = new Products
                {
                    ProductCode = model.ProductCode,
                    ProductName = model.ProductName,
                    ProductDetails = model.ProductDetails,
                    PhotoPathOfProduct = uniqueFileName,
                    FreezeProduct = model.FreezeProduct,
                    UserId = Convert.ToInt32(HttpContext.Session.GetString("ID"))
                };

                _context.Products.Add(newProduct);
                _context.SaveChanges();
                // return RedirectToAction("details", new { id = newProduct.Id });
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private string ProcessUploadedFile(CreateProductViewModel model)
        {
            string uniqueFileName = null;
            if (model.ProductPhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProductPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                model.ProductPhoto.CopyTo(new FileStream(filePath, FileMode.Create));

            }
            return uniqueFileName;
        }

        public IActionResult Edit(int Id)
        {
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var product = _context.Products.Find(Id);

            var updateProduct = new ProductEditViewModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductCode = product.ProductCode,
                ProductDetails = product.ProductDetails,
                ExistingPhotoPath = product.PhotoPathOfProduct,
                FreezeProduct = product.FreezeProduct
            };
            return View(updateProduct);
        }
        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model)
        {
            var product = _context.Products.Find(model.Id);

            product.ProductName = model.ProductName;
            product.ProductCode = model.ProductCode;
            product.ProductDetails = model.ProductDetails;
            product.FreezeProduct = model.FreezeProduct;
            if (model.ProductPhoto != null)
            {
                //if (model.ExistingPhotoPath != null)
                //{
                //    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", model.ExistingPhotoPath);
                //    System.IO.File.Delete(filePath);


                //}
                string uniqueFileName = null;
                if (model.ProductPhoto != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProductPhoto.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    model.ProductPhoto.CopyTo(new FileStream(filePath, FileMode.Create));

                }
                model.ExistingPhotoPath = uniqueFileName;
            }

            product.PhotoPathOfProduct = model.ExistingPhotoPath;

            var updated = _context.Products.Attach(product);
            updated.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


    }
}