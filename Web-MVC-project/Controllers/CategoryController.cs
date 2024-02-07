using Microsoft.AspNetCore.Mvc;
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
    }
}
