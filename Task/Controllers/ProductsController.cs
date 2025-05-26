using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.Models;

namespace Task.Controllers
{
    public class ProductsController : Controller
    {
        AppDbContext db;
        public ProductsController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Products()
        {
            return View(GetAllData(false));
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories,"CategoryId","Name");
            return View();
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View(GetSingleProduct(id));
        }
        public IActionResult Details(int id)
        {
            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View(GetSingleProduct(id));
        }
        public IActionResult Delete(int id)
        {
            db.Products.Remove(GetSingleProduct(id));
            db.SaveChanges();

            return RedirectToAction(nameof(Products));
        }
        [HttpPost]
        public IActionResult Create(Product _product)
        {
            Product prod = new Product()
            {
                Name = _product.Name,
                Price = _product.Price,
                ISActive = true,
                IsDeleted = false,
                CategoryId = _product.CategoryId
            };
            db.Products.Add(prod);
            db.SaveChanges();

            return RedirectToAction(nameof(Products));
        }
        [HttpPost]
        public IActionResult Edit(Product _product)
        {
            //Product toUpdate = GetSingleProduct(_product.ProductId);
            //toUpdate.Name = _product.Name;
            //toUpdate.ISActive = _product.ISActive;
            //toUpdate.CategoryId = _product.CategoryId;

            db.Update(_product);
            db.SaveChanges();

            return RedirectToAction(nameof(Products));
        }

        public List<Product> GetAllData(bool _isDeleted)
        {
            if (_isDeleted == true)
            {
                return db.Products.Include(c => c.Category).Where(x => x.IsDeleted == true).Select(i => i).ToList();
            }
            else
            {
                return db.Products.Include(c => c.Category).Where(x => x.IsDeleted == false).Select(i => i).ToList();
            }

        }

        public Product GetSingleProduct(int id)
        {
            Product _products = db.Products.Include(c => c.Category).Where(x => x.ProductId ==id).Select(r => r).FirstOrDefault();

            if (_products != null)
            {
                return _products;
            }
            else
            {
                return new Product()
                {
                    ProductId = 0,
                    Name = "Error Has Occured",
                    ISActive = false,
                    IsDeleted = false,
                    CategoryId = 0
                };
            }
        }
    }
}
