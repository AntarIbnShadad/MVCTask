using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Task.Data;
using Task.Models;

namespace Task.Controllers
{
    public class CategoriesController : Controller
    {
        AppDbContext db;

        public CategoriesController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Categories()
        {
            return View(GetAllData(false));
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            return View(GetSingleCategory(id));
        }
        public IActionResult Delete(int id)
        {
            db.Categories.Remove(GetSingleCategory(id));
            db.SaveChanges();

            return RedirectToAction(nameof(Categories));
        }
        [HttpPost]
        public IActionResult Create(Category _category)
        {
            Category cat = new Category()
            {
                Name = _category.Name,
                IsActive = true,
                IsDeleted = false
            };
            db.Categories.Add(cat);
            db.SaveChanges();

            return RedirectToAction(nameof(Categories));
        }
        [HttpPost]
        public IActionResult Edit(Category _category)
        {
            //Category toUpdate = GetSingleCategory(_category.CategoryId);
            //toUpdate.Name = _category.Name;
            //toUpdate.IsActive = _category.IsActive;

            db.Update(_category);
            db.SaveChanges();

            return RedirectToAction(nameof(Categories));
        }

        public List<Category> GetAllData(bool _isDeleted)
        {
            if (_isDeleted == true)
            {
                return db.Categories.Where(x => x.IsDeleted == true).Select(i => i).ToList();
            }
            else
            {
                return db.Categories.Where(x => x.IsDeleted == false).Select(i => i).ToList();
            }

        }

        public Category GetSingleCategory(int id)
        {
            Category _category = db.Categories.Find(id);   
            
            if(_category != null)
            {
                return _category;
            }
            else
            {
                return new Category()
                {
                    CategoryId = 0,
                    Name = "Error Has Occured",
                    IsActive = false,
                    IsDeleted = false,
                    Products = new List<Product>()
                };
            }
        }
    }
}
