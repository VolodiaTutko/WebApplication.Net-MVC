using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Web_MVC_project.Data;
using Web_MVC_project.Models;

namespace Web_MVC_project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "Category";
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
			return View(new Category());
		}

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            ValidateCategoryName(obj.categoryName, obj.displayOrder);
            ValidateUniqueDisplayOrder(obj.displayOrder);

            if (!ModelState.IsValid)
            {
                return View();
            }

            SaveCategoryToDatabase(obj);

            TempData["message"] = "The category has been created successfully";

            return RedirectToAction("Index");
        }

        private void ValidateCategoryName(string categoryName, int displayOrder)
        {
            if (Regex.IsMatch(categoryName, @"^\d"))
            {
                ModelState.AddModelError("categoryName", "The category name cannot start with a digit");
            }
            else if (categoryName == displayOrder.ToString())
            {
                ModelState.AddModelError("categoryName", "The category name must be different from the display order");
            }
        }

        private void ValidateUniqueDisplayOrder(int displayOrder)
        {
            if (_db.Categories.Any(c => c.displayOrder == displayOrder))
            {
                ModelState.AddModelError("displayOrder", "The display order must be unique");
            }
        }

		public IActionResult Edit(int? categoryId)
		{
            if (categoryId == null || categoryId == 0)
            {
				return NotFound();
			}   

            Category? CategoryFromDb = _db.Categories.Find(categoryId);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }

			return View(CategoryFromDb);
		}


		[HttpPost]
		public IActionResult Edit(Category obj)
		{
            ValidateCategoryName(obj.categoryName, obj.displayOrder);
            ValidateUniqueDisplayOrder(obj.displayOrder);

            if (!ModelState.IsValid)
			{
				return View();
			}

			UpdateCategoryToDatabase(obj);
			TempData["message"] = "The category has been edited successfully";

			return RedirectToAction("Index");
		}


		public IActionResult Delete(int? categoryId)
		{
			if (categoryId == null || categoryId == 0)
			{
				return NotFound();			}


			Category? CategoryFromDb = _db.Categories.Find(categoryId);
			if (CategoryFromDb == null)
			{
				return NotFound();
			}

			return View(CategoryFromDb);
		}


		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? categoryId)
		{
			if (categoryId == null || categoryId == 0)
			{
				return NotFound();
			}
			Category? CategoryFromDb = _db.Categories.Find(categoryId);
			if (CategoryFromDb == null)
			{
				return NotFound();
			}
            DleteCategoryFromDatabase(CategoryFromDb);

			TempData["message"] = "The category has been deleted successfully";
			return RedirectToAction("Index");
		}



		private void DleteCategoryFromDatabase(Category obj)
		{
			_db.Categories.Remove(obj);
			_db.SaveChanges();
		}
		private void UpdateCategoryToDatabase(Category obj)
		{
			_db.Categories.Update(obj);
			_db.SaveChanges();
		}

		private void SaveCategoryToDatabase(Category obj)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
        }
          



    }
}
